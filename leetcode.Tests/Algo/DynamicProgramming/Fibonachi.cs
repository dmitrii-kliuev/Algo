using System;
using Xunit;

namespace Algo.Tests.Algo.DynamicProgramming
{
    public class Fibonacci
    {
        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(2, 1)]
        [InlineData(3, 2)]
        [InlineData(4, 3)]
        [InlineData(5, 5)]
        [InlineData(6, 8)]
        [InlineData(7, 13)]
        [InlineData(8, 21)]
        [InlineData(9, 34)]
        [InlineData(10, 55)]
        [InlineData(11, 89)]
        [InlineData(12, 144)]
        [InlineData(13, 233)]
        [InlineData(14, 377)]
        [InlineData(15, 610)]
        [InlineData(16, 987)]
        [InlineData(17, 1597)]
        [InlineData(18, 2584)]
        [InlineData(19, 4181)]
        [InlineData(20, 6765)]
        [InlineData(21, 10946)]
        [InlineData(22, 17711)]
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
                if (n == 1 || n == 2) return 1;

                var f = new int[n + 1];
                f[1] = 1;
                f[2] = 1;
                for (int i = 3; i <= n; i++)
                {
                    f[i] = f[i - 2] + f[i - 1];
                }

                return f[n];
            }
        }
    }
}
