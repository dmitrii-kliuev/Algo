using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace leetcode.Tests.leetcode
{
    /*You are given coins of different denominations and a total amount of money.
     Write a function to compute the number of combinations that make up that amount.
     You may assume that you have infinite number of each kind of coin.
    
        Example 1:

        Input: amount = 5, coins = [1, 2, 5]
        Output: 4
        Explanation: there are four ways to make up the amount:
        5=5
        5=2+2+1
        5=2+1+1+1
        5=1+1+1+1+1
        Example 2:

        Input: amount = 3, coins = [2]
        Output: 0
        Explanation: the amount of 3 cannot be made up just with coins of 2.
        Example 3:

        Input: amount = 10, coins = [10] 
        Output: 1
     */

    public class CoinChangeTests
    {
        [Theory]
        [InlineData(new[] { 1, 2, 5 }, 5, 4)]
        [InlineData(new[] { 1, 2, 3 }, 4, 4)]   // 1111, 22, 112, 13
        [InlineData(new[] { 1, 2, 5 }, 100, 541)]
        public void Test(int[] coins, int amount, int expected)
        {
            var s = new Solution();
            var actual = s.change(amount, coins);
            Assert.Equal(expected, actual);
        }

        public class Solution
        {
            public int change(int amount, int[] coins)
            {
                int[] dp = new int[amount + 1];
                dp[0] = 1;
                foreach (int coin in coins)
                {
                    for (int i = coin; i <= amount; i++)
                    {
                        dp[i] += dp[i - coin];
                    }
                }
                return dp[amount];
            }
        }
    }
}
