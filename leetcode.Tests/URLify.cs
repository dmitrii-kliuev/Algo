using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace leetcode.Tests
{
    public class URLify
    {
        /*URLify: Write a method to replace all spaces in a string with '%20: You may assume that the string
has sufficient space at the end to hold the additional characters, and that you are given the "true"
length of the string. (Note: If implementing in Java, please use a character array so that you can
perform this operation in place.)
EXAMPLE
Input: "Mr John Smith " 13
Output: "Mr%20John%20Smith"*/

        [Theory]
        [InlineData("Mr John Smith", "Mr%20John%20Smith")]
        [InlineData("Mr John Smith   ", "Mr%20John%20Smith")]
        public void Test(string str, string expected)
        {
            var actual = Solution.Start(str);
            Assert.Equal(expected, actual);
        }

        public static class Solution
        {
            public static string Start(string str)
            {
                if (string.IsNullOrEmpty(str)) return "";

                var sb = new StringBuilder();

                var tail = true;
                for (int i = str.Length - 1; i >= 0; i--)
                {
                    if (tail && str[i] == ' ') continue;
                    else
                    {
                        tail = false;

                        if (str[i] == ' ')
                            sb.Append("02%");
                        else
                            sb.Append(str[i]);
                    }
                }

                return new string(sb.ToString().Reverse().ToArray());
            }
        }


        [Theory]
        [InlineData("Mr John Smith", "Mr%20John%20Smith")]
        [InlineData("Mr John Smith   ", "Mr%20John%20Smith")]
        public void Test1(string str, string expected)
        {
            var actual = Solution1.Start(str);
            Assert.Equal(expected, actual);
        }
        public static class Solution1
        {
            public static string Start(string str)
            {
                if (string.IsNullOrEmpty(str)) return "";

                // remove trailing spaces
                var trailingSpacesQty = 0;
                for (int i = str.Length - 1; i >= 0; i--)
                {
                    if (str[i] == ' ') 
                        trailingSpacesQty++;
                    else
                        break;
                }

                var newLength = str.Length - trailingSpacesQty;
                var spaceQty = 0;
                for (int i = 0; i < newLength; i++)
                {
                    if (str[i] == ' ')
                        spaceQty++;
                }
                
                var arr = new char[newLength + (spaceQty * 2)];

                var strPointer = 0;
                for (int i = 0; i < arr.Length; i++)
                {
                    if (str[strPointer] == ' ')
                    {
                        arr[i] = '%';
                        arr[++i] = '2';
                        arr[++i] = '0';
                        strPointer++;
                    }
                    else
                    {
                        arr[i] = str[strPointer];
                        strPointer++;
                    }
                }

                return new string(arr);
            }
        }
    }
}
