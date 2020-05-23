using Xunit;

namespace Algo.Tests.Algo.DynamicProgramming
{
    // Good article https://www.geeksforgeeks.org/understanding-the-coin-change-problem-with-dynamic-programming/

    public class CoinChangeTests
    {
        [Theory]
        [InlineData(new[] { 1, 2, 5 }, 5, 4)]
        [InlineData(new[] { 1, 2, 3 }, 4, 4)]   // 1111, 22, 112, 13
        [InlineData(new[] { 1, 2, 5 }, 100, 541)]
        [InlineData(new[] { 1, 5, 10 }, 8, 2)]
        [InlineData(new[] { 1, 5, 10 }, 12, 4)]
        public void Test(int[] coins, int amount, int expected)
        {
            var s = new Solution();
            if (coins != null)
            {
                var actual = s.Change(amount, coins);
                Assert.Equal(expected, actual);
            }
        }

        private class Solution
        {
            public int Change(int amount, int[] coins)
            {
                var ways = new int[amount + 1];
                ways[0] = 1;

                foreach (var coin in coins)
                {
                    for (int j = 0; j < ways.Length; j++)
                    {
                        if (j >= coin)
                        {
                            ways[j] = ways[j - coin] + ways[j];
                        }
                    }
                }


                return ways[amount];
            }
        }
    }
}
