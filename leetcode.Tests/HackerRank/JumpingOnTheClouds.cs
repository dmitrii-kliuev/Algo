using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace leetcode.Tests.HackerRank
{
    public class JumpingOnTheClouds
    {
        [Theory]
        //[InlineData(new[] { 0, 1, 0, 0, 0, 1, 0 }, 3)]
        //[InlineData(new[] { 0, 0, 1, 0, 0, 1, 0 }, 4)]
        //[InlineData(new[] { 0, 0, 0, 0, 1, 0 }, 3)]
        [InlineData(new[] { 0, 0, 0, 1, 0, 0 }, 3)]
        public void SolutionTest(int[] input, int expected)
        {
            // arrange
            var s = new Solution();

            // act
            var actual = s.JumpingOnClouds(input);

            // assert
            Assert.Equal(expected, actual);
        }

        public class Solution
        {
            public int JumpingOnClouds(int[] c)
            {
                var jumpQty = 0;

                var i = 0;
                while (i < c.Length - 1)
                {
                    if (i < c.Length - 2 && c[i + 2] == 0)
                    {
                        jumpQty++;
                        i += 2;
                        continue;
                    }

                    if (c[i + 1] == 0)
                    {
                        jumpQty++;
                        i += 1;
                    }
                }

                return jumpQty;
            }
        }
    }
}
