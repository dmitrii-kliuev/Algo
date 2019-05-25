using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace leetcode.Tests
{
    public class BinarySearchInArr
    {
        [Theory]
        [InlineData(5, 5)]
        [InlineData(10, 10)]
        [InlineData(60, 60)]
        [InlineData(0, 0)]
        [InlineData(99, 99)]
        [InlineData(100, 100)]
        public void Test(int val, int expected)
        {
            var r = Enumerable.Range(0, 101);
            var s = new Solution();
            var actual = s.Search(r.ToArray(), val);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(5, 5)]
        [InlineData(10, 10)]
        [InlineData(60, null)]
        [InlineData(25, 25)]
        [InlineData(26, 26)]
        [InlineData(27, 27)]
        public void Test1(int val, int? expected)
        {
            var r = Enumerable.Range(0, 57);
            var s = new Solution();
            var actual = s.Search(r.ToArray(), val);

            Assert.Equal(expected, actual);
        }

        public class Solution
        {
            public int? Search(int[] arr, int val)
            {
                var low = 0;
                var high = arr.Length - 1;

                while (true)
                {
                    var range = high - low;

                    var mid = range / 2 + low;

                    if (arr[mid] == val)
                        return mid;

                    if (arr[mid] < val)
                        low = mid + 1;

                    if (arr[mid] > val)
                        high = mid - 1;

                    if (low > high) return null;
                }
            }
        }
    }
}
