using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace leetcode.Tests.leetcode
{
    public class SelfDividingNumbers
    {
        [Theory]
        [InlineData(1, 22, new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 11, 12, 15, 22 })]
        public void Test(int left, int right, int[] expected)
        {
            var s = new Solution();
            var actual = s.SelfDividingNumbers(left, right);
            Assert.Equal(actual, expected);
        }

        public class Solution
        {
            public IList<int> SelfDividingNumbers(int left, int right)
            {
                var res = new List<int>();
                for (int i = left; i <= right; i++)
                {
                    var tmp = i;
                    var isSelfDeviding = true;
                    while (tmp > 0)
                    {
                        var d = tmp % 10;
                        if (d == 0 || i % d != 0)
                        {
                            isSelfDeviding = false;
                            break;
                        }

                        tmp /= 10;
                    }

                    if(isSelfDeviding)
                        res.Add(i);
                }

                return res;
            }
        }
    }
}
