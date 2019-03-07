using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace leetcode.Tests.leetcode
{
    public class RomanToIntegerTest
    {
        [Theory]
        [InlineData("III", 3)]
        [InlineData("IV", 4)]
        [InlineData("VIII", 8)]
        [InlineData("IX", 9)]
        [InlineData("LVIII", 58)]
        [InlineData("MCMXCIV", 1994)]
        public void Test(string str, int expected)
        {
            var s = new Solution();
            var actual = s.RomanToInt(str);
            Assert.Equal(expected, actual);
        }

        public class Solution
        {
            public int RomanToInt(string s)
            {
                var arr = s.ToCharArray();
                char prev = (char)0;
                var res = 0;
                foreach (var c in arr)
                {
                    if (c == 'I')
                        res += 1;

                    if (c == 'V' && prev == 'I')
                        res += 3;
                    else if (c == 'V')
                        res += 5;

                    if (c == 'X' && prev == 'I')
                        res += 8;
                    else if (c == 'X')
                        res += 10;

                    if (c == 'L' && prev == 'X')
                        res += 30;
                    else if (c == 'L')
                        res += 50;

                    if (c == 'C' && prev == 'X')
                        res += 80;
                    else if (c == 'C')
                        res += 100;

                    if (c == 'D' && prev == 'C')
                        res += 300;
                    else if (c == 'D')
                        res += 500;

                    if (c == 'M' && prev == 'C')
                        res += 800;
                    else if (c == 'M')
                        res += 1000;

                    prev = c;
                }

                return res;
            }
        }
    }
}
