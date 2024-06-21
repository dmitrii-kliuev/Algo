using System;
using Xunit;

namespace Algo.Tests.leetcode
{
    public class WidestVerticalAreaBetweenTwoPointsContainingNoPoints
    {
        [Fact]
        public void Test()
        {
            var points = new int[4][]
            {
                new int[2]{ 8, 7 },
                new int[2]{ 9, 9 },
                new int[2]{ 7, 4 },
                new int[2]{ 9, 7 },
            };

            var expected = 1;

            var actual = MaxWidthOfVerticalArea(points);

            Assert.Equal(expected, actual);
        }


        public int MaxWidthOfVerticalArea(int[][] points)
        {
            var xPoints = new int[points.Length];

            for (var i = 0; i < points.Length; i++)
            {
                xPoints[i] = points[i][0];
            }

            Array.Sort(xPoints);

            var maxWidth = 0;
            for (int i = 0; i < xPoints.Length - 1; i++)
            {
                var tmp = Math.Abs(xPoints[i] - xPoints[i + 1]);
                if (tmp > maxWidth)
                    maxWidth = tmp;
            }

            return maxWidth;
        }
    }
}
