using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace leetcode.Tests.leetcode
{
    public class RobotReturnToOrigin
    {
        [Theory]
        [InlineData("UD", true)]
        [InlineData("LL", false)]
        public void Test(string moves, bool expected)
        {
            var s = new Solution();
            var actual = s.JudgeCircle(moves);
            Assert.Equal(expected, actual);
        }

        public class Solution
        {
            public bool JudgeCircle(string moves)
            {
                int x = 0;
                int y = 0;

                foreach (var move in moves)
                {
                    if (move == 'U') x++;
                    if (move == 'D') x--;
                    if (move == 'R') y++;
                    if (move == 'L') y--;
                }

                return x == 0 && y == 0;
            }
        }
    }
}
