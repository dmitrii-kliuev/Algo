using Xunit;

namespace Algo.Tests.Algo
{
    public class IsSubstringTest
    {
        [Theory]
        [InlineData("hello", "ell", true)]
        [InlineData("hello", "eql", false)]
        [InlineData("hello", "o", true)]
        [InlineData("hello", "h", true)]
        public void Test(string str, string subStr, bool expected)
        {
            var actual = Solution.IsSubstring(str, subStr);
            Assert.Equal(expected, actual);
        }

        private static class Solution
        {
            public static bool IsSubstring(string str, string subStr)
            {
                var tmp = "";

                foreach (var s in str)
                {
                    tmp += s;
                    if (tmp.Length == subStr.Length)
                    {
                        if (tmp == subStr)
                            return true;

                        tmp = RemoveFirstLetter(tmp);
                    }
                }

                return false;
            }

            private static string RemoveFirstLetter(string tmp)
            {
                var t = "";
                for (int i = 1; i < tmp.Length; i++)
                    t += tmp[i];

                return t;
            }
        }
    }
}
