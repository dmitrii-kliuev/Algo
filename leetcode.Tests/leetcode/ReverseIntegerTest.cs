using System;
using System.Diagnostics;
using Xunit;

namespace Algo.Tests.leetcode
{
    public class ReverseIntegerTest
    {
        [Theory]
        [InlineData(123, 321)]
        [InlineData(-123, -321)]
        [InlineData(1534236469, 0)]
        public void Test(int num, int expected)
        {
            var s = new Solution();
            var res = s.Reverse(num);
            Assert.Equal(expected, res);

        }

        public class Solution
        {
            public int Reverse(int x)
            {
                var res = 0;

                try
                {
                    checked
                    {
                        while (true)
                        {
                            res += (x % 10);

                            x /= 10;
                            if (x == 0) break;

                            res *= 10;
                        }
                    }
                }
                catch (OverflowException e)
                {
                    Debug.WriteLine(e);
                    return 0;
                }

                return res;
            }
        }
    }
}
