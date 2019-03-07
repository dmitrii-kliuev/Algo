using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace leetcode.Tests.leetcode
{
    public class RemoveElementTest
    {
        [Theory]
        [InlineData(new int[] { 3, 2, 2, 3 }, 3, new[] { 2, 2 }, 2)]
        [InlineData(new int[] { 0, 1, 2, 2, 3, 0, 4, 2 }, 2, new[] { 0, 1, 3, 0, 4 }, 5)]
        [InlineData(new int[] { 1 }, 1, new int[0], 0)]
        [InlineData(new int[] { 1, 2 }, 1, new[] { 2 }, 1)]
        [InlineData(new int[] { 2, 1 }, 1, new[] { 2 }, 1)]
        [InlineData(new int[] { 2, 2 }, 1, new[] { 2, 2 }, 2)]
        [InlineData(new int[] { 3, 3 }, 3, new int[0], 0)]
        [InlineData(new int[] { 2, 2, 3 }, 2, new[] { 3 }, 1)]
        public void RemoveElementSolution(int[] nums, int val, int[] expectedArr, int expectedLen)
        {
            var s = new Solution();
            var actualLen = s.RemoveElement(nums, val);
            Assert.Equal(expectedLen, actualLen);

            var actualArr = new int[actualLen];
            for (int i = 0; i < actualLen; i++)
                actualArr[i] = nums[i];

            Array.Sort(expectedArr);
            Array.Sort(actualArr);
            Assert.Equal(expectedArr, actualArr);
        }

        public class Solution
        {
            public int RemoveElement(int[] nums, int val)
            {
                var len = nums.Length;

                if (len == 1 && nums[0] == val)
                    return 0;

                var valCount = 0;

                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] == val && i < nums.Length - 1)
                    {
                        valCount = 0;

                        for (int j = nums.Length - 1; j >= 0; j--)
                        {
                            if (nums[j] != val)
                                break;

                            valCount++;
                        }

                        if (nums.Length == valCount + i)
                            break;

                        // swap
                        var tail = nums.Length - valCount - 1;
                        var tmp = nums[i];
                        nums[i] = nums[tail];
                        nums[tail] = tmp;

                        valCount++;
                    }

                    if (nums[i] == val && i == nums.Length - 1)
                        valCount++;

                    if (i + valCount == nums.Length - 1)
                        break;
                }

                return len - valCount;
            }
        }

        public class Solution2 // from leetcode
        {
            public int RemoveElement(int[] nums, int val)
            {
                int result = 0;

                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] != val)
                    {
                        nums[result++] = nums[i];
                    }
                }

                return result;
            }
        }
    }
}
