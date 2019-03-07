using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace leetcode.Tests.leetcode
{
    public class ClimbingStairs
    {
        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        [InlineData(3, 3)]
        [InlineData(4, 5)]
        [InlineData(5, 8)]
        [InlineData(6, 13)]
        [InlineData(7, 21)]
        public void Test(int steps, int expected)
        {
            var s = new Solution();
            var actual = s.ClimbStairs(steps);
            Assert.Equal(expected, actual);
        }

        public class Solution
        {
            public int ClimbStairs(int n)
            {
                var res = 0;
                var prev = 0;
                for (int i = 0; i < n; i++)
                {
                    res = i + prev;
                    prev = i;
                }
                
                return res;
            }
        }
    }
}
