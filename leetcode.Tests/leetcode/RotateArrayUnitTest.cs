using System;
using Xunit;


namespace leetcode.Tests
{
    public class RotateArrayUnitTest
    {
        [Xunit.Theory]
        [InlineData(new[] { 1, 2, 3, 4, 5, 6, 7 }, 3, new[] { 5, 6, 7, 1, 2, 3, 4 })]
        [InlineData(new[] { -1, -100, 3, 99 }, 2, new[] {3,99,-1,-100})]
        public void Test1(int[] input, int k, int[] output)
        {
            // arrange
            var s = new RotateArraySolution();

            // act
            s.Rotate(input, k);

            // assert
            Assert.Equal(input, output);
        }
    }


    //Approach #2 Using Extra Array [Accepted]
    public class RotateArraySolution
    {
        public void Rotate(int[] nums, int k)
        {
            var extraArr = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                extraArr[(i + k) % nums.Length] = nums[i];
            }

            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = extraArr[i];
            }
        }

        public void Rotate0(int[] nums, int k)
        {
            for (int j = 0; j < k; j++)
            {
                int lastNum = nums[nums.Length - 1];
                for (int i = nums.Length - 1; i >= 0; i--)
                {
                    if (i != 0)
                        nums[i] = nums[i - 1];
                    else
                        nums[i] = lastNum;
                }
            }
        }
    }
}