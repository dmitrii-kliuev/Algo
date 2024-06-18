using FluentAssertions;
using Xunit;

namespace Algo.Tests.leetcode
{
    public class LargestLocalValuesInAMatrix
    {
        [Fact]
        public void Test()
        {
            var grid = new int[][]
            {
                new int[]{ 9, 9, 8, 1 },
                new int[]{ 5, 6, 2, 6 },
                new int[]{ 8, 2, 6, 4 },
                new int[]{ 6, 2, 2, 2 }
            };

            var expected = new int[][]
            {
                new int[] { 9, 9 },
                new int[] { 8, 6 }
            };

            var actual = LargestLocal(grid);

            for (var i = 0; i < expected[0].Length; i++)
            {
                actual[i].Should().BeEquivalentTo(expected[i]);
            }
        }

        public int[][] LargestLocal(int[][] grid)
        {
            var gridRowLength = grid[0].Length;

            var matrixSize = 3;
            var matrixCount = gridRowLength - matrixSize;

            var maxLocalRowSize = gridRowLength - 2;
            var maxLocal = new int[maxLocalRowSize][];

            for (int mr = 0; mr <= matrixCount; mr++)
            {
                maxLocal[mr] = new int[maxLocalRowSize];

                for (int mc = 0; mc <= matrixCount; mc++)
                {
                    maxLocal[mr][mc] = GetMax(grid, mr, mc);

                }
            }


            return maxLocal;
        }

        private int GetMax(int[][] grid, int mr, int mc)
        {
            var matrixSize = 3;
            var max = grid[mr][mc];

            for (int i = mr; i < matrixSize + mr; i++)
            {
                for (int j = mc; j < matrixSize + mc; j++)
                {
                    if (grid[i][j] > max)
                        max = grid[i][j];
                }
            }

            return max;
        }
    }
}
