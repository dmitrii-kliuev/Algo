using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xunit;

namespace Algo.Tests.leetcode
{
/*
    Given an integer array nums of length n, you want to create an array ans of length 2n where ans[i] == nums[i] and ans[i + n] == nums[i] for 0 <= i < n (0-indexed).

    Specifically, ans is the concatenation of two nums arrays.

    Return the array ans.

 

    Example 1:

    Input: nums = [1,2,1]
    Output: [1,2,1,1,2,1]
    Explanation: The array ans is formed as follows:
    - ans = [nums[0],nums[1],nums[2],nums[0],nums[1],nums[2]]
    - ans = [1,2,1,1,2,1]
    Example 2:

    Input: nums = [1,3,2,1]
    Output: [1,3,2,1,1,3,2,1]
    Explanation: The array ans is formed as follows:
    - ans = [nums[0],nums[1],nums[2],nums[3],nums[0],nums[1],nums[2],nums[3]]
    - ans = [1,3,2,1,1,3,2,1]
 

    Constraints:

    n == nums.length
    1 <= n <= 1000
    1 <= nums[i] <= 1000

*/

    public class ConcatenationOfArray
    {
        [Theory]
        [InlineData(new int[] { 1, 2, 1 }, new int[] { 1, 2, 1, 1, 2, 1 })]
        [InlineData(new int[] { 1, 3, 2, 1 }, new int[] { 1, 3, 2, 1, 1, 3, 2, 1 })]
        public void Test(int[] nums, int[] expected)
        {
            var res = GetConcatenation(nums);

            res.Should().BeEquivalentTo(expected);
        }

        public int[] GetConcatenation(int[] nums)
        {
            var len = nums.Length;
            var ans = new int[len * 2];

            for (int i = 0; i < len; i++)
            {
                ans[i] = nums[i];
                ans[i + len] = nums[i];
            }

            return ans;
        }
    }
}
