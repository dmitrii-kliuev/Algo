using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xunit;

namespace leetcode.Tests.leetcode
{
    public class FibonacciNumber
    {
        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(2, 1)]
        [InlineData(4, 3)]
        [InlineData(5, 5)]
        public void Test(int n, int expected)
        {
            var s = new Solution();
            var actual = s.Fib(n);
            Assert.Equal(expected, actual);
        }

        public class Solution
        {
            public int Fib(int N)
            {
                if (N == 1) return 1;
                var res = 0;
                var prevL = 0;
                var prevR = 1;
                for (int i = 0; i < N - 1; i++)
                {
                    res = prevL + prevR;
                    prevL = prevR;
                    prevR = res;
                }

                return res;
            }
        }

    }
}
