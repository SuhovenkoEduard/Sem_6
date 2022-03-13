using System;
using System.Diagnostics;

namespace AISDLab3
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите размер массива:");
            int size = int.Parse(Console.ReadLine());

            Item[] workArray = GenerationData.GenerateDate(size);
            Item[] secondArray = workArray;
            Item[] thirdArray = workArray;
            var stopwatch = new Stopwatch();

            Console.WriteLine("Исходный массив: ");
            Print(workArray);
            Console.WriteLine();

            Console.WriteLine("Сортировка по одному ключу: ");
            stopwatch.Start();
            Item[] firstResult = SortService.SortOneKey(workArray);
            stopwatch.Stop();
            Print(firstResult);
            Console.WriteLine("Время сортировки по одному ключу: " + (double)stopwatch.ElapsedTicks / 1000 + " ms\n");

            Console.WriteLine("Сортировка по двум ключам: ");
            stopwatch.Restart();
            Item[] secondResult = SortService.SortTwoKey(secondArray);
            stopwatch.Stop();
            Print(secondResult);
            Console.WriteLine("Время сортировки по двум ключам: " + (double)stopwatch.ElapsedTicks / 1000 + " ms\n");

            Console.WriteLine("Сортировка по трем ключам: ");
            stopwatch.Restart();
            Item[] thirdResult = SortService.SortThreeKey(thirdArray);
            stopwatch.Stop();
            Print(thirdResult);
            Console.WriteLine("Время сортировки по трем ключам: " + (double)stopwatch.ElapsedTicks / 1000 + " ms\n");

            Console.WriteLine("Сортировка с проверкой: ");
            stopwatch.Restart();
            Item[] sortWithCheck = SortService.SortThreeKeyWithCheck(thirdArray);
            stopwatch.Stop();
            Print(sortWithCheck);
            Console.WriteLine("Время сортировки с проверкой: " + (double)stopwatch.ElapsedTicks / 1000 + " ms\n");

            Console.WriteLine("Бинарный поиск: ");
            stopwatch.Restart();
            BinarySearch.Search(workArray, workArray[2]);
            stopwatch.Stop();
            Console.WriteLine("Время нахождения элемента: " + (double)stopwatch.ElapsedTicks / 1000 + " ms\n");
        }

        public static void Print(Item[] items)
        {
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }
    }
}
