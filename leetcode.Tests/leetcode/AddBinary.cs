using System;
using System.Diagnostics;
using System.Linq;
using Xunit;

namespace Algo.Tests.leetcode
{
    public class AddBinary
    {
        [Theory]
        [InlineData("11", "1", "100")]
        [InlineData("1010", "1011", "10101")]
        [InlineData("0", "0", "0")]
        [InlineData("1", "1", "10")]
        [InlineData("10", "", "10")]
        [InlineData("1111", "1111", "11110")]
        public void Test(string a, string b, string expected)
        {
            var aBit = 1;
            var bBit = 1;

            var carry = 0;

            // Bitwise exclusive-OR of 0 and 1 returns 1.
            Debug.WriteLine($"Bitwise result: {Convert.ToString(0x0 ^ 0x1, 2)}");
            // Bitwise exclusive-OR of 0 and 0 returns 0.
            Debug.WriteLine($"Bitwise result: {Convert.ToString(0x0 ^ 0x0, 2)}");
            // Bitwise exclusive-OR of 1 and 1 returns 0.
            Debug.WriteLine($"Bitwise result: {Convert.ToString(0x1 ^ 0x1, 2)}");

            carry = aBit & bBit | aBit & carry | bBit & carry;
            carry = aBit & bBit | aBit & carry | bBit & carry;

            aBit = 0;
            bBit = 0;
            carry = aBit & bBit | aBit & carry | bBit & carry;
            Debug.WriteLine(carry);
            var s = new Solution();
            var actual = s.AddBinary(a, b);
            Assert.Equal(expected, actual);
        }

        private class Solution
        {
            public string AddBinary(string a, string b)
            {
                var res = "";
                var aL = a.Length;
                var bL = b.Length;
                var maxLength = aL > bL ? aL : bL;
                a = PadLeft(a, maxLength, '0');
                b = PadLeft(b, maxLength, '0');

                var carry = 0;
                for (int i = maxLength - 1; i >= 0; i--)
                {
                    var aBit = a[i] == '1' ? 1 : 0;
                    var bBit = b[i] == '1' ? 1 : 0;
                    var sum = aBit ^ bBit ^ carry;

                    carry = aBit & bBit | aBit & carry | bBit & carry;
                    res = sum + res;
                }

                if (carry == 1)
                    res = carry + res;

                return res;
            }

            private string PadLeft(string str, int maxLength, char symbol)
            {
                for (int i = str.Length; i < maxLength; i++)
                {
                    str = symbol + str;
                }

                return str;
            }
        }

        public class BigSolution
        {
            public string AddBinary(string a, string b)
            {
                a = new string(a.Reverse().ToArray());
                b = new string(b.Reverse().ToArray());

                var aL = a.Length;
                var bL = b.Length;
                var maxLength = aL > bL ? aL : bL;
                var oneInMind = 0;
                var res = "";

                for (int i = 0; i < maxLength; i++)
                {
                    if (i <= aL - 1 && i <= bL - 1)
                    {
                        if (a[i] == '1' && b[i] == '1')
                        {
                            if (oneInMind == 1)
                                res += "1";
                            else
                                res += "0";

                            oneInMind = 1;
                        }
                        else if (a[i] == '0' && b[i] == '0')
                        {
                            if (oneInMind == 1)
                            {
                                res += "1";
                                oneInMind = 0;
                            }
                            else
                            {
                                res += "0";
                            }
                        }
                        else
                        {
                            if (oneInMind == 1)
                            {
                                res += "0";
                                oneInMind = 1;
                            }
                            else
                            {
                                res += "1";
                            }
                        }
                    }
                    else
                    {
                        if (aL > bL)
                        {
                            if (oneInMind == 1)
                            {
                                if (a[i] == '1')
                                {
                                    res += "0";
                                    oneInMind = 1;
                                }
                                else if (a[i] == '0')
                                {
                                    res += "1";
                                    oneInMind = 0;
                                }
                            }
                            else
                            {
                                res += a[i];
                            }
                        }
                        else if (bL > aL)
                        {
                            if (oneInMind == 1)
                            {
                                if (b[i] == '1')
                                {
                                    res += "0";
                                    oneInMind = 1;
                                }
                                else if (b[i] == '0')
                                {
                                    res += "1";
                                    oneInMind = 0;
                                }
                            }
                            else
                            {
                                res += b[i];
                            }
                        }
                    }
                }

                if (oneInMind == 1)
                    res += "1";

                res = new string(res.Reverse().ToArray());
                return res;
            }
        }
    }
}