using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace leetcode.Tests
{
    public class ContainsDuplicateTests
    {
        [Theory]
        [InlineData(new[] { 1, 2, 3, 1 }, true)]
        [InlineData(new[] { 1, 2, 3, 4 }, false)]
        [InlineData(new[] { 1, 1, 1, 3, 3, 4, 3, 2, 4, 2 }, true)]
        public void ContainsDuplicateSolutionTest(int[] nums, bool expected)
        {
            // arrange
            var s = new Solution();

            // act
            var actual = s.ContainsDuplicate(nums);

            // assert
            Assert.Equal(expected, actual);
        }

        public class Solution
        {
            public bool ContainsDuplicate(int[] nums)
            {
                var numsList = nums.ToList();
                numsList.Sort();

                for (int i = 0; i < numsList.Count - 1; i++)
                {
                    if (numsList[i] == numsList[i + 1])
                        return true;
                }

                return false;
            }
        }

        public class Solution2
        {
            public bool ContainsDuplicate(int[] nums)
            {

                HashSet<int> set = new HashSet<int>();

                for (int i = 0; i < nums.Length; i++)
                {
                    if (set.Contains(nums[i]))
                        return true;

                    set.Add(nums[i]);
                }

                return false;

            }
        }
    }
}
