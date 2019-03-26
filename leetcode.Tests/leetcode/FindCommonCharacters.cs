using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace leetcode.Tests.leetcode
{
    public class FindCommonCharacters
    {
        [Theory]
        [InlineData(new string[] { "bella", "label", "roller" }, new string[] { "e", "l", "l" })]
        [InlineData(new string[] { "cool", "lock", "cook" }, new string[] { "c", "o" })]
        public void Test(string[] A, string[] expected)
        {
            var s = new Solution();

            var actual = s.CommonChars(A);

            Assert.Equal(expected, actual);
        }

        public class Solution
        {
            public IList<string> CommonChars(string[] A)
            {
                var res = new List<string>();
                if (A.Length == 0) return res;

                var word = A[0];
                foreach (var ch in word)
                {
                    var couner = (from c in A[0] where c == ch select c).Count();
                    for (int i = 1; i < A.Length; i++)
                    {
                        var qty = (from c in A[i] where c == ch select c).Count();
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
