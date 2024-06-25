using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace Algo.Tests.leetcode
{
    public class HowManyNumbersAreSmallerThanTheCurrentNumber
    {
        [Theory]
        [InlineData(new int[] { 8, 1, 2, 2, 3 }, new int[] { 4, 0, 1, 1, 3 })]
        public void Test(int[] nums, int[] expeted)
        {
            var actual = SmallerNumbersThanCurrentV2(nums);
            expeted.Should().BeEquivalentTo(actual);
        }

        public int[] SmallerNumbersThanCurrentV2(int[] nums)
        {
            List<int> numsSorted = new List<int>(nums);
            numsSorted.Sort();
            int[] output = new int[nums.Length];
            for (int i = 0; i < numsSorted.Count; i++)
            {
                output[i] = numsSorted.IndexOf(nums[i]);
            }
            return output;
        }

        public int[] SmallerNumbersThanCurrent(int[] nums)
        {
            var result = new int[nums.Length];

            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < nums.Length; j++)
                {
                    if(i != j && nums[j] < nums[i])
                    {
                        result[i]++;
                    }
                }
            }

            return result;
        }
    }
}
