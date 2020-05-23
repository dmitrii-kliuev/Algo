using System.Collections.Generic;
using Xunit;

namespace Algo.Tests.leetcode
{
    public class UniqueEmailAddresses
    {
        [Theory]
        [InlineData(new[] {
            "test.email+alex@leetcode.com",
            "test.e.mail+bob.cathy@leetcode.com",
            "testemail+david@lee.tcode.com" }, 2)]
        public void Test(string[] arr, int expected)
        {
            var s = new Solution();
            var actual = s.NumUniqueEmails(arr);
            Assert.Equal(expected, actual);
        }

        public class Solution
        {
            public int NumUniqueEmails(string[] emails)
            {
                var uniq = new List<string>();
                foreach (var email in emails)
                {
                    var parts = email.Split('@');
                    var indexOfPlus = parts[0].IndexOf('+');
                    parts[0] = parts[0].Substring(0, indexOfPlus);
                    parts[0] = parts[0].Replace(".", "");
                    var cleanMail = $"{parts[0]}@{parts[1]}";
                    if (!uniq.Contains(cleanMail))
                        uniq.Add(cleanMail);
                }

                return uniq.Count;
            }
        }
    }
}
