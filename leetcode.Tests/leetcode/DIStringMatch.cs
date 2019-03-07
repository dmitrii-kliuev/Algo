using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace leetcode.Tests.leetcode
{
    public class DIStringMatch
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
            public int[] DiStringMatch(string S)
            {
                var res = new int[S.Length + 1];
                var left = 0;
                var right = S.Length;
                for (int i = 0; i < S.Length; i++)
                {
                    if (S[i] == 'I')
                        res[i] = left++;

                    if (S[i] == 'D')
                        res[i] = right--;
                }

                res[S.Length] = left;

                return res;
            }
        }
    }
}
