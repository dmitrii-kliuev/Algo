using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectionSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new[] {7, 10, 5, 2, 4, 0, 1};
            SelectionSort(arr);
        }

        static void SelectionSort(int[] arr)
        {
            var sortedIndexEndRange = 0;
            while (sortedIndexEndRange != arr.Length)
            {
                var minIndex = FindMinIndex(arr, sortedIndexEndRange);
                Swap(arr, minIndex, sortedIndexEndRange);
                sortedIndexEndRange++;
            }
        }

        static void Swap(int[] arr, int minIndex, int sortedIndexEndRange)
        {
            var tmp = arr[sortedIndexEndRange];
            arr[sortedIndexEndRange] = arr[minIndex];
            arr[minIndex] = tmp;
        }

        static int FindMinIndex(int[] arr, int sortedIndexEndRange)
        {
            int minIndex = sortedIndexEndRange;
            int minValue = arr[sortedIndexEndRange];
            for (int i = sortedIndexEndRange; i < arr.Length; i++)
            {
                if (arr[i] < minValue)
                {
                    minValue = arr[i];
                    minIndex = i;
                }
            }

            return minIndex;
        }

        static int FindMaxIndex(int[] arr, int sortedIndexEndRange)
        {
            int maxIndex = sortedIndexEndRange;
            int maxValue = arr[sortedIndexEndRange];
            for (int i = sortedIndexEndRange; i < arr.Length; i++)
            {
                if (arr[i] > maxValue)
                {
                    maxValue = arr[i];
                    maxIndex = i;
                }
            }

            return maxIndex;
        }
    }
}
