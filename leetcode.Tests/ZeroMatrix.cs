using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace leetcode.Tests
{
    public class ZeroMatrix
    {
        [Theory]
        [InlineData("", true)]
        public void Test(string str, bool expected)
        {
            var actual = Solution.Start(str);
            Assert.Equal(expected, actual);
        }

        public static class Solution
        {
            public static bool Start(string str)
            {
                return false;
            }
        }

    }
}
