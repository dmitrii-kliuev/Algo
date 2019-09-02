using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace leetcode.Tests
{
    public class DominatorInAnArrayOfIntegers
    {
        /*a function that finds a value that occurs in more than half of the elements of an array.*/
        [Theory]
        [InlineData(new int[] { 0, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 3, 3, 3, 4, 5 }, -1)]
        [InlineData(new int[] { 1, 1, 2 }, 1)]
        [InlineData(new int[] { 1, 2, 2 }, 2)]
        [InlineData(new int[] { 1, 1, 2, 2 }, -1)]
        [InlineData(new int[] { 1, 1, 2, 2, 2 }, 2)]
        [InlineData(new int[] { 1 }, 1)]
        [InlineData(new int[] { 1, 1 }, 1)]
        [InlineData(new int[] { 1, 2 }, -1)]
        [InlineData(new int[] { }, -1)]
        public void Test(int[] arr, int expected)
        {
            var s = new Solution();
            var actual = s.solution(arr);
            Assert.Equal(expected, actual);
        }

        class Solution
        {
            public int solution(int[] A)
            {
                int n = A.Length;
                int[] L = new int[n + 1];
                L[0] = -1;
                for (int i = 0; i < n; i++)
                {
                    L[i + 1] = A[i];
                }
                int count = 0;
                int pos = (n + 1) / 2;
                int candidate = L[pos];
                for (int i = 1; i <= n; i++)
                {
                    if (L[i] == candidate)
                        count = count + 1;
                }
                if (2 * count > n)
                    return candidate;
                return -1;
            }
        }
    }
}
