using Xunit;

namespace leetcode.Tests.Algo
{
    public class OneTimeCharsInStr
    {
        [Theory]
        [InlineData("qweasd", true)]
        [InlineData("qwdeasd", false)]
        [InlineData("aa", false)]
        [InlineData("a", true)]
        public void Test(string str, bool expected)
        {
            var actual = Solution.IsOnlyOnce(str);
            Assert.Equal(expected, actual);
        }

        static class Solution
        {
            public static bool IsOnlyOnce(string str)
            {
                for (int i = 0; i < str.Length; i++)
                {
                    for (int j = 0; j < str.Length; j++)
                    {
                        if (i != j && str[i] == str[j])
                            return false;
                    }
                }

                return true;
            }
        }

    }
}
