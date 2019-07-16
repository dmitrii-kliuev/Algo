using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Linq;

namespace leetcode.Tests.leetcode
{
    public class KeyboardRow
    {
        /*
         https://leetcode.com/problems/keyboard-row/
         Given a List of words, return the words that can be typed using letters of alphabet 
         on only one row's of American keyboard like the image below.
          
            Example:

            Input: ["Hello", "Alaska", "Dad", "Peace"]
            Output: ["Alaska", "Dad"]

        */

        [Theory]
        [InlineData(new string[] { "Hello", "Alaska", "Dad", "Peace" }, new string[] { "Alaska", "Dad" })]
        public void Test(string[] input, string[] expected)
        {
            var s = new Solution();
            var actual = s.FindWords(input);
            Assert.Equal(expected, actual);
        }

        public class Solution
        {
            public string[] FindWords(string[] words)
            {
                List<HashSet<char>> keyboard = new List<HashSet<char>>
                {
                    new HashSet<char> { 'q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p' },
                    new HashSet<char> { 'a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l' },
                    new HashSet<char> { 'z', 'x', 'c', 'v', 'b', 'n', 'm' }
                };

                var result = new List<string>();

                foreach (var word in words)
                {
                    foreach (var row in keyboard)
                    {
                        bool rowIsNotContain = false;
                        foreach (var ch in word)
                        {
                            if (!row.Contains(ChToLower(ch)))
                            {
                                rowIsNotContain = true;
                                break;
                            }
                        }

                        if (!rowIsNotContain)
                        {
                            result.Add(word);
                            break;
                        }
                    }
                }

                return result.ToArray();
            }

            private char ChToLower(char ch)
            {
                if (ch >= 65 && ch <= 90)
                    return (char)(ch + 32);
                else return ch;
            }
        }
    }
}
