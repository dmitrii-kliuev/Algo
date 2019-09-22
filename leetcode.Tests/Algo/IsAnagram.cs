using System.Collections.Generic;
using Xunit;

namespace leetcode.Tests.Algo
{
    public class IsAnagram
    {
        [Theory]
        [InlineData("CAT", "ACT", true)]
        [InlineData("CAT", "ACTT", false)]
        [InlineData("CAAAAT", "ACAAAT", true)]
        [InlineData("CAAAAT", "ACAABT", false)]
        public void Test(string first, string second, bool expected)
        {
            var actual = Solution.Start(first, second);
            Assert.Equal(expected, actual);
        }

        static class Solution
        {
            internal static bool Start(string first, string second)
            {
                if (first.Length != second.Length) return false;

                var dict = new Dictionary<char, int>();
                foreach (var ch in first)
                {
                    if (!dict.ContainsKey(ch))
                    {
                        dict.Add(ch, 1);
                    }
                    else if (dict.ContainsKey(ch))
                    {
                        dict[ch]++;
                    }
                }

                foreach (var ch in second)
                {
                    if (dict.ContainsKey(ch))
                    {
                        if (dict[ch] != 1)
                            dict[ch]--;
                        else
                            dict.Remove(ch);
                    }
                }

                return dict.Count == 0;
            }
        }
    }
}
