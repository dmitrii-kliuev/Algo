using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace leetcode.Tests.leetcode
{
    public class FactorialRecursiveTest
    {
        [Theory]
        [InlineData(4, 24)]
        public void Test(int num, int expected)
        {
            var s = new Solution();
            var actual = s.Factorial(num);
            Assert.Equal(expected, actual);

            var actual2 = s.Fact(4);
            Assert.Equal(expected, actual2);

            Assert.Equal(0, s.Fact(0));
        }

        public class Solution
        {
            public int Fact(int x) => 
                x == 0 ? 0 : 
                x == 1 ? 1 : 
                x * Fact(x - 1);
                

            public int Factorial(int x)
            {
                if (x == 1) return x;

                var res = Factorial(x - 1) * x;

                return res;
            }
        }
    }
}
