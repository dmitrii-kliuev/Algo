using System;
using System.Collections.Generic;
using Xunit;

namespace Algo.Tests.leetcode
{
    public class SquaresOfASortedArray
    {
        [Theory]
        [InlineData(new[] { -4, -1, 0, 3, 10 }, new[] { 0, 1, 9, 16, 100 })]
        [InlineData(new[] { -7, -3, 2, 3, 11 }, new[] { 4, 9, 9, 49, 121 })]
        public void Test(int[] arr, int[] expected)
        {
            var s = new SolutionOn();
            var actual = s.SortedSquares(arr);
            Assert.Equal(expected, actual);
        }

        public class Solution
        {
            public int[] SortedSquares(int[] a)
            {
                var list = new List<int>();
                for (int i = 0; i < a.Length; i++)
                {
                    list.Add(a[i] * a[i]);
                }

                list.Sort();

                return list.ToArray();
            }
        }

        private class SolutionOn
        {
            public int[] SortedSquares(int[] a)
            {
                int n = a.Length;
                int[] result = new int[n];
                int i = 0, j = n - 1;
                for (int p = n - 1; p >= 0; p--)
                {
                    if (Math.Abs(a[i]) > Math.Abs(a[j]))
                    {
                        result[p] = a[i] * a[i];
                        i++;
                    }
                    else
                    {
                        result[p] = a[j] * a[j];
                        j--;
                    }
                }
                return result;
            }
        }
    }
}
