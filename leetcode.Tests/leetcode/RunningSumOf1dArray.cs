using FluentAssertions;
using Xunit;

namespace Algo.Tests.leetcode
{
    public class RunningSumOf1dArray
    {
        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4 }, new int[] { 1, 3, 6, 10 })]
        public void Test(int[] nums, int[] expected)
        {
            var actual = RunningSum(nums);
            actual.Should().BeEquivalentTo(expected);
        }

        public int[] RunningSum(int[] nums)
        {
            var tmp = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                tmp += nums[i];
                nums[i] = tmp;
            }

            return nums;
        }
    }
}
