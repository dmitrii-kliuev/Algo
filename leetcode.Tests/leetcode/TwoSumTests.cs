using System.Collections.Generic;
using Xunit;

namespace Algo.Tests.leetcode
{
    /*Given an array of integers, return indices of the two numbers such that they add up to a specific target.

You may assume that each input would have exactly one solution, and you may not use the same element twice.

Example:

Given nums = [2, 7, 11, 15], target = 9,

Because nums[0] + nums[1] = 2 + 7 = 9,
return [0, 1].*/

    public class TwoSumTests
    {
        [Theory]
        [InlineData(new[] { 2, 7, 11, 15 }, 9, new[] { 0, 1 })]
        [InlineData(new[] { 2, 11, 7, 15 }, 9, new[] { 0, 2 })]
        [InlineData(new[] { 3, 3 }, 6, new[] { 0, 1 })]
        public void TwoSumTest(int[] nums, int target, int[] trueRes)
        {
            // arrange
            var s = new Solution();

            // act
            var result = s.TwoSum(nums, target);

            // assert
            Assert.Equal(trueRes, result);
        }

        #region My not bad solution
        public class Solution
        {
            public int[] TwoSum(int[] nums, int target)
            {
                var result = new int[2];
                for (int i = 0; i < nums.Length; i++)
                {
                    for (int j = i + 1; j < nums.Length; j++)
                    {
                        if (nums[i] + nums[j] == target)
                        {
                            result[0] = i;
                            result[1] = j;
                            break;
                        }
                    }
                }


                return result;
            }
        }
        #endregion

        #region Cool solution
        public class Solution2
        {
            public int[] TwoSum(int[] nums, int target)
            {
                Dictionary<int, int> dict = new Dictionary<int, int>();
                for (int i = 0; i < nums.Length; i++)
                {
                    if (dict.ContainsKey(target - nums[i]))
                    {
                        return new[] { dict[target - nums[i]], i };
                    }

                    if (!dict.ContainsKey(nums[i]))
                    {
                        dict.Add(nums[i], i);
                    }
                }
                return new[] { -1, -1 };
            }
        }
        #endregion
    }
}
