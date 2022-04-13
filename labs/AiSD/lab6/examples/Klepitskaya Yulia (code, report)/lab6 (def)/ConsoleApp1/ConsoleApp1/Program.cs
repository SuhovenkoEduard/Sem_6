using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "../../../../input.txt";
            string archive = "../../../../arvhie.txt";
            string output = "../../../../output.txt";

            FirstAlgoritm(input, archive, output);
        }
        static void FirstAlgoritm(string input, string archive, string output)
        {
            string s;
            using (StreamReader sw = new StreamReader(input))
            {
                s = sw.ReadToEnd();
            }

            Console.Write("Пароль: ");
            string password = Console.ReadLine();

            s = password + "|" + s;

            DateTime startTime = DateTime.Now;

            byte[] buffer_in = Encoding.UTF8.GetBytes(s);
            byte[] buffer_out = new byte[buffer_in.Length];
            byte[] buffer_decode = new byte[buffer_in.Length];
            BWTImplementation bwt = new BWTImplementation();
            int primary_index = 0;
            Console.WriteLine("Before BWT: " + s);
         
            //Archivation
            bwt.bwt_encode(buffer_in, buffer_out, buffer_in.Length, ref primary_index);

            string res = Encoding.UTF8.GetString(buffer_out);
            //Console.WriteLine("Compression: \n" + res);
            double koef = Convert.ToDouble(s.Length) * 8.0;
            DateTime finishTime = DateTime.Now;
            Console.WriteLine("время сжатия: " + (finishTime - startTime).TotalMilliseconds + "ms");

            Console.WriteLine($"коэффициент сжатия {koef / Convert.ToDouble(res.Length)}");

            using (StreamWriter sw1 = new StreamWriter(archive, false, System.Text.Encoding.Default))
            {
                sw1.Write(res);
            }

            //decoding
            string decoded = res;
            
            
            //Console.WriteLine("Decompression: \n" + decoded);
            bwt.bwt_decode(buffer_out, buffer_decode, buffer_in.Length, primary_index);

            string tmpPass = "";
            string dec2 = Encoding.UTF8.GetString(buffer_decode);
            int i = 0;

            while (dec2[i] != '|')
            {
                tmpPass += dec2[i];
                i++;
            }
            string inputPass;
            do
            {
                Console.Write("Введите пароль: ");
                inputPass = Console.ReadLine();

            } while (tmpPass != inputPass);
            string dec = dec2;
            dec = dec.Substring(tmpPass.Length + 1);
            Console.WriteLine("Decoded string: {0}", dec);
            using (StreamWriter sw1 = new StreamWriter(output, false, System.Text.Encoding.Default))
            {
                sw1.Write(dec);
            }
        }

        class BWTImplementation
        {
            public void bwt_encode(byte[] buf_in, byte[] buf_out, int size, ref int primary_index)
            {
                int[] indices = new int[size];
                for (int i = 0; i < size; i++)
                    indices[i] = i;

                Array.Sort(indices, 0, size, new BWTComparator(buf_in, size));

                for (int i = 0; i < size; i++)
                    buf_out[i] = buf_in[(indices[i] + size - 1) % size];

                for (int i = 0; i < size; i++)
                {
                    if (indices[i] == 1)
                    {
                        primary_index = i;
                        return;
                    }
                }
            }

            public void bwt_decode(byte[] buf_encoded, byte[] buf_decoded, int size, int primary_index)
            {
                byte[] F = new byte[size];
                int[] buckets = new int[0x100];
                int[] indices = new int[size];

                for (int i = 0; i < 0x100; i++)
                    buckets[i] = 0;

                for (int i = 0; i < size; i++)
                    buckets[buf_encoded[i]]++;

                for (int i = 0, k = 0; i < 0x100; i++)
                {
                    for (int j = 0; j < buckets[i]; j++)
                    {
                        F[k++] = (byte)i;
                    }
                }

                for (int i = 0, j = 0; i < 0x100; i++)
                {
                    while (i > F[j] && j < size - 1)
                    {
                        j++;
                    }
                    buckets[i] = j;
                }

                for (int i = 0; i < size; i++)
                    indices[buckets[buf_encoded[i]]++] = i;

                for (int i = 0, j = primary_index; i < size; i++)
                {
                    buf_decoded[i] = buf_encoded[j];
                    j = indices[j];
                }
            }
        }

        class BWTComparator : IComparer<int>
        {

            private byte[] rotlexcmp_buf = null;

            private int rottexcmp_bufsize = 0;

            public BWTComparator(byte[] array, int size)
            {
                rotlexcmp_buf = array;
                rottexcmp_bufsize = size;
            }


            public int Compare(int li, int ri)
            {
                int ac = rottexcmp_bufsize;
                while (rotlexcmp_buf[li] == rotlexcmp_buf[ri])
                {
                    if (++li == rottexcmp_bufsize)
                        li = 0;
                    if (++ri == rottexcmp_bufsize)
                        ri = 0;
                    if (--ac <= 0)
                        return 0;
                }
                if (rotlexcmp_buf[li] > rotlexcmp_buf[ri])
                    return 1;

                return -1;

            }

        }
    }
}
