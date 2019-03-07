using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace leetcode.Tests.leetcode
{

    /* Move Zeroes
  
Given an array nums, write a function to move all 0's to the end of it while maintaining the relative order of the non-zero elements.

Example:

Input: [0,1,0,3,12]
Output: [1,3,12,0,0]
Note:

You must do this in-place without making a copy of the array.
Minimize the total number of operations.*/
    public class MoveZeroesTest
    {
        [Xunit.Theory]
        [InlineData(new[] { 0, 1, 0, 3, 12 }, new[] { 1, 3, 12, 0, 0 })]
        [InlineData(new[] { 0, 0, 1 }, new[] { 1, 0, 0 })]
        public void Test(int[] arr, int[] expected)
        {
            var s = new Solution();

            //s.Shift(arr, 2, 1);

            s.MoveZeroes(arr);
            Assert.Equal(expected, arr);

            var st = new SolutionTrivial();
            st.MoveZeroes(arr);
            Assert.Equal(expected, arr);
        }

    }

    public class Solution
    {
        public void MoveZeroes(int[] nums)
        {
            var tailQty = 0;
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                if (nums[i] == 0)
                {
                    tailQty++;
                    Shift(nums, i, tailQty);
                    nums[nums.Length - tailQty] = 0;
                }
            }
        }

        public void Shift(int[] nums, int pos, int tailQty)
        {
            for (int i = pos; i < nums.Length - tailQty; i++)
            {
                nums[i] = nums[i + 1];
            }
        }
    }

    public class SolutionTrivial
    {
        public void MoveZeroes(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < nums.Length - 1; j++)
                {
                    if (nums[j] == 0)
                    {
                        var tmp = nums[j];
                        nums[j] = nums[j + 1];
                        nums[j + 1] = tmp;
                    }
                }
            }
        }
    }
}
