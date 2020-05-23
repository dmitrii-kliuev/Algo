using Xunit;

namespace Algo.Tests
{
    public class OneOrZeroStringCahnge
    {
        /*  One Away: There are three types of edits that can be performed on strings: insert a character,
            remove a character, or replace a character. Given two strings, write a function to check if they are
            one edit (or zero edits) away.*/
        [Theory]
        [InlineData("pale", "ple", true)]       // delete 1
        [InlineData("pales", "pale", true)]     // delete 1
        [InlineData("pales", "pal", false)]     // delete 2
        [InlineData("pale", "bale", true)]      // change 1
        [InlineData("pale", "bake", false)]     // change 2
        [InlineData("pale", "pale", true)]      // equal
        [InlineData("pale", "paled", true)]     // insert 1
        [InlineData("pale", "paleds", false)]   // insert 2
        [InlineData("paleds", "pale", false)]   // delete 2
        [InlineData("", "", true)]              // empty
        public void Test(string str1, string str2, bool expected)
        {
            var actual = Solution.Start(str1, str2);
            Assert.Equal(expected, actual);
        }

        public static class Solution
        {
            public static bool Start(string str1, string str2)
            {
                if (str1.Length == str2.Length)
                {
                    var isEqual = true;
                    for (int i = 0; i < str1.Length; i++)
                    {
                        if (str1[i] != str2[i]) isEqual = false;
                    }

                    if (isEqual)
                        return true;
                }

                var arr = new int[127];

                foreach (var ch in str1) arr[ch]++;
                foreach (var ch in str2) arr[ch]--;

                var greaterThenZero = 0;
                var lessThenZero = 0;

                foreach (var item in arr)
                {
                    if (item > 0) greaterThenZero++;
                    if (item < 0) lessThenZero++;
                }

                if ((greaterThenZero == 0 || greaterThenZero == 1) &&
                    (lessThenZero == 0 || lessThenZero == 1)) return true;

                return false;
            }
        }
    }
}
