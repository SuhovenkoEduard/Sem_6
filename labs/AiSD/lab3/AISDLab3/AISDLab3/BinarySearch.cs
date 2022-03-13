using System;

namespace AISDLab3
{
    public static class BinarySearch
    {
        public static void Search(Item[] array, Item item)
        {
            int low = 0;
            int high = array.Length - 1;
            while (low <= high)
            {
                int mid = (low + high) / 2;
                if (Item.CompareToThreeKeys(item, array[mid]) == -1)
                    high = mid - 1;
                else if (Item.CompareToThreeKeys(item, array[mid]) == 1)
                    low = mid + 1;
                else if (Item.CompareToThreeKeys(item, array[mid]) == 0)
                {
                    Console.WriteLine("Поиск успешен");
                    Console.WriteLine("Элемент {0} найден на позиции {1}\n", item, mid + 1);
                    return;
                }
            }
            Console.WriteLine("Поиск не успешен");
        }
    }
}
