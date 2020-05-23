using System;
using Xunit;

namespace Algo.Tests.leetcode
{
    public class RotateImageTests
    {
        [Fact]
        public void RotateImageSolutionTest()
        {
            // arrange
            var input = new[,]
            {
                { 1, 2, 3},
                { 4, 5, 6},
                { 7, 8, 9}
            };

            var output = new[,]
            {
                { 7, 4, 1 },
                { 8, 5, 2 },
                { 9, 6, 3 }
            };

            // act
            var s = new Solution();
            s.Rotate(input);

            // assert
            Assert.Equal(input, output);
        }

        [Fact]
        public void RotateImageSolutionTest2()
        {
            // arrange
            var input = new[,]
            {
                { 1,  2,  3,  4},
                { 5,  6,  7,  8},
                { 9,  10, 11, 12},
                { 13, 14, 15, 16}
            };

            var output = new[,]
            {
                {13, 9,  5, 1},
                {14, 10, 6, 2 },
                {15, 11, 7, 3 },
                {16, 12, 8, 4 }
            };

            // act
            var s = new Solution();
            s.Rotate(input);

            // assert
            Assert.Equal(input, output);
        }

        public class Solution
        {
            /*
             * clockwise rotate
             * first reverse up to down, then swap the symmetry 
             * 1 2 3     7 8 9     7 4 1
             * 4 5 6  => 4 5 6  => 8 5 2
             * 7 8 9     1 2 3     9 6 3
            */

            public void Rotate(int[,] matrix)
            {
                var side = (int)Math.Sqrt(matrix.Length);
                Reverse(matrix, side);

                for (int i = 0; i < side; ++i)
                {
                    for (int j = i + 1; j < side; ++j)
                        Swap(matrix, i, j);
                }
            }

            public void Reverse(int[,] matrix, int side)
            {
                /*
                 1 2 3      7 8 9
                 4 5 6 =>   4 5 6
                 7 8 9      1 2 3
                 */

                var step = side - 1;
                var swapQty = side / 2;
                for (int i = 0; i < side; i++)
                {
                    if (swapQty == 0) break;
                    for (int j = 0; j < side; j++)
                    {
                        int buff = matrix[i, j];
                        matrix[i, j] = matrix[step, j];
                        matrix[step, j] = buff;
                    }
                    step--;
                    swapQty--;
                }
            }

            public void Swap(int[,] matrix, int i, int j)
            {
                int tmp = matrix[i, j];
                matrix[i, j] = matrix[j, i];
                matrix[j, i] = tmp;
            }
        }
    }
}
