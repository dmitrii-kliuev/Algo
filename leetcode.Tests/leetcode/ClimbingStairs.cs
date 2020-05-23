using Xunit;

namespace Algo.Tests.leetcode
{
    public class ClimbingStairs
    {
        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        [InlineData(3, 3)]
        [InlineData(4, 5)]
        [InlineData(5, 8)]
        [InlineData(6, 13)]
        [InlineData(7, 21)]
        public void Test(int steps, int expected)
        {
            var s = new Solution();
            var actual = s.ClimbStairs(steps);
            Assert.Equal(expected, actual);
        }

        public class Solution
        {
            public int ClimbStairs(int n)
            {
                var dp = new int[n + 1];

                dp[0] = dp[1] = 1;

                for (int i = 2; i < dp.Length; i++)
                {
                    dp[i] = dp[i - 1] + dp[i - 2];
                }

                return dp[n];
            }
        }
    }
}
