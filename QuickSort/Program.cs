﻿using System;

namespace QuickSort
{
    internal class Program
    {
        private static void Main()
        {
            int[] array = { 3, 7, 4, 4, 6, 5, 8, 12, 19, 2, 0 };
            Console.WriteLine(string.Join(", ", array));
            QuickSort(array);
            Console.WriteLine(string.Join(", ", array));

            Console.ReadKey();
        }

        public static void QuickSort(int[] arr)
        {
            QuickSort(arr, 0, arr.Length - 1);
        }

        public static void QuickSort(int[] array, int left, int right)
        {
            var i = left;
            var j = right;

            int pivot = array[(left + right) >> 1];

            while (i <= j)
            {
                while (array[i] < pivot)
                {
                    i++;
                }

                while (array[j] > pivot)
                {
                    j--;
                }

                if (i <= j)
                {
                    var tmp = array[i];
                    array[i] = array[j];
                    array[j] = tmp;

                    i++;
                    j--;
                }
            }

            if (left < j)
            {
                QuickSort(array, left, j);
            }

            if (i < right)
            {
                QuickSort(array, i, right);
            }
        }
    }
}
