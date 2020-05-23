using Xunit;

namespace Algo.Tests.leetcode
{
    public class CountAndSayTest
    {
        [Theory]
        [InlineData(1, "1")]
        [InlineData(2, "11")]
        [InlineData(3, "21")]
        [InlineData(4, "1211")]
        [InlineData(5, "111221")]
        public void Test(int n, string expected)
        {
            var s = new Solution();
            //var test = s.Next("111221");

            var actual = s.CountAndSay(n);
            Assert.Equal(expected, actual);
        }


        public class Solution
        {
            public string CountAndSay(int n)
            {
                var buff = "1";
                if (n == 1) return buff;

                for (int i = 0; i < n - 1; i++)
                {
                    buff = Next(buff);
                }

                return buff;
            }

            public string Next(string input)
            {
                var currentChar = "";
                var counter = 0;
                var res = "";
                foreach (var c in input)
                {
                    if (currentChar == "")
                    {
                        currentChar = c.ToString();
                        counter++;
                    }
                    else if (currentChar == c.ToString())
                    {
                        counter++;
                    }
                    else
                    {
                        res += counter + currentChar;

                        counter = 1;
                        currentChar = c.ToString();
                    }

                }

                res += counter + currentChar;

                return res;
            }
        }
    }
}
