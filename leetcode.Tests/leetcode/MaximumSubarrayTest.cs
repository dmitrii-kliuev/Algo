using System;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace Algo.Tests.leetcode
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class MaximumSubarrayTest
    {

        [Theory]
        [InlineData(new[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 }, 6)] // Explanation: [4,-1,2,1] has the largest sum = 6.
        [InlineData(new[] { -1, 1, 0, 2, -3, -1, -2, 0, -1, 1, 25 }, 26)]
        [InlineData(new[] { 5, -3, 6, -7, 6 }, 8)]
        [InlineData(new[] { -2, -3, -1, -7, -6 }, -1)]
        public void Test(int[] nums, int expected)
        {
            var s = new Solution();
            var actual = s.MaxSubArray(nums);
            Assert.Equal(expected, actual);
        }

        public class Solution
        {
            public int MaxSubArray(int[] nums)
            {
                if (nums.Length == 0) return 0;

                var max = nums[0];
                var ans = max;

                for (int i = 1; i < nums.Length; i++)
                {
                    max = Math.Max(nums[i], max + nums[i]);

                    if (max > ans)
                        ans = max;
                }

                return ans;
            }
        }

        public class SlowSolution
        {
            public int MaxSubArray(int[] nums)
            {
                if (nums.Length == 0) return 0;

                var n = nums.Length;
                var ans = nums[0];

                for (int sub_array_size = 1; sub_array_size <= n; sub_array_size++)
                {
                    for (int start_index = 0; start_index < n; start_index++)
                    {
                        if (start_index + sub_array_size > n) break;

                        var sum = 0;
                        for (int k = start_index; k < (start_index + sub_array_size); k++)
                            sum += nums[k];

                        ans = Math.Max(ans, sum);

                    }
                }

                return ans;
            }
        }
    }
}
