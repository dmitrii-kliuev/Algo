using Xunit;

namespace Algo.Tests.leetcode
{
    public class LengthOfLastWord
    {
        [Theory]
        [InlineData("qqq www", 3)]
        [InlineData("qqqwww", 6)]
        [InlineData("a", 1)]
        [InlineData("a ", 1)]
        public void Test(string text, int expected)
        {
            var s = new Solution();
            var actual = s.LengthOfLastWord(text);
            Assert.Equal(expected, actual);
        }

        public class Solution
        {
            public int LengthOfLastWord(string s)
            {
                var counter = 0;
                var isWord = false;
                for (int i = s.Length - 1; i >= 0; i--)
                {
                    if (!isWord && s[i] != ' ')
                    {
                        isWord = true;
                    }

                    if (isWord)
                    {
                        if (s[i] != ' ')
                            counter++;
                        else
                            break;
                    }
                }

                return counter;
            }
        }
    }
}
