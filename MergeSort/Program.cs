using System;

namespace MergeSort
{
    internal class Program
    {
        private static void Main()
        {
            //MergeTest();

            var arr = new[] { 3, 1, 6, 7, 2, 4, 8, 9, 5, 10, 11 };
            MergeSort(arr);
        }

        private static void MergeSort(int[] arr)
        {
            if (arr.Length <= 1)
                return;

            var leftSize = arr.Length / 2;
            var rightSize = arr.Length - leftSize;

            var left = new int[leftSize];
            var right = new int[rightSize];

            Array.Copy(arr, 0, left, 0, leftSize);
            Array.Copy(arr, leftSize, right, 0, rightSize);

            MergeSort(left);
            MergeSort(right);

            Merge(arr, left, right);
        }

        private static void Merge(int[] items, int[] left, int[] right)
        {
            var leftIndex = 0;
            var rightIndex = 0;
            var targetIndex = 0;
            var remain = left.Length + right.Length;
            while (remain > 0)
            {
                if (leftIndex >= left.Length)
                {
                    items[targetIndex] = right[rightIndex++];
                }
                else if (rightIndex >= right.Length)
                {
                    items[targetIndex] = left[leftIndex++];
                }
                else if (left[leftIndex] < right[rightIndex])
                {
                    items[targetIndex] = left[leftIndex++];
                }
                else
                {
                    items[targetIndex] = right[rightIndex++];
                }

                targetIndex++;
                remain--;
            }
        }

        public static void MergeTest()
        {
            //var left = new[] {1, 3, 6, 7};
            //var right = new[] {2, 4, 8, 9, 10};

            var left = new[] { 1, 3, 6, 7, 11 };
            var right = new[] { 2, 4, 8, 9, 10 };
            var items = new int[left.Length + right.Length];

            Merge(items, left, right);
        }
    }
}
