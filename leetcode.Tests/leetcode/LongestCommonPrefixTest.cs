using System;
using System.Collections.Generic;
using Xunit;

namespace Algo.Tests.leetcode
{
    public class LongestCommonPrefixTest
    {
        [Fact]
        public void Test()
        {
            var arr = new[] { "flower", "flow", "flight" };
            var expected = "fl";

            var s = new Solution();
            var actual = s.LongestCommonPrefix(arr);

            Assert.Equal(expected, actual);
        }

        public class Solution
        {
            public string LongestCommonPrefix(string[] strs)
            {
                if (strs.Length == 0) return "";
                var minLength = strs[0].Length;

                foreach (var str in strs)
                {
                    var currentLength = str.Length;
                    if (currentLength < minLength)
                        minLength = currentLength;
                }

                var buff = new char[minLength];
                bool b = false;
                var counter = 0;
                for (int i = 0; i < minLength; i++)
                {
                    foreach (var str in strs)
                    {
                        if (buff[i] == 0)
                            buff[i] = str[i];
                        else
                        {
                            if (buff[i] != str[i])
                            {
                                b = true;
                                break;
                            }
                        }
                    }

                    if (b) break;

                    counter++;
                }

                var resArr = new char[counter];
                Array.Copy(buff, resArr, counter);
                var res = new string(resArr);
                return res;
            }
        }

        public class Solution2 /*one of the best solution from leetcode*/
        {
            public string LongestCommonPrefix(string[] strs)
            {
                if (strs.Length == 0 || string.IsNullOrWhiteSpace(strs[0]))
                    return "";

                List<char> firstWord = new List<char>();

                foreach (var c in strs[0])
                {
                    firstWord.Add(c);
                }


                int highestPrefix = firstWord.Count;

                for (int i = 1; i < strs.Length; i++)
                {
                    int charCount = 0;
                    string word = strs[i];

                    for (int j = 0; j < word.Length; j++)
                    {
                        if (j < firstWord.Count)
                        {
                            if (firstWord[j].Equals(word[j]))
                                charCount++;
                            else
                                break;
                        }
                        else
                            break;
                    }

                    if (charCount == 0)
                        return "";
                    if (charCount < highestPrefix)
                        highestPrefix = charCount;
                }

                return strs[0].Substring(0, highestPrefix);

            }
        }
    }
}
