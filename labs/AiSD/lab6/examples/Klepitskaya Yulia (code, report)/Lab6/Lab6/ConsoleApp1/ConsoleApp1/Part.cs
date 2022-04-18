using System;
using System.IO;
using System.Linq;

namespace ConsoleApp1
{
    public static class Part
    {
        public static string GetFilePath(string dirPath, string fileName)
        {
            return $"{dirPath}/{fileName}.txt";
        }
        
        public static string GetPartFilePath(string dirPath, string fileName, int part)
        {
            return $"{dirPath}/{fileName}{part}.txt";
        } 
        
        public static void ToParts(string fromPath, string toDirPath, string toBaseFileName, int size)
        {
            var files = File.ReadAllBytes(fromPath);
            var part = 0;
            while (part * size < files.Length)
            {
                File.WriteAllBytes(GetPartFilePath(toDirPath, toBaseFileName, part),
                    files
                        .Skip(part * size)
                        .Take(size)
                        .ToArray());
                part++;
            }
        }
        public static void ToParts(string toDirPath, string toBaseFileName, byte[] bytes, int size)
        {
            var part = 0;
            while (part * size < bytes.Length)
            {
                File.WriteAllBytes(GetPartFilePath(toDirPath, toBaseFileName, part),
                    bytes
                        .Skip(part * size)
                        .Take(size)
                        .ToArray());
                part++;
            }
        }
        
        public static byte[] FromParts(string dirPath, string baseFileName)
        {
            var output = Array.Empty<byte>();

            var part = 0;

            while (File.Exists(GetPartFilePath(dirPath, baseFileName, part)))
            {
                output = output
                    .Concat(File.ReadAllBytes(GetPartFilePath(dirPath, baseFileName, part)))
                    .ToArray();
                part++;
            }
            return output;
        }

        public static int NumberOfParts(string file)
        {
            var i = 0;
            while (File.Exists(file + i))
            {
                i++;
            }
            return i;
        }
    }
}
