using Xunit;

namespace Algo.Tests.leetcode
{
    public class DiStringMatch
    {
        [Theory]
        [InlineData("IDID", new[] { 0, 4, 1, 3, 2 })]
        [InlineData("III", new[] { 0, 1, 2, 3 })]
        [InlineData("DDI", new[] { 3, 2, 0, 1 })]
        public void Test(string str, int[] expected)
        {
            var s = new Solution();
            var actual = s.DiStringMatch(str);
            Assert.Equal(expected, actual);
        }

        public class Solution
        {
            public int[] DiStringMatch(string s)
            {
                var res = new int[s.Length + 1];
                var left = 0;
                var right = s.Length;
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] == 'I')
                        res[i] = left++;

                    if (s[i] == 'D')
                        res[i] = right--;
                }

                res[s.Length] = left;

                return res;
            }
        }
    }
}
