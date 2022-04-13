using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace laba4
{
    class Program
    {
        private const int TomLength = 10000;
        private const int TomLengthLZW = 1000;
        static void Main(string[] args)
        {
            var tree = new Huffman();
            Console.WriteLine("Чтение файла...");
            var encoded = ReadingInFileHaffman();

            Console.WriteLine("Архивация Хофмана");
            Console.WriteLine("Создание битов...");
            CreateBits(encoded);

            Console.WriteLine("Создание частот...");
            tree.Build(encoded);

            Console.WriteLine("Архивация...");
            var x = tree.Encode(encoded);

            Console.WriteLine("Запись...");
            var haffman = GetBitsHaffman(x);
            WriteInArchivingFileHaffman(haffman);

            Console.WriteLine("Разархивация...");
            var str = tree.Decode(x);
            File.WriteAllText("haffmanDecoded.txt", str);
            Console.WriteLine("Готово");
            Console.WriteLine();



            Console.WriteLine("Архивация LZW");
            var lzw = new LZW();

            Console.WriteLine("Архивация...");
            var code = lzw.Encode(encoded);

            Console.WriteLine("Создание битов...");
            var bits = CreateBits(code);

            Console.WriteLine("Запись...");
            WriteInArchivingFileLZW(bits);

            Console.WriteLine("Разархивация...");
            var decode = lzw.Decode(code);
            File.WriteAllText("LZWDecoded.txt", decode);
            Console.WriteLine("Готово");
        }

        private static string ReadingInFileHaffman()
        {
            return File.ReadAllText("data.txt");
        }

        private static void CreateBits(string obj)
        {
            using (var file = new StreamWriter("dataBinary.txt"))
            {
                foreach (var item in obj)
                {
                    int charCode = Convert.ToInt32(item);
                    file.Write(Convert.ToString(charCode, 2).PadLeft(8, '0'));
                }
            }
        }

        private static List<int> GetBitsHaffman(BitArray obj)
        {
            var list = new List<int>();
            foreach (bool item in obj)
            {
                list.Add(item ? 1 : 0);
            }

            return list;
        }

        private static void WriteInArchivingFileHaffman(List<int> obj)
        {
            var take = 0;
            var i = 1;
            var count = obj.Count;
            do
            {
                var items = obj.Skip(take).Take(TomLength);
                take += TomLength;
                File.WriteAllText($"haffman{i++}.txt", string.Join("", items));
            } while (take < count);
        }

        private static List<string> CreateBits(List<int> obj)
        {
            var bits = new List<string>();

            foreach (var item in obj)
            {
                bits.Add(Convert.ToString(item, 2).PadLeft(8, '0'));
            }

            return bits;
        }

        private static void WriteInArchivingFileLZW(List<string> obj)
        {
            var take = 0;
            var i = 1;
            var count = obj.Count;
            do
            {
                var items = obj.Skip(take).Take(TomLengthLZW);
                take += TomLengthLZW;
                File.WriteAllText($"lzw{i++}.txt", string.Join("", items));
            } while (take < count);
        }
    }
}
