using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Algo.Tests.leetcode
{
    public class FindCommonCharacters
    {
        [Theory]
        [InlineData(new[] { "bella", "label", "roller" }, new[] { "e", "l", "l" })]
        [InlineData(new[] { "cool", "lock", "cook" }, new[] { "c", "o" })]
        public void Test(string[] a, string[] expected)
        {
            var s = new Solution();

            var actual = s.CommonChars(a);

            Assert.Equal(expected, actual);
        }

        public class Solution
        {
            public IList<string> CommonChars(string[] a)
            {
                var res = new List<string>();
                if (a.Length == 0) return res;

                var word = a[0];
                foreach (var ch in word)
                {
                    var couner = (from c in a[0] where c == ch select c).Count();
                    for (int i = 1; i < a.Length; i++)
                    {
                        var qty = (from c in a[i] where c == ch select c).Count();
                        if (qty < couner) couner = qty;

                    }

                    if (!res.Contains(ch.ToString()))
                    {
                        for (int i = 0; i < couner; i++)
                        {
                            res.Add(ch.ToString());
                        }
                    }
                }

                return res;
            }
        }
    }
}
