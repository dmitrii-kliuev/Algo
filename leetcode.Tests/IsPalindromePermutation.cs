using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace leetcode.Tests
{
    public class IsPalindromePermutation
    {
        /*
            Palindrome Permutation: Given a string, write a function to check if it is a permutation of a palindrome.
            A palindrome is a word or phrase that is the same forwards and backwards. A permutation
            is a rearrangement of letters. The palindrome does not need to be limited to just dictionary words.
            EXAMPLE
            Input: Tact Coa
            Output: True (permutations: "taco cat". "atco cta". etc.)
         */
        [Theory]
        [InlineData("qwqw", true)]
        [InlineData("qwqwh", true)]
        [InlineData("qqaazz", true)]
        [InlineData("qqwweerg", false)]
        [InlineData("a", true)]
        [InlineData("ff", true)]
        [InlineData("qqwweergg", true)]
        [InlineData("Tact Coa", true)]
        public void Test(string str, bool expected)
        {
            var actual = Solution.CheckIsPalindromePermutation(str.ToLower());
            Assert.Equal(expected, actual);
        }

        public static class Solution
        {
            public static bool CheckIsPalindromePermutation(string str)
            {
                var arr = new char[127];
                foreach (var ch in str)
                {
                    if (ch != ' ') arr[ch]++;
                }

                var oddQuantity = 0;
                foreach (var item in arr)
                {
                    if (item != 0 && item % 2 != 0)
                        oddQuantity++;
                }

                return oddQuantity == 0 || oddQuantity == 1;
            }
        }
    }
}
