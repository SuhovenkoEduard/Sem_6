using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISDLab3
{
    public class SortService
    {
        public static Item[] SortOneKey(Item[] workArray)
        {
            var list = workArray.ToList();
            list.Sort(Item.CompareToOneKey);
            return list.ToArray();
        }

        public static Item[] SortTwoKey(Item[] workArray)
        {
            var list = workArray.ToList();
            list.Sort(Item.CompareToTwoKeys);
            return list.ToArray();
        }

        public static Item[] SortThreeKey(Item[] workArray)
        {
            var list = workArray.ToList();
            list.Sort(Item.CompareToThreeKeys);
            return list.ToArray();
        }

        public static Item[] SortThreeKeyWithCheck(Item[] workArray)
        {
            var copiedArray = (Item[]) workArray.Clone();
            for (int i = 0; i < copiedArray.Length; i++)
            {
                int minInd = i;
                for (int j = i + 1; j < copiedArray.Length; j++)
                {
                    if (Item.CompareToThreeKeys(copiedArray[i], copiedArray[j]) == 1)
                    {
                        minInd = j;
                    }
                }

                if (minInd != i)
                {
                    Item temp = copiedArray[i];
                    copiedArray[i] = copiedArray[minInd];
                    copiedArray[minInd] = temp;
                }

                bool sorted = false;
                for (int j = 0; j < copiedArray.Length - 1; j++)
                {
                    if (Item.CompareToThreeKeys(copiedArray[i], copiedArray[i + 1]) <= 0)
                    {
                        sorted = true;
                        break;
                    }
                }
                if (sorted)
                {
                    break;
                }
            }
            return copiedArray;
        }
    }
}
