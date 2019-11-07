using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace leetcode.Tests
{
    public class IsSubstring
    {
        /*  String Rotation: Assume you have a method isSubst ring which checks if one word is a substring
            of another. Given two strings, 51 and 52, write code to check if 52 is a rotation of 51 using only one
            call to isSubstring (e . g. , "waterbottle " is a rotation of " erbottlewat").*/
        [Theory]
        [InlineData("waterbottle", "erbottlewat", true)]
        public void Test(string str, string shifted, bool expected)
        {
            var actual = Solution.Start(str, shifted);
            Assert.Equal(expected, actual);
        }

        public static class Solution
        {
            public static bool Start(string str, string shifted)
            {
                return (str + str).Contains(shifted);
            }
        }
    }
}
