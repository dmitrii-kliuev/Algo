using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace leetcode.Tests.HackerRank
{
    public class ArrayLeftRotation
    {
        [Theory]
        [InlineData(new[] { 1, 2, 3, 4, 5, 6, 7 }, new[] { 3, 4, 5, 6, 7, 1, 2 }, 2)]
        public void SolutionTest(int[] arr, int[] expected, int d)
        {
            // arrange

            // act
            var actual = Solution.RotLeft(arr, d);

            // assert
            Assert.Equal(expected, actual);
        }

        public class Solution
        {
            public static int[] RotLeft(int[] a, int d)
            {
                var output = new int[a.Length];

                var pos = 0;
                for (int i = 0; i < a.Length; i++)
                {
                    if (i + d < a.Length)
                    {
                        output[i] = a[i + d];
                        pos++;
                    }
                    else
                        output[i] = a[i - pos];
                }

                return output;
            }
        }
    }
}
