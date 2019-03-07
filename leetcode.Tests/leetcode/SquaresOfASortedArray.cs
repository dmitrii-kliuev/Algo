using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace leetcode.Tests.leetcode
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
            public int[] SortedSquares(int[] A)
            {
                var list = new List<int>();
                for (int i = 0; i < A.Length; i++)
                {
                    list.Add(A[i] * A[i]);
                }

                list.Sort();

                return list.ToArray();
            }
        }
        
        class SolutionOn
        {
            public int[] SortedSquares(int[] A)
            {
                int n = A.Length;
                int[] result = new int[n];
                int i = 0, j = n - 1;
                for (int p = n - 1; p >= 0; p--)
                {
                    if (Math.Abs(A[i]) > Math.Abs(A[j]))
                    {
                        result[p] = A[i] * A[i];
                        i++;
                    }
                    else
                    {
                        result[p] = A[j] * A[j];
                        j--;
                    }
                }
                return result;
            }
        }
    }
}
