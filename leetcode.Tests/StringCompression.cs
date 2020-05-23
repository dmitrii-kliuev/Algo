using System;
using System.Diagnostics;
using System.Text;
using Xunit;

namespace Algo.Tests
{
    public class StringCompression
    {
        /*String Compression: Implement a method to perform basic string compression using the counts
        of repeated characters. For example, the string aabcccccaaa would become a2b1c5a3. If the
        "compressed" string would not become smaller than the original string, your method should return
        the original string. You can assume the string has only uppercase and lowercase letters (a - z).*/

        [Theory]
        [InlineData("aabcccccaaa", "a2b1c5a3")]
        [InlineData("ddffhhhhhnmn", "d2f2h5n1m1n1")]
        [InlineData("abc", "abc")]
        [InlineData("", "")]
        public void Test(string str, string expected)
        {
            var actual = Solution.Start(str);
            Assert.Equal(expected, actual);
        }

        public static class Solution
        {
            public static string Start(string str)
            {
                if (string.IsNullOrEmpty(str)) return str;

                var compressed = new StringBuilder();
                char currentChar = str[0];
                int counter = 0;

                foreach (var ch in str)
                {
                    if (ch != currentChar) // save result and clear counter
                    {
                        compressed.Append($"{currentChar}{counter}");

                        currentChar = ch;

                        counter = 0;
                    }
                    counter++;
                }

                compressed.Append($"{currentChar}{counter}");

                if (compressed.Length > str.Length)
                    return str;

                return compressed.ToString();
            }
        }

    }

    public class Sbtest
    {
        [Fact]
        public void Test()
        {
            var max = 10000;
            {
                Stopwatch sw = Stopwatch.StartNew();
                string msg = "";
                for (int i = 0; i < max; i++)
                {
                    msg += "Your total is ";
                    msg += "$500 ";
                    msg += DateTime.Now;
                }
                sw.Stop();
                Debug.WriteLine($"{sw.ElapsedMilliseconds}. len {msg.Length}");
            }

            {
                Stopwatch sw = Stopwatch.StartNew();
                StringBuilder msgSb = new StringBuilder();
                for (int j = 0; j < max; j++)
                {
                    msgSb.Append("Your total is ");
                    msgSb.Append("$500 ");
                    msgSb.Append(DateTime.Now);
                }
                sw.Stop();
                Debug.WriteLine($"{sw.ElapsedMilliseconds}. len {msgSb.ToString().Length}");
            }
        }
    }
}
