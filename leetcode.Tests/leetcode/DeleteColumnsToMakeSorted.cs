using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace leetcode.Tests.leetcode
{
    public class DeleteColumnsToMakeSorted
    {
        [Theory]
        [InlineData(new[] { "cba", "daf", "ghi" }, 1)]
        [InlineData(new[] { "a", "b" }, 0)]
        [InlineData(new[] { "zyx", "wvu", "tsr" }, 3)]
        [InlineData(new[] { "rrjk", "furt", "guzm" }, 2)]
        public void Test(string[] arr, int expected)
        {
            var s = new Solution();
            var actual = s.MinDeletionSize(arr);
            Assert.Equal(expected, actual);
        }

        public class Solution
        {
            public int MinDeletionSize(string[] A)
            {
                var res = 0;

                for (int i = 0; i < A[0].Length; i++)
                {
                    var prev = (char)0;
                    foreach (var s in A)
                    {
                        if (prev <= s[i])
                        {
                            prev = s[i];
                        }
                        else
                        {
                            res++;
                            break;
                        }

                    }
                }

                return res;
            }
        }
    }
}
