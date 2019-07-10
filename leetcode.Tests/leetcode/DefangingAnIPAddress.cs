using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace leetcode.Tests.leetcode
{
    public class DefangingAnIPAddress
    {
        /*
        Given a valid (IPv4) IP address, return a defanged version of that IP address.

        A defanged IP address replaces every period "." with "[.]".
        
        Example 1:

        Input: address = "1.1.1.1"
        Output: "1[.]1[.]1[.]1"
        Example 2:

        Input: address = "255.100.50.0"
        Output: "255[.]100[.]50[.]0"
*/

        [Theory]
        [InlineData("1.1.1.1", "1[.]1[.]1[.]1")]
        [InlineData("255.100.50.0", "255[.]100[.]50[.]0")]
        public void Test(string ip, string expected)
        {
            var s = new Solution();
            var actual = s.DefangIPaddr(ip);
            Assert.Equal(expected, actual);
        }

        public class Solution
        {
            public string DefangIPaddr(string address)
            {
                var res = new StringBuilder();
                foreach (var ch in address)
                {
                    if (ch == '.')
                        res.Append("[.]");
                    else
                        res.Append(ch);
                }

                return res.ToString();
            }
        }
    }
}
