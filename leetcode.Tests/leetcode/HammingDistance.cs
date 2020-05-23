using System;
using Xunit;

namespace Algo.Tests.leetcode
{
    public class HammingDistance
    {
        [Theory]
        [InlineData(1, 4, 2)]
        public void Test(int x, int y, int expected)
        {
            var s = new Solution();
            var actual = s.HammingDistance(x, y);

            //var xBinary = Convert.ToString(x, 2);
            //var yBinary = Convert.ToString(y, 2);
            Assert.Equal(expected, actual);
        }

        public class Solution
        {
            public int HammingDistance(int x, int y)
            {
                var xLen = Convert.ToString(x, 2).Length;
                var yLen = Convert.ToString(y, 2).Length;
                var maxLength = xLen > yLen ? xLen : yLen;

                var res = 0;
                for (int i = 0; i < maxLength; i++)
                {
                    var currX = (1 & x >> i) != 0;
                    var currY = (1 & y >> i) != 0;
                    if (currX != currY)
                        res++;
                }

                return res;
            }
        }
    }
}
