using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace ConsoleApp1
{
   
    public class Huffman
    {
        public delegate void UpdateCRC(int value);

        private static byte[] sign = { 0x5a, 0x52, 0x41, 0x48 };

        public static void Compress(string inputFile, string archFile, int sizeArch)
        {
            int parts = Part.NumberOfParts(archFile);

            for (int i = 0; i <= parts; i++)
                File.Delete(archFile + i.ToString());

            try
            {
                Stream ifstreamIn = new FileStream(inputFile, FileMode.Open, FileAccess.Read);
                Stream ofstreamIn = new FileStream(archFile, FileMode.Create, FileAccess.ReadWrite);
                CRCCalc crc = new CRCCalc();

                DateTime startTime = DateTime.Now;

                ofstreamIn.Write(sign, 0, sign.Length);
                for (int i = 0; i < 12; i++)
                    ofstreamIn.WriteByte(0x0);

                Huff(ifstreamIn, ofstreamIn, val => crc.UpdateByte((byte)val));

                ofstreamIn.Seek(4, SeekOrigin.Begin);
                byte[] bufferIn = BitConverter.GetBytes(ofstreamIn.Length);
                ofstreamIn.Write(bufferIn, 0, bufferIn.Length);

                bufferIn = BitConverter.GetBytes(crc.GetCRC());

                DateTime finishTime = DateTime.Now;
                Console.WriteLine("Huffman");

                Console.WriteLine("time: " + (finishTime - startTime).TotalMilliseconds + "ms");
                var koef = new System.IO.FileInfo(inputFile).Length;
                var res = new System.IO.FileInfo(archFile).Length;
                Console.WriteLine("koef " + (koef / Convert.ToDouble(res)));
                ofstreamIn.Write(bufferIn, 0, bufferIn.Length);
                ofstreamIn.Close();
                Part.ToParts(archFile, sizeArch);
                File.Delete(archFile);
                ifstreamIn.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static void Huff(Stream sin, Stream sout, UpdateCRC callback)
        {
            Tree t = new Tree();
            int rd, i, tmp;
            Stack<int> ret;
            BitIO bw = new BitIO(sout, true);
            while ((rd = sin.ReadByte()) != -1)
            {
                tmp = rd;
                callback((byte)tmp);
                if (!t.contains(rd))
                {
                    ret = t.GetCode(257);
                    while (ret.Count > 0)
                        bw.WriteBit(ret.Pop());
                    for (i = 0; i < 8; i++)
                    {
                        bw.WriteBit((int)(rd & 0x80));
                        rd <<= 1;
                    }
                    t.UpdateTree(tmp);
                }
                else
                {
                    ret = t.GetCode(tmp);
                    while (ret.Count > 0)
                        bw.WriteBit(ret.Pop());
                    t.UpdateTree(tmp);
                }
            }

            ret = t.GetCode(256);
            while (ret.Count > 0)
            {
                bw.WriteBit(ret.Pop());
            }
        }

        public static void Huff(Stream sin, Stream sout)
        {
            Tree t = new Tree();
            int rd, i, tmp;
            Stack<int> ret;
            BitIO bw = new BitIO(sout, true);
            while ((rd = sin.ReadByte()) != -1)
            {
                tmp = rd;
                if (!t.contains(rd))
                {
                    ret = t.GetCode(257);
                    while (ret.Count > 0)
                        bw.WriteBit(ret.Pop());
                    for (i = 0; i < 8; i++)
                    {
                        bw.WriteBit((int)(rd & 0x80));
                        rd <<= 1;
                    }
                    t.UpdateTree(tmp);
                }
                else
                {
                    ret = t.GetCode(tmp);
                    while (ret.Count > 0)
                        bw.WriteBit(ret.Pop());
                    t.UpdateTree(tmp);
                }
            }

            ret = t.GetCode(256);
            while (ret.Count > 0)
                bw.WriteBit(ret.Pop());
            bw.Close();
        }

        public static void Decompress(string archFile, string outputFile)
        {
            var bytes = Part.FromParts(archFile);
            File.WriteAllBytes(archFile, bytes);
            Stream ifstream = new FileStream(archFile, FileMode.Open, FileAccess.Read);
            Stream ofstream = new FileStream(outputFile, FileMode.Create, FileAccess.ReadWrite);
            CRCCalc crcCalc = new CRCCalc();
            uint crc_old, crc_new;

            for (int i = 0; i < sign.Length; i++)
                if (ifstream.ReadByte() != sign[i])
                {
                    ifstream.Close();
                    ofstream.Close();
                    throw new IOException("The supplied file is not a valid huff archive");
                }

            byte[] buffer = new byte[8];
            ifstream.Read(buffer, 0, 8);
            long size = BitConverter.ToInt64(buffer, 0);
            if (size != ifstream.Length)
            {
                ifstream.Close();
                ofstream.Close();
                throw new IOException("Invalid file length");
            }

            ifstream.Read(buffer, 0, 4);
            crc_old = BitConverter.ToUInt32(buffer, 0);

            Thread myDecompressor = new Thread(o =>
            {
                try
                {
                    UnHuff(ifstream, ofstream, x => crcCalc.UpdateByte((byte)x));
                }
                catch (Exception e)
                {
                }
            });
            myDecompressor.Start();
            while (myDecompressor.IsAlive)
            {
                Thread.Sleep(100);
            }

            ofstream.Close();
            ifstream.Close();
            File.Delete(archFile);
        }

        public static void UnHuff(Stream InStream, Stream OutStream, UpdateCRC callback)
        {
            int i = 0, count = 0, sym;
            Tree t = new Tree();
            BitIO bitIO = new BitIO(InStream, false);
            while ((i = bitIO.ReadBit()) != 2)
            {
                if ((sym = t.DecodeBinary(i)) != Tree.CharIsEof)
                {
                    OutStream.WriteByte((byte)sym);
                    callback(sym);
                    count++;
                }
            }
        }

        public static void UnHuff(Stream InStream, Stream OutStream)
        {
            int i = 0, count = 0;
            Tree t = new Tree();
            BitIO bitIO = new BitIO(InStream, false);
            while ((i = bitIO.ReadBit()) != 2)
            {
                if ((count = t.DecodeBinary(i)) != Tree.CharIsEof)
                    OutStream.WriteByte((byte)count);
            }
        }
    }

    public enum NodeType
    {
        SYM,
        NYT,
        EOF,
        INT,
    }

}