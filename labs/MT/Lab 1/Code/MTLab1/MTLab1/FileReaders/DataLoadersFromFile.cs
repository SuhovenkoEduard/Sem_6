using MTLab1.StringUtils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTLab1.FileReaders
{
    class Task1Data
    {
        public char[] Alphabet { get; set; } = Array.Empty<char>(); 
        public string StringToCheck { get; set; } = string.Empty;

        public Task1Data(char[] alphabet, string stringToCheck)
        {
            Alphabet = alphabet;
            StringToCheck = stringToCheck;
        }
    }

    class Task2Data
    {
        public char[] Alphabet { get; set; } = Array.Empty<char>();
        public string StringToCheck { get; set; } = string.Empty;
        public StringChild StringChild { get; set; } = StringChild.Other;

        public Task2Data(char[] alphabet, string stringToCheck, StringChild stringChild)
        {
            Alphabet = alphabet;
            StringToCheck = stringToCheck;
            StringChild = stringChild;
        }
    }

    class Task3Data
    {
        public char[] Alphabet { get; set; } = Array.Empty<char>();
        public string Text { get; set; } = string.Empty;
        public string Sequence { get; set; } = string.Empty;

        public Task3Data(char[] alphabet, string text, string sequence)
        {
            Alphabet = alphabet;
            Text = text;
            Sequence = sequence;
        }
    }

    internal class DataLoadersFromFile
    {
        public static string[] filePaths = new string[] 
        {
            "../../../../MTLab1/Resources/task1data.txt",
            "../../../../MTLab1/Resources/task2data.txt",
            "../../../../MTLab1/Resources/task3data.txt",
        };

        public static Task1Data LoadDataForTask1()
        {
            using var fs = new StreamReader(filePaths[0]);
            string data = fs.ReadToEnd();
            string[] parts = data.Split(';');
            Task1Data task1Data = new
            (
                parts[0].ToCharArray(),
                parts[1]
            );
            return task1Data;
        }
        
        public static Task2Data LoadDataForTask2()
        {
            using var fs = new StreamReader(filePaths[1]);
            string data = fs.ReadToEnd();
            string[] parts = data.Split(';');
            Task2Data task2Data = new
            (
                parts[0].ToCharArray(),
                parts[1],
                StringUtilsLibrary.ConvertStringChildToEnum(parts[2])
            );
            return task2Data;
        }
        
        public static Task3Data LoadDataForTask3()
        {
            using var fs = new StreamReader(filePaths[2]);
            string data = fs.ReadToEnd();
            string[] parts = data.Split(';');
            Task3Data task3Data = new
            (
                parts[0].ToCharArray(),
                parts[1],
                parts[2]
            );
            return task3Data;
        }
    }
}
