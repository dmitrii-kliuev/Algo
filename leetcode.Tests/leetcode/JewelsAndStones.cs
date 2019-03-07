using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace leetcode.Tests.leetcode
{
    public class JewelsAndStones
    {
        [Theory]
        [InlineData("aA", "aAAbbbb", 3)]
        [InlineData("z", "ZZ", 0)]
        public void Test(string j, string s, int expected)
        {
            var sol = new Solution();
            var actual = sol.NumJewelsInStones(j, s);
            Assert.Equal(expected, actual);
        }

        public class Solution
        {
            public int NumJewelsInStones(string J, string S)
            {
                var qty = 0;

                foreach (var oneS in S)
                {
                    foreach (var oneJ in J)
                    {
                        if (oneS == oneJ)
                            qty++;
                    }
                }

                return qty;
            }
        }
    }
}
