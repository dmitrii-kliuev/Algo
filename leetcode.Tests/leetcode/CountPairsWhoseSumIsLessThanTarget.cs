using System.Collections.Generic;
using Xunit;

namespace Algo.Tests.leetcode
{
    public class CountPairsWhoseSumIsLessThanTarget
    {
        [Theory]
        [InlineData(new int[] { -1, 1, 2, 3, 1 }, 2, 3)]
        [InlineData(new int[] { -6, 2, 5, -2, -7, -1, 3 }, -2, 10)]
        public void Test(IList<int> nums, int target, int expected)
        {
            var actual = CountPairs(nums, target);
            Assert.Equal(expected, actual);
        }

        public int CountPairs(IList<int> nums, int target)
        {
            var count = 0;
            for (int i = 0; i < nums.Count; i++)
            {
                for (int j = i + 1; j < nums.Count; j++)
                {
                    var sum = nums[i] + nums[j];
                    if (sum < target)
                        count++;
                }
            }


            return count;
        }
    }
}
