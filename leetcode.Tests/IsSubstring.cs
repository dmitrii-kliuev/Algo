using Xunit;

namespace Algo.Tests
{
    public class IsSubstring
    {
        /*  String Rotation: Assume you have a method isSubstring which checks if one word is a substring
            of another. Given two strings, s1 and s2, write code to check if s2 is a rotation of s1 using only one
            call to isSubstring (e.g., "waterbottle" is a rotation of "erbottlewat").*/
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
