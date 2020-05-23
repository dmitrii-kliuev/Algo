using System;
using System.Collections.Generic;
using Xunit;

namespace Algo.Tests.leetcode
{
    public class TimeToBuyAndSellStock3
    {
        [Theory]
        [InlineData(new[] { 3, 3, 5, 0, 0, 3, 1, 4 }, 6)]
        [InlineData(new[] { 1, 2, 3, 4, 5 }, 4)]
        [InlineData(new[] { 2, 1, 4 }, 3)]
        [InlineData(new[] { 1, 2, 4, 2, 5, 7, 2, 4, 9, 0 }, 13)]
        [InlineData(new[] { 2, 1, 2, 0, 1 }, 2)]
        public void Test(int[] arr, int expected)
        {
            var s = new Solution();

            //var test = s.MaxProfitOnTheRange(arr, 0, 2);
            //var test2 = s.MaxProfitOnTheRange(arr, 2, 4);
            var actual = s.MaxProfit(arr);
            Assert.Equal(expected, actual);
        }

        public class Solution
        {
            public int MaxProfit(int[] prices)
            {
                int sell1 = 0, sell2 = 0, buy1 = int.MinValue, buy2 = int.MinValue;
                for (int i = 0; i < prices.Length; i++)
                {
                    buy1 = Math.Max(buy1, -prices[i]);
                    sell1 = Math.Max(sell1, buy1 + prices[i]);
                    buy2 = Math.Max(buy2, sell1 - prices[i]);
                    sell2 = Math.Max(sell2, buy2 + prices[i]);
                }
                return sell2;
            }
        }

        public class Solution1
        {
            public int MaxProfitOnTheRange(int[] arr, int startIdx, int endIdx)
            {
                var max = 0;
                for (int i = startIdx; i <= endIdx; i++)
                {
                    for (int j = i; j <= endIdx; j++)
                    {
                        var buyPrice = arr[i];
                        var sellPrice = arr[j];

                        if (max < sellPrice - buyPrice)
                            max = sellPrice - buyPrice;
                    }
                }

                return max;
            }

            public int MaxProfit(int[] prices)
            {
                var res = 0;
                if (prices.Length == 0 || prices.Length == 1) return res;

                var center = 0;

                while (center != prices.Length)
                {
                    var maxL = MaxProfitOnTheRange(prices, 0, center);
                    var maxR = MaxProfitOnTheRange(prices, center, prices.Length - 1);

                    if (res < maxL + maxR)
                        res = maxL + maxR;

                    center++;
                    if (center == prices.Length) break;
                }

                return res;
            }
        }

        public class SolutionOld
        {
            public int MaxProfit(int[] prices)
            {
                var res = 0;

                if (prices.Length == 0) return res;
                var resList = new List<int>();
                var current = prices[0];
                var tail = prices[prices.Length - 1];
                for (int i = 1; i < prices.Length; i++)
                {
                    if (current >= prices[i])
                    {
                        current = prices[i];
                        continue;
                    }


                    if (current < prices[i] && i < prices.Length - 1 && prices[i + 1] < prices[i])
                    {
                        resList.Add(prices[i] - current);

                        if (i < prices.Length - 1)
                        {
                            i++;
                            current = prices[i];
                        }
                    }

                    if (i == prices.Length - 1)
                    {
                        if (current < tail)
                            resList.Add(tail - current);
                    }
                }

                resList.Sort();
                var counter = 2;
                for (int i = resList.Count - 1; i >= 0; i--)
                {
                    res += resList[i];

                    counter--;
                    if (counter == 0) break;
                }


                return res;
            }
        }


        //if (resList.Count == 0)
        //{
        //    if (current < tail) return tail - current;
        //}
    }
}
