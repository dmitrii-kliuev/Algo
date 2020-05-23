using System;
using System.Collections.Generic;
using Xunit;

namespace Algo.Tests.leetcode
{
    public class IntersectionOfTwoArrays2Tests
    {
        /*
            Given two arrays, write a function to compute their intersection.

            Example 1:

            Input: nums1 = [1,2,2,1], nums2 = [2,2]
            Output: [2,2]
            Example 2:

            Input: nums1 = [4,9,5], nums2 = [9,4,9,8,4]
            Output: [4,9]
            Note:

            Each element in the result should appear as many times as it shows in both arrays.
            The result can be in any order.
            Follow up:

            What if the given array is already sorted? How would you optimize your algorithm?
            What if nums1's size is small compared to nums2's size? Which algorithm is better?
            What if elements of nums2 are stored on disk, and the memory is limited such that 
            you cannot load all elements into the memory at once?
         */

        [Theory]
        [InlineData(new[] { 1, 2, 2, 1 }, new[] { 2, 2 }, new[] { 2, 2 })]
        [InlineData(new[] { 4, 9, 5 }, new[] { 9, 4, 9, 8, 4 }, new[] { 4, 9 })]
        public void SolutionTest(int[] nums1, int[] nums2, int[] expected)
        {
            // arrange
            var s = new Solution();

            // act
            var actual = s.Intersect(nums1, nums2);

            //assert
            Assert.Equal(expected, actual);
        }

        public class Solution
        {
            public int[] Intersect(int[] nums1, int[] nums2)
            {
                Array.Sort(nums1);
                Array.Sort(nums2);

                var res = new List<int>();
                int i = 0;
                int j = 0;

                while (i < nums1.Length && j < nums2.Length)
                {
                    if (nums1[i] < nums2[j])
                    {
                        i++;
                    }
                    else if (nums1[i] > nums2[j])
                    {
                        j++;
                    }
                    else
                    {
                        res.Add(nums1[i]);
                        i++;
                        j++;
                    }
                }

                return res.ToArray();
            }
        }
    }
}
