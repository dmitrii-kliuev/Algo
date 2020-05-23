using Xunit;

namespace Algo.Tests.leetcode
{
    public class ToLowerCase
    {
        [Theory]
        [InlineData("Hello", "hello")]
        [InlineData("here", "here")]
        [InlineData("LOVELY", "lovely")]
        public void Test(string str, string expected)
        {
            var s = new Solution();
            var actual = s.ToLowerCase(str);
            Assert.Equal(expected, actual);
        }

        public class Solution
        {
            public string ToLowerCase(string str)
            {
                char[] chars = new char[str.Length];
                var distance = 'a' - 'A';
                for (int i = 0; i < str.Length; i++)
                {

                    if (str[i] >= 'A' && str[i] <= 'Z')
                    {
                        chars[i] = (char)(str[i] + distance);
                    }
                    else
                        chars[i] = str[i];
                }

                return new string(chars);
            }
        }
    }
}
