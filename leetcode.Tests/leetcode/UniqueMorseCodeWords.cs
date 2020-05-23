using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Algo.Tests.leetcode
{
    public class UniqueMorseCodeWords
    {
        [Theory]
        [InlineData(new[] { "gin", "zen", "gig", "msg" }, 2)]
        public void Test(string[] arr, int expected)
        {
            var s = new Solution();
            var actual = s.UniqueMorseRepresentations(arr);
            Assert.Equal(expected, actual);
        }

        private class Solution
        {
            private readonly string[] _morse =
            {
                ".-", "-...", "-.-.", "-..", ".",
                "..-.", "--.", "....", "..", ".---",
                "-.-", ".-..", "--", "-.", "---",
                ".--.", "--.-", ".-.", "...", "-",
                "..-", "...-", ".--", "-..-", "-.--", "--.."
            };

            public int UniqueMorseRepresentations(string[] words)
            {
                var hs = new HashSet<string>();
                var distance = 'a';
                foreach (var word in words)
                {
                    var sb = new StringBuilder();
                    foreach (var ch in word)
                    {
                        var i = ch - distance;
                        sb.Append(_morse[i]);
                    }

                    hs.Add(sb.ToString());
                }

                return hs.Count;
            }
        }
    }
}
