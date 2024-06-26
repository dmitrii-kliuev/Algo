﻿using Xunit;

namespace Algo.Tests.Algo
{
    public class SelectionSort
    {
        [Theory]
        [InlineData(new[] { 5, 3, 6, 2, 10 }, new[] { 2, 3, 5, 6, 10 })]
        [InlineData(new[] { 5, 3, 6, 2, 10, 1 }, new[] { 1, 2, 3, 5, 6, 10 })]
        [InlineData(new[] { 5, 3, 6, 4, 2, 10, 1, 9 }, new[] { 1, 2, 3, 4, 5, 6, 9, 10 })]
        public void SelectionSortTest(int[] input, int[] expected)
        {
            var s = new Solution();
            var res = s.Sort(input);
            Assert.Equal(expected, res);
        }

        public class Solution
        {
            public int[] Sort(int[] arr)
            {
                if (arr.Length == 0) return arr;

                for (int i = 0; i < arr.Length - 1; i++)
                {
                    int min = arr[i];
                    int minIdx = i;
                    for (int j = i + 1; j < arr.Length; j++)
                    {
                        if (arr[j] < min)
                        {
                            min = arr[j];
                            minIdx = j;
                        }
                    }

                    Swap(arr, i, minIdx);
                }

                return arr;
            }

            private void Swap(int[] arr, int i, int minIdx)
            {
                var tmp = arr[i];
                arr[i] = arr[minIdx];
                arr[minIdx] = tmp;
            }
        }
    }
}
