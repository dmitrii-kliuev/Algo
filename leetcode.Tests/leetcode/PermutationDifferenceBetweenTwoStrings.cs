using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Algo.Tests.leetcode
{
    public class PermutationDifferenceBetweenTwoStrings
    {
        [Theory]
        [InlineData("abc", "bac", 2)]
        public void Test(string s, string t, int expected)
        {
            var result = FindPermutationDifferenceV2(s, t);
            Assert.Equal(expected, result);
        }

        public int FindPermutationDifference(string s, string t)
        {
            var sum = 0;

            for (int i = 0; i < s.Length; i++)
            {
                sum += Math.Abs(i - t.IndexOf(s[i], StringComparison.CurrentCulture));
            }

            return sum;
        }

        public int FindPermutationDifferenceV2(string s, string t)
        {
            var sum = 0;
            var sMap = new Dictionary<char, byte>();
            for (byte i = 0; i < s.Length; i++)
            {
                sMap[s[i]] = i;
            }

            for (int i = 0; i < t.Length; i++)
            {
                sum += Math.Abs(sMap[t[i]] - i);
            }

            return sum;
        }
    }
}
