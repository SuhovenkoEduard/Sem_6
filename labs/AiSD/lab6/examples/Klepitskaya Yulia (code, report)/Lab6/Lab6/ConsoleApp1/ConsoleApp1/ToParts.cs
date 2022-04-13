using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    public static class Part
    {
        public static void ToParts(string file, int size)
        {
            var files = File.ReadAllBytes(file);

            int part = 0;

            while (part * size < files.Length)
            {
                File.WriteAllBytes(file + part.ToString(),
                    files
                        .Skip(part * size)
                        .Take(size)
                        .ToArray());
                part++;
            }
        }
        public static byte[] FromParts(string file)
        {
            byte[] output = new byte[0];

            int part = 0;

            while (File.Exists(file + part.ToString()))
            {
                output = output
                    .Concat(File.ReadAllBytes(file + part.ToString()))
                    .ToArray();
                part++;
            }
            return output;
        }
        public static void ToParts(string file, byte[] bytes, int size)
        {
            int part = 0;

            while (part * size < bytes.Length)
            {
                File.WriteAllBytes(file + part.ToString(),
                    bytes
                        .Skip(part * size)
                        .Take(size)
                        .ToArray());
                part++;
            }
        }

        public static int NumberOfParts(string file)
        {
            int i = 0;
            while (File.Exists(file + i.ToString()))
            {
                i++;
            }
            return i;
        }
    }
}
