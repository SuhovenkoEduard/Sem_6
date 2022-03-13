using System;
using System.Collections.Generic;

namespace lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree tree = new Tree();
            TreeBasedOnArray treeBasedOnArray = new TreeBasedOnArray();
            NodeTreeBasedOnArray rootNodeTreeBasedOnArray = null;
            NodeTree rootNodeTree = null;
            int key;
            bool isNotExit = true;
            while (isNotExit == true)
            {
                Console.WriteLine("\tДерево");
                Console.WriteLine("1 Добавить записи");
                Console.WriteLine("2 Вывести дерево");
                Console.WriteLine("3 Удалить запись");
                Console.WriteLine("4 Поиск записи");
                Console.WriteLine("5 Индивидуальное");
                Console.WriteLine();
                Console.WriteLine("\tДерево на массиве");
                Console.WriteLine("6 Добавить записи");
                Console.WriteLine("7 Вывести дерево");
                Console.WriteLine("8 Удалить запись");
                Console.WriteLine("9 Поиск записи");
                /*Console.WriteLine("10 защита");*/
                Console.WriteLine();
                Console.WriteLine("0 Выйти из программы");

                int menuItem = int.Parse(Console.ReadLine());

                switch(menuItem)
                {
                    case 1:
                        rootNodeTree = tree.Make();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 2:
                        tree.Watch(rootNodeTree);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 3:
                        Console.WriteLine("Введите значение ключа, по которому должна быть удалена запись:");
                        key = int.Parse(Console.ReadLine());
                        rootNodeTree = tree.Delete(key);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 4:
                        Console.WriteLine("Введите искомое значение ключа");
                        key = int.Parse(Console.ReadLine());
                        tree.Search(key);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 5:
                        Console.WriteLine($"Average value of tree: {tree.CalcAverageValue(rootNodeTree)}");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 6:
                        rootNodeTreeBasedOnArray = treeBasedOnArray.Make();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 7:
                        treeBasedOnArray.Watch(rootNodeTreeBasedOnArray);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 8:
                        Console.WriteLine("Введите значение ключа, по которому должна быть удалена запись:");
                        key = int.Parse(Console.ReadLine());
                        rootNodeTreeBasedOnArray = treeBasedOnArray.Delete(key);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 9:
                        Console.WriteLine("Введите искомое значение ключа");
                        key = int.Parse(Console.ReadLine());
                        treeBasedOnArray.Search(key);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    /*case 10:
                        Console.WriteLine("Глубина дерева: " + tree.height(rootNodeTree));
                        Console.ReadKey();
                        Console.Clear();
                        break;*/
                    case 0:
                        isNotExit = false;
                        break;
                    default:
                        Console.WriteLine("Введите корректный номер пункта");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }

            Console.WriteLine("Для выхода из программы нажмите Enter...");
            Console.ReadLine();
        }
    }
}
