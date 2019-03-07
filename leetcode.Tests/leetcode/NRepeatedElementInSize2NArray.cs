using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xunit;

namespace leetcode.Tests.leetcode
{
    public class NRepeatedElementInSize2NArray
    {
        [Theory]
        [InlineData(new[] { 1, 2, 3, 3 }, 3)]
        [InlineData(new[] { 2, 1, 2, 5, 3, 2 }, 2)]
        [InlineData(new[] { 5, 1, 5, 2, 5, 3, 5, 4 }, 5)]
        public void Test(int[] arr, int expected)
        {
            int k = 1;
            var test = (k++ + ++k); // 4

            var s = new Solution();
            var actual = s.RepeatedNTimes(arr);
            Assert.Equal(expected, actual);
        }

        public class Solution
        {
            public int RepeatedNTimes(int[] A)
            {
                var tmp = new int[10000];
                var res = 0;
                for (int i = 0; i < A.Length; i++)
                {
                    if (tmp[A[i]] == 0)
                        tmp[A[i]] = 1;
                    else
                    {
                        return A[i];
                    }
                }


                return res;
            }
        }

        public class SolutionWithHashSet
        {
            public int RepeatedNTimes(int[] A)
            {
                var hs = new HashSet<int>();
                var res = 0;
                for (int i = 0; i < A.Length; i++)
                {
                    if (!hs.Add(A[i])) return A[i];
                }

                return res;
            }
        }
    }
}
