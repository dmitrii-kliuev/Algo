using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace leetcode.Tests.HackerRank
{
    public class RepeatedString
    {
        [Theory]
        [InlineData("abcac", 10, 4)]
        [InlineData("aba", 10, 7)]
        [InlineData("a", 1000000000000, 1000000000000)]
        public void SolutionTest(string input, long n, long expected)
        {
            // arrange
            var s = new Solution();

            // act
            var actual = s.RepeatedString(input, n);

            // assert
            Assert.Equal(expected, actual);
        }

        public class Solution
        {
            public long RepeatedString(string s, long n)
            {
                var aInS = s.ToCharArray().Count(c => c == 'a');
                var entryQty = n / s.Length;

                var tailLength = n - entryQty * s.Length;

                var aInTail = s.Substring(0, (int)tailLength).ToCharArray().Count(c => c == 'a');

                var quantity = entryQty * aInS + aInTail;

                return quantity;
            }
        }
    }
}
