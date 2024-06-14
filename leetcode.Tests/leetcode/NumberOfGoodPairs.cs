using System.Collections.Generic;
using Xunit;

namespace Algo.Tests.leetcode
{
    public class NumberOfGoodPairs
    {
        /*
        1512. Number of Good Pairs

        Given an array of integers nums, return the number of good pairs.

        A pair (i, j) is called good if nums[i] == nums[j] and i < j.

 

        Example 1:

        Input: nums = [1,2,3,1,1,3]
        Output: 4
        Explanation: There are 4 good pairs (0,3), (0,4), (3,4), (2,5) 0-indexed.
        Example 2:

        Input: nums = [1,1,1,1]
        Output: 6
        Explanation: Each pair in the array are good.

        Example 3:
        Input: nums = [1,2,3]
        Output: 0
 
         */

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 1, 1, 3 }, 4)]
        public void Test(int[] nums, int expected)
        {
            var actual = NumIdenticalPairsV3(nums);
            Assert.Equal(expected, actual);
        }

        public int NumIdenticalPairs(int[] nums)
        {
            var result = 0;
            for (var i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] == nums[j])
                    {
                        result++;
                    }
                }
            }

            return result;
        }

        public int NumIdenticalPairsV2(int[] nums)
        {
            var result = 0;
            var numsMap = new int[101];

            for (int i = 0; i < nums.Length; i++)
            {
                numsMap[nums[i]]++;
            }

            for (int i = 0; i < numsMap.Length; i++)
            {
                var n = numsMap[i];
                result += n * (n - 1) / 2;
            }

            return result;
        }

        public int NumIdenticalPairsV3(int[] nums)
        {
            var result = 0;
            var numsMap = new Dictionary<int, int>();

            foreach (var num in nums)
            {
                if (numsMap.ContainsKey(num)) // 1, 1, 1, 1
                {
                    result += numsMap[num]++;
                }
                else
                {
                    numsMap[num] = 1;
                }
            }

            return result;
        }
    }
}
