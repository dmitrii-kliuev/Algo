using System;
using Xunit;

namespace Algo.Tests.leetcode
{
    public class ContainerWithMostWater
    {
        [Theory]
        [InlineData(new int[] { 8, 7, 2, 1 }, 7)]
        [InlineData(new int[] { 1, 1 }, 1)]
        [InlineData(new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 }, 49)]
        [InlineData(new int[] { 1, 2 }, 1)]
        [InlineData(new int[] { 2, 3, 4, 5, 18, 17, 6 }, 17)]
        public void Test(int[] height, int expected)
        {
            var actual = MaxArea(height);
            Assert.Equal(expected, actual);
        }

        public int MaxArea(int[] height)
        {
            if (height.Length < 2)
            {
                return -1;
            }

            var p1 = 0;
            var p2 = height.Length - 1;

            var maxSquare = 0;

            for (int i = 0; i < height.Length; i++)
            {
                var min = Math.Min(height[p1], height[p2]);
                var square = min * (p2 - p1);
                if (square > maxSquare)
                    maxSquare = square;

                if (height.Length == 2)
                {
                    return maxSquare;
                }

                if (height[p1] < height[p2])
                {
                    p1++;
                }
                else
                {
                    p2--;
                }
            }

            return maxSquare;
        }
    }
}
