using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xunit;

namespace leetcode.Tests.HackerRank
{
    public class Array2D
    {
        [Fact]
        public void SolutionTestSecond()
        {
            var input = new[]
            {
                new[] {-1, -1, 0, -9, -2, -2},
                new[] {-2, -1, -6, -8, -2, -5},
                new[] {-1, -1, -1, -2, -3, -4},
                new[] {-1, -9, -2, -4, -4, -5},
                new[] {-7, -3, -3, -2, -9, -9},
                new[] {-1, -3, -1, -2, -4, -5}
            };

            // act
            var s = new Solution();

            var actual = s.HourglassSum(input);

            // assert
            Assert.Equal(-6, actual);
        }

        [Fact]
        public void SolutionTest()
        {
            // arrange
            var input = new[]
            {
                new[] {1, 1, 1, 0, 0, 0},
                new[] {0, 1, 0, 0, 0, 0},
                new[] {1, 1, 1, 0, 0, 0},
                new[] {0, 0, 2, 4, 4, 0},
                new[] {0, 0, 0, 2, 0, 0},
                new[] {0, 0, 1, 2, 4, 0}
            };

            // act
            var s = new Solution();

            var actual = s.HourglassSum(input);

            // assert
            Assert.Equal(19, actual);
        }

        public class Solution
        {
            const int hourglassWidth = 3;
            const int hourglassHeight = 3;

            public int HourglassSum(int[][] arr)
            {
                
                var arrSide = arr.Length;

                var max = GetHourglassSum(arr, 0, 0);
                for (int i = 0; i < arrSide - hourglassHeight + 1 ; i++)
                {
                    for (int j = 0; j < arrSide - hourglassWidth + 1; j++)
                    {
                        var nextSum = GetHourglassSum(arr, i, j);
                        if (nextSum > max)
                            max = nextSum;
                    }
                }

                return max;
            }

            public int GetHourglassSum(int[][] arr, int iShift, int jShift)
            {
                var sum = 0;
                for (int i = iShift; i < hourglassHeight + iShift; i++)
                {
                    for (int j = jShift; j < hourglassWidth + jShift; j++)
                    {
                        if (!(i == 1 + iShift && j == 0 + jShift)
                            && !(i == 1 + iShift && j == 2 + jShift))
                        {
                            sum += arr[i][j];
                        }
                    }
                }

                return sum;
            }
        }
    }
}
