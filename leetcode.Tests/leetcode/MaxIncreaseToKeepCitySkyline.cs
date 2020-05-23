using System;
using Xunit;

namespace Algo.Tests.leetcode
{
    public class MaxIncreaseToKeepCitySkyline
    {
        /*
            https://leetcode.com/problems/max-increase-to-keep-city-skyline/
            807. Max Increase to Keep City Skyline

            In a 2 dimensional array grid, each value grid[i][j] represents the height of 
            a building located there. We are allowed to increase the height of any number of buildings, 
            by any amount (the amounts can be different for different buildings). 
            Height 0 is considered to be a building as well. 

            At the end, the "skyline" when viewed from all four directions of the grid, 
            i.e. top, bottom, left, and right, must be the same as the skyline of the original grid. 
            A city's skyline is the outer contour of the rectangles formed by all the buildings 
            when viewed from a distance. See the following example.

            What is the maximum total sum that the height of the buildings can be increased?

            Example:
            Input: grid = [[3,0,8,4],[2,4,5,7],[9,2,6,3],[0,3,1,0]]
            Output: 35
            Explanation: 
            The grid is:
            [ [3, 0, 8, 4], 
                [2, 4, 5, 7],
                [9, 2, 6, 3],
                [0, 3, 1, 0] ]

            The skyline viewed from top or bottom is: [9, 4, 8, 7]
            The skyline viewed from left or right is: [8, 7, 9, 3]

            The grid after increasing the height of buildings without affecting skylines is:

            gridNew = [ [8, 4, 8, 7],
                        [7, 4, 7, 7],
                        [9, 4, 8, 7],
                        [3, 3, 3, 3] ]

            Notes:

            1 < grid.length = grid[0].length <= 50.
            All heights grid[i][j] are in the range [0, 100].
            All buildings in grid[i][j] occupy the entire grid cell: that is, 
            they are a 1 x 1 x grid[i][j] rectangular prism.
        */

        [Fact]
        public void Test()
        {
            var expected = 35;
            var arr = new[]
            {
                new []{ 3, 0, 8, 4 },
                new []{ 2, 4, 5, 7 },
                new []{ 9, 2, 6, 3 },
                new []{ 0, 3, 1, 0 }
            };

            var s = new Solution();
            var actual = s.MaxIncreaseKeepingSkyline(arr);
            Assert.Equal(expected, actual);
        }

        public class Solution
        {
            public int MaxIncreaseKeepingSkyline(int[][] grid)
            {
                if (grid.GetLength(0) == 0) throw new Exception("grid is empty");
                var x = grid.GetLength(0);
                var y = grid[0].GetLength(0);
                var xMax = new int[x];
                var yMax = new int[y];

                for (int i = 0; i < x; i++)
                    xMax[i] = GetMax(grid[i]);

                for (int j = 0; j < y; j++)
                {
                    var maxY = grid[0][j];
                    for (int i = 0; i < x; i++)
                        if (grid[i][j] > maxY) maxY = grid[i][j];

                    yMax[j] = maxY;
                }

                var res = 0;

                for (int i = 0; i < x; i++)
                {
                    for (int j = 0; j < y; j++)
                    {
                        var min = xMax[i] < yMax[j] ? xMax[i] : yMax[j];

                        res += min - grid[i][j];
                    }
                }

                return res;
            }

            private int GetMax(int[] arr)
            {
                var max = arr[0];
                foreach (var item in arr)
                    if (item > max) max = item;

                return max;
            }
        }
    }
}
