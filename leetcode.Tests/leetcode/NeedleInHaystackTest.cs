using Xunit;

namespace Algo.Tests.leetcode
{
    public class NeedleInHaystackTest
    {
        [Theory]
        [InlineData("hello", "ll", 2)]
        [InlineData("heol", "ll", -1)]
        [InlineData("", "ll", -1)]
        [InlineData("aaaaa", "bba", -1)]
        public void NeedleInHaystack(string haystack, string needle, int expected)
        {
            var s = new Solution();
            var actual = s.StrStr(haystack, needle);
            Assert.Equal(expected, actual);
        }

        public class Solution
        {
            public int StrStr(string haystack, string needle)
            {
                var res = -1;

                for (int i = 0; i < haystack.Length + 1 - needle.Length; i++)
                {
                    var part = haystack.Substring(i, needle.Length);
                    if (part == needle)
                        return i;
                }

                return res;
            }
        }
    }
}
