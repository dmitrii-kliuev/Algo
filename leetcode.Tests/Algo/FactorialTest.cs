using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace leetcode.Tests.Algo
{
    public class FactorialTest
    {
        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        [InlineData(3, 6)]
        [InlineData(4, 24)]
        public void Test(int num, int expected)
        {
            var s = new Solution();
            var res = s.FactTest();

            var actual = s.Fact(num);
            Assert.Equal(expected, actual);
        }

        public class Solution
        {
            public int Fact(int num)
            {
                if (num == 0) return 0;
                if (num == 1) return 1;

                var f = Fact(num - 1);

                return num * f;
            }

            public int FactTest()
            {
                var res = Fact4(4);
                return res;
            }

            public int Fact4(int n)
            {
                return 4 * Fact3();
            }
            
            public int Fact3()
            {
                return 3 * Fact2();
            }
            
            public int Fact2()
            {
                return 2 * Fact1();
            }

            public int Fact1()
            {
                return 1;
            }

        }
    }
}
