using Xunit;

namespace Algo.Tests.leetcode
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
            public int NumJewelsInStones(string j, string s)
            {
                var qty = 0;

                foreach (var stone in s)
                {
                    foreach (var jewel in j)
                    {
                        if (stone == jewel)
                            qty++;
                    }
                }

                return qty;
            }
        }
    }
}
