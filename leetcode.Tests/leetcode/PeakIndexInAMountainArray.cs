using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Xunit;

namespace leetcode.Tests.leetcode
{
    public class PeakIndexInAMountainArray
    {
        [Theory]
        [InlineData(new[] { 0, 1, 0 }, 1)]
        [InlineData(new[] { 0, 2, 1, 0 }, 1)]
        public void Test(int[] arr, int expected)
        {
            var s = new Solution();
            var actual = s.PeakIndexInMountainArray(arr);
            Assert.Equal(expected, actual);
        }

        public class Solution
        {
            public int PeakIndexInMountainArray(int[] A)
            {
                var res = 0;
                if (A.Length < 3) return res;

                var prev = A[0];
                for (int i = 1; i < A.Length; i++)
                {
                    if (prev < A[i])
                    {
                        res = i;
                    }
                    else if (res != 0 && prev < A[i])
                    {
                        return 0;
                    }

                    prev = A[i];
                }

                return res;
            }
        }
    }
}
