using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace leetcode.Tests.Algo
{
    public class Fibonacci
    {
        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        [InlineData(3, 3)]
        [InlineData(4, 5)]
        [InlineData(5, 8)]
        [InlineData(6, 13)]
        [InlineData(7, 21)]
        [InlineData(8, 34)]
        [InlineData(9, 55)]
        [InlineData(10, 89)]
        [InlineData(11, 144)]
        [InlineData(12, 233)]
        [InlineData(13, 377)]
        [InlineData(14, 610)]
        [InlineData(15, 987)]
        [InlineData(16, 1597)]
        [InlineData(17, 2584)]
        [InlineData(18, 4181)]
        [InlineData(19, 6765)]
        [InlineData(20, 10946)]
        [InlineData(21, 17711)]
        public void Test(int num, int expected)
        {
            var s = new Solution();
            var actual = s.Fib(num);
            Assert.Equal(expected, actual);
        }

        public class Solution
        {
            public int Fib(int n)
            {
                if (n < 0) throw new Exception("Only positive allowed");
                if (n == 0) return 0;
                if (n == 1) return 1;

                var f = new int[n + 1];
                f[0] = 1;
                f[1] = 1;
                for (int i = 2; i <= n; i++)
                {
                    f[i] = f[i - 2] + f[i - 1];
                }

                return f[n];
            }
        }
    }
}
