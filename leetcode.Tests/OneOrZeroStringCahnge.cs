using Xunit;

namespace leetcode.Tests
{

    public class OneOrZeroStringCahnge
    {
        /*  One Away: There are three types of edits that can be performed on strings: insert a character,
            remove a character, or replace a character. Given two strings, write a function to check if they are
            one edit (or zero edits) away.*/
        [Theory]
        [InlineData("pale", "ple", true)]
        [InlineData("pales", "pale", true)]
        [InlineData("pale", "bale", true)]
        [InlineData("pale", "bake", false)]
        public void Test(string str1, string str2, bool expected)
        {
            var actual = Solution.Start(str1, str2);
            Assert.Equal(expected, actual);
        }

        public static class Solution
        {
            public static bool Start(string str1, string str2)
            {
                return false;
            }
        }
    }
}
