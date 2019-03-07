using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertionSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new[] {3, 7, 4, 4, 6, 5, 8};
            //var arr = new[] { 0, 1, 2, 4, 5, 6, 3, 7 };
            InsertionSort(arr);
        }

        public static void InsertionSort(int[] items)
        {
            var sortedRangeEndIndex = 1;

            while (sortedRangeEndIndex < items.Length)
            {
                if (items[sortedRangeEndIndex] < items[sortedRangeEndIndex - 1])
                {
                    var insertionIndex = FindPosition(items, items[sortedRangeEndIndex]);
                    Insert(items, insertionIndex, sortedRangeEndIndex);
                }

                sortedRangeEndIndex++;
            }
        }

        private static void Insert(int[] items, int insertionIndex, int indexInsertFrom)
        {
            var tmp = items[insertionIndex];
            items[insertionIndex] = items[indexInsertFrom];

            for (int i = indexInsertFrom; insertionIndex < i; i--)
            {
                items[i] = items[i - 1];
            }

            items[insertionIndex + 1] = tmp;
        }

        public static int FindPosition(int[] items, int newItem)
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] > newItem)
                    return i;
            }

            throw new Exception("Индекс не найден");
        }
    }
}
