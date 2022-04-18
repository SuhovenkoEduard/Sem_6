using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace ConsoleApp1.Huffman
{
   
    public static class Huffman
    {
        private delegate void UpdateCrc(int value);

        private static readonly byte[] Sign = { 0x5a, 0x52, 0x41, 0x48 };

        public static void Compress(string inputFilePath, string archDirPath, string archBaseFileName, int sizeArch)
        {
            var parts = Part.NumberOfParts(inputFilePath);
            for (var i = 0; i <= parts; i++)
                File.Delete(Part.GetPartFilePath(archDirPath, archBaseFileName, i));

            Stream ifstreamIn = new FileStream(inputFilePath, FileMode.Open, FileAccess.Read);
            Stream ofstreamIn = new FileStream(Part.GetFilePath(archDirPath, archBaseFileName), FileMode.Create, FileAccess.ReadWrite);
            var crc = new CrcCalc();

            var startTime = DateTime.Now;

            ofstreamIn.Write(Sign, 0, Sign.Length);
            for (var i = 0; i < 12; i++)
                ofstreamIn.WriteByte(0x0);

            Huff(ifstreamIn, ofstreamIn, val => crc.UpdateByte((byte)val));

            ofstreamIn.Seek(4, SeekOrigin.Begin);
            var bufferIn = BitConverter.GetBytes(ofstreamIn.Length);
            ofstreamIn.Write(bufferIn, 0, bufferIn.Length);

            bufferIn = BitConverter.GetBytes(crc.GetCrc());

            var finishTime = DateTime.Now;
            Console.WriteLine("Huffman");

            Console.WriteLine("time: " + (finishTime - startTime).TotalMilliseconds + "ms");
            var koef = new FileInfo(inputFilePath).Length;
            var res = new FileInfo(Part.GetFilePath(archDirPath, archBaseFileName)).Length;
            Console.WriteLine("koef " + (koef / Convert.ToDouble(res)));
            ofstreamIn.Write(bufferIn, 0, bufferIn.Length);
            ofstreamIn.Close();
            Part.ToParts(Part.GetFilePath(archDirPath, archBaseFileName), archDirPath, archBaseFileName, sizeArch);
            File.Delete(Part.GetFilePath(archDirPath, archBaseFileName));
            ifstreamIn.Close();
        }

        private static void Huff(Stream sin, Stream sout, UpdateCrc callback)
        {
            var t = new Tree();
            int rd;
            Stack<int> ret;
            var bw = new BitIo(sout, true);
            while ((rd = sin.ReadByte()) != -1)
            {
                var tmp = rd;
                callback((byte)tmp);
                if (!t.Contains(rd))
                {
                    ret = t.GetCode(257);
                    while (ret.Count > 0)
                        bw.WriteBit(ret.Pop());
                    int i;
                    for (i = 0; i < 8; i++)
                    {
                        bw.WriteBit(rd & 0x80);
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

        
        public static void Decompress(string archDirPath, string archBaseFileName, string outputFilePath)
        {
            var bytes = Part.FromParts(archDirPath, archBaseFileName);
            File.WriteAllBytes(Part.GetFilePath(archDirPath, archBaseFileName), bytes);
            Stream ifstream = new FileStream(Part.GetFilePath(archDirPath, archBaseFileName), FileMode.Open, FileAccess.Read);
            Stream ofstream = new FileStream(outputFilePath, FileMode.Create, FileAccess.ReadWrite);
            var crcCalc = new CrcCalc();
            if (Sign.Any(t => ifstream.ReadByte() != t))
            {
                ifstream.Close();
                ofstream.Close();
                throw new IOException("The supplied file is not a valid huff archive");
            }

            var buffer = new byte[8];
            ifstream.Read(buffer, 0, 8);
            var size = BitConverter.ToInt64(buffer, 0);
            if (size != ifstream.Length)
            {
                ifstream.Close();
                ofstream.Close();
                throw new IOException("Invalid file length");
            }

            ifstream.Read(buffer, 0, 4);
            var myDecompressor = new Thread(o =>
            {
                try
                {
                    UnHuff(ifstream, ofstream, x => crcCalc.UpdateByte((byte)x));
                }
                catch (Exception)
                {
                    // ignored
                }
            });
            myDecompressor.Start();
            while (myDecompressor.IsAlive)
            {
                Thread.Sleep(100);
            }

            ofstream.Close();
            ifstream.Close();
            File.Delete(Part.GetFilePath(archDirPath, archBaseFileName));
        }

        private static void UnHuff(Stream inStream, Stream outStream, UpdateCrc callback)
        {
            int i;
            var t = new Tree();
            var bitIo = new BitIo(inStream, false);
            while ((i = bitIo.ReadBit()) != 2)
            {
                int sym;
                if ((sym = t.DecodeBinary(i)) != Tree.CharIsEof)
                {
                    outStream.WriteByte((byte)sym);
                    callback(sym);
                }
            }
        }

    }

    public enum NodeType
    {
        Sym,
        Nyt,
        Eof,
        Int,
    }

}