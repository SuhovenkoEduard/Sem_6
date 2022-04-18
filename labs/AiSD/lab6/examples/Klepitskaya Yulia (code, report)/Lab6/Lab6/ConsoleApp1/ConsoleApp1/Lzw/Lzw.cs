using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleApp1.Lzw
{
    public static class Lzw
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

        public static void Compress(string inputFilePath, string archDirPath, string archBaseFileName, int tomSize)
        {
            var parts = Part.NumberOfParts(inputFilePath);
            for (var i = 0; i <= parts; i++)
                File.Delete(Part.GetPartFilePath(archDirPath, archBaseFileName, i));

            var input = File.ReadAllText(inputFilePath);

            var startTime = DateTime.Now;

            var rootTable = GenTable();
            var compressed = new List<int>();
            var compressTable = rootTable.ToList();
            var tempS = input[0].ToString();
            for (var i = 0; i < input.Length - 1; i++)
            {
                var tempChar = input[i + 1];
                if (compressTable.Contains(tempS + tempChar))
                {    
                    tempS += tempChar;
                }
                else
                {
                    compressed.Add(compressTable.IndexOf(tempS));
                    compressTable.Add(tempS + tempChar);
                    tempS = tempChar.ToString();
                }
                if (i == input.Length - 2)
                {
                    compressed.Add(compressTable.IndexOf(tempS));
                }
            }
            var output = compressed.Aggregate("", (current, elem) => current + $"{elem} ");
            output = output.Trim();
            var sizeBefore = sizeof(char) * input.Length;
            var sizeAfter = sizeof(int) * compressed.Count;
            string[] res = { output, $"{sizeBefore}", $"{sizeAfter}" };

            var finishTime = DateTime.Now;
            Console.WriteLine("Lzw");

            Console.WriteLine("time: " + (finishTime - startTime).TotalMilliseconds + "ms");
            var koef = new FileInfo(inputFilePath).Length;
            var result = Encoding.Default.GetBytes(res[0]).Length;

            Console.WriteLine("koef " + koef / Convert.ToDouble(result));

            Part.ToParts(archDirPath, archBaseFileName, Encoding.Default.GetBytes(res[0]), tomSize);
        }

        public static void Decompress(string archDirPath, string archBaseFileName, string toFilePath)
        {
            var input = Encoding.Default.GetString(Part.FromParts(archDirPath, archBaseFileName));

            var rootTable = GenTable();
            var arr = input.Split(' ');
            var ints = new int[arr.Length];
            for (var i = 0; i < arr.Length; i++)
                ints[i] = int.Parse(arr[i]);
            var output = "";
            var decompressTable = rootTable.ToList();
            var tempI = ints[0];
            var res = "";
            output += decompressTable[tempI];
            res += output;
            var c = ' ';
            for (var i = 1; i < ints.Length; i++)
            {
                var nextTemp = ints[i];
                string tempS;
                if (decompressTable.Count - 1 < nextTemp)
                {
                    tempS = output;
                    tempS += c;
                }
                else
                {
                    tempS = decompressTable[nextTemp];
                }
                res += tempS;
                c = tempS[0];
                decompressTable.Add(output + c);
                output = tempS;
            }

            File.WriteAllText(toFilePath, res);
        }
    }
}