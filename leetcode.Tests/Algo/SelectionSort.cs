using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32.SafeHandles;
using Xunit;

namespace leetcode.Tests.Algo
{
    public class SelectionSort
    {
        [Theory]
        [InlineData(new[] { 5, 3, 6, 2, 10 }, new[] { 2, 3, 5, 6, 10 })]
        //[InlineData(new[] { 5, 3, 6, 2, 10 }, new[] { 10, 6, 5, 3, 2})]
        public void Test(int[] input, int[] expected)
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

                
                for (int i = 0; i < arr.Length; i++)
                {
                    int min = arr[i];
                    int minIdx = i;
                    for (int j = i; j < arr.Length; j++)
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
