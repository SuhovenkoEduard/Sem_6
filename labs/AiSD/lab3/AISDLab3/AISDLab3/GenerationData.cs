using System;
using System.Text;
using System.Threading;

namespace AISDLab3
{
    public static class GenerationData
    {
        public static Item[] GenerateDate(int size)
        {
            var workArray = new Item[size];
            for (var i = 0; i < size; i++)
            {
                Thread.Sleep(30);
                workArray[i] = new Item
                {
                    Date = RandomDay(),
                    Float = RandomFloat(),
                    Str = RandomString(RandomNumber(5, 8), false)
                };
            }

            workArray[2].Date = workArray[3].Date;
            workArray[1].Date = workArray[4].Date;
            workArray[1].Float += 20;
            workArray[6].Date = workArray[7].Date;
            workArray[6].Float = workArray[7].Float;

            return workArray;
        }

        private static string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();

            return builder.ToString();
        }

        private static float RandomFloat()
        {
            Random random = new Random();
            return (float)random.NextDouble() * random.Next(2, 100);

        }

        private static DateTime RandomDay()
        {
            Random random = new Random();
            DateTime start = new DateTime(1995, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(random.Next(range));
        }

        private static int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
    }
}
