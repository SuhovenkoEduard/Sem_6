using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleApp1
{
    internal class Lwz
    {
        private static List<string> GenTable()
        {
            List<string> rootTable = new List<string>();
            for (int i = 0; i < 65535; i++)
            {
                char temp = (char)i;
                rootTable.Add(temp.ToString());
            }
            return rootTable;
        }

        public static string[] Compress(string from, string to, int tomSize)
        {
            int parts = Part.NumberOfParts(to);

            for (int i = 0; i <= parts; i++)
                File.Delete(to + i.ToString());

            string input = File.ReadAllText(from);

            DateTime startTime = DateTime.Now;

            var rootTable = GenTable();
            List<int> compressed = new List<int>();
            List<string> compressTable = new List<string>();
            foreach (string element in rootTable)
                compressTable.Add(element);
            string temp_s = input[0].ToString();
            for (int i = 0; i < input.Length - 1; i++)
            {
                char temp_char = input[i + 1];
                if (compressTable.Contains(temp_s + temp_char))
                {    
                    temp_s = temp_s + temp_char;
                }
                else
                {
                    compressed.Add(compressTable.IndexOf(temp_s));
                    compressTable.Add(temp_s + temp_char);
                    temp_s = temp_char.ToString();
                }
                if (i == input.Length - 2)
                {
                    compressed.Add(compressTable.IndexOf(temp_s));
                }
            }
            string output = "";
            foreach (int elem in compressed)
                output += $"{elem} ";
            output = output.Trim();
            int size_before = sizeof(char) * input.Length;
            int size_after = sizeof(int) * compressed.Count;
            string[] res = { output, $"{size_before}", $"{size_after}" };

            DateTime finishTime = DateTime.Now;
            Console.WriteLine("Lwz");

            Console.WriteLine("time: " + (finishTime - startTime).TotalMilliseconds + "ms");
            var koef = new System.IO.FileInfo(from).Length;
            var result = Encoding.Default.GetBytes(res[0]).Length;

            Console.WriteLine("koef " + (koef / Convert.ToDouble(result)));

            Part.ToParts(to, Encoding.Default.GetBytes(res[0]), tomSize);
            return res;
        }

        public static void Decompress(string from, string to)
        {
            var input = Encoding.Default.GetString(Part.FromParts(from));

            var root_table = GenTable();
            string[] arr = input.Split(' ');
            int[] Ints = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
                Ints[i] = int.Parse(arr[i]);
            List<string> decompress_table = new List<string>();
            string output = "";
            foreach (string element in root_table)
                decompress_table.Add(element);
            int temp_i = Ints[0];
            string res = "";
            output += decompress_table[temp_i];
            res += output;
            string temp_s = "";
            char C = ' ';
            for (int i = 1; i < Ints.Length; i++)
            {
                int next_temp = Ints[i];
                if (decompress_table.Count - 1 < next_temp)
                {
                    temp_s = output;
                    temp_s = temp_s + C;
                }
                else
                {
                    temp_s = decompress_table[next_temp];
                }
                res += temp_s;
                C = temp_s[0];
                decompress_table.Add(output + C);
                output = temp_s;
            }

            File.WriteAllText(to, res);
        }
    }
}