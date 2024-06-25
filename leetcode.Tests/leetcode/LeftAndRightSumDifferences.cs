using FluentAssertions;
using System;
using Xunit;

namespace Algo.Tests.leetcode
{
    public class LeftAndRightSumDifferences
    {
        [Theory]
        [InlineData(new int[] { 10, 4, 8, 3 }, new int[] { 15, 1, 11, 22 })]
        public void Test(int[] nums, int[] expected)
        {
            var actual = LeftRightDifference(nums);
            actual.Should().BeEquivalentTo(expected);
        }

        public int[] LeftRightDifference(int[] nums)
        {
            var res = new int[nums.Length];

            var leftSum = new int[nums.Length];
            var rightSum = new int[nums.Length];

            for (var i = 0; i < nums.Length; i++)
            {
                if (i == 0) {
                    leftSum[i] = 0;
                    rightSum[nums.Length - 1] = 0;
                }
                else
                {
                    leftSum[i] = leftSum[i - 1] + nums[i - 1];

                    var rIndex = nums.Length - i - 1;
                    rightSum[rIndex] = rightSum[rIndex + 1] + nums[rIndex + 1];
                }
            }

            for (int i = 0; i < nums.Length; i++)
            {
                res[i] = Math.Abs(leftSum[i] - rightSum[i]);
            }

            return res;
        }
    }
}
