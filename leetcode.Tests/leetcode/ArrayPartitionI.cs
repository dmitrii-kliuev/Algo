using System;
using Xunit;

namespace Algo.Tests.leetcode
{
    public class ArrayPartitionI
    {
        [Theory]
        [InlineData(new[] { 1, 4, 3, 2 }, 4)]
        public void Test(int[] arr, int expected)
        {
            var s = new Solution();
            var actual = s.ArrayPairSum(arr);
            Assert.Equal(expected, actual);
        }

        public class Solution
        {
            public int ArrayPairSum(int[] nums)
            {
                var res = 0;

                Array.Sort(nums);

                for (int i = 0, j = 0; j < nums.Length / 2; i += 2, j++)
                {
                    res += nums[i];
                }

                return res;
            }
        }
    }
}
