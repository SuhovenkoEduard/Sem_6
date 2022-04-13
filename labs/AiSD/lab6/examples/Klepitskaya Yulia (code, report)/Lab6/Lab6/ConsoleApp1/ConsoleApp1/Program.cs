using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string p = "../../../Archives/";

            string lwzFrom = p + "lwzInput.txt";
            string lwzArch = p + "lwzArch.txt";
            string lwzTo = p + "lwzOutput.txt";
            int lwzTom = 115;

            string huffFrom = p + "huffInput.txt";
            string huffArch = p + "huffArch.txt";
            string huffTo = p + "huffOutput.txt";
            int huffTom = 200;

            Lwz.Compress(lwzFrom, lwzArch, lwzTom);
            Lwz.Decompress(lwzArch, lwzTo);

            Huffman.Compress(huffFrom, huffArch, huffTom);
            Huffman.Decompress(huffArch, huffTo);
        }
    }
}
