using System.Collections.Generic;
using System.Diagnostics;
using Xunit;

namespace Algo.Tests.leetcode
{
    public class NRepeatedElementInSize2NArray
    {
        [Theory]
        [InlineData(new[] { 1, 2, 3, 3 }, 3)]
        [InlineData(new[] { 2, 1, 2, 5, 3, 2 }, 2)]
        [InlineData(new[] { 5, 1, 5, 2, 5, 3, 5, 4 }, 5)]
        public void Test(int[] arr, int expected)
        {
            int k = 1;
            var test = (k++ + ++k); // 4
            Debug.WriteLine(test);

            var s = new Solution();
            var actual = s.RepeatedNTimes(arr);
            Assert.Equal(expected, actual);
        }

        private class Solution
        {
            public int RepeatedNTimes(int[] a)
            {
                var tmp = new int[10000];
                var res = 0;
                for (int i = 0; i < a.Length; i++)
                {
                    if (tmp[a[i]] == 0)
                        tmp[a[i]] = 1;
                    else
                    {
                        return a[i];
                    }
                }


                return res;
            }
        }

        public class SolutionWithHashSet
        {
            public int RepeatedNTimes(int[] a)
            {
                var hs = new HashSet<int>();
                var res = 0;
                for (int i = 0; i < a.Length; i++)
                {
                    if (!hs.Add(a[i])) return a[i];
                }

                return res;
            }
        }
    }
}
