using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xunit;

namespace leetcode.Tests.Algo.DynamicProgramming
{
    public class Knapsack
    {
        // good article about knapsack problem https://www.hackerearth.com/ru/practice/notes/the-knapsack-problem/

        [Theory]
        [InlineData(new[] { 5, 4, 6, 3 }, new [] { 10, 40, 30, 50 }, 10, 90)]
        [InlineData(new[] { 1, 4, 3 }, new[] { 1500, 3000, 2000 }, 4, 3500)]
        [InlineData(new[] { 1, 4, 3, 1 }, new[] { 1500, 3000, 2000, 2000 }, 4, 4000)]
        public void Test(int[] weights, int[] values, int maxWeight, int expected)
        {
            var actual = MyKnapsack.knapsack(values, weights, maxWeight);

            Assert.Equal(expected, actual);
        }

        class MyKnapsack
        {
            public static int knapsack(int[] values, int[] weights, int maxWeight)
            {
                var rowCount = values.Length;
                var V = new int[rowCount + 1, maxWeight + 1];

                for (int j = 0; j < maxWeight + 1; j++)
                    V[0, j] = 0;

                for (int i = 0; i < rowCount + 1; i++)
                    V[i, 0] = 0;


                for (int i = 1; i < rowCount + 1; i++)
                {
                    for (int j = 1; j < maxWeight + 1; j++)
                    {
                        int currItemWeight = weights[i - 1];
                        int currItemValue = values[i - 1];
                        int currMaxBagCapacity = j;

                        if (currMaxBagCapacity >= currItemWeight)
                        {
                            var prevMaxValue = V[i - 1, j];

                            var remainingCapacity = currMaxBagCapacity - currItemWeight;

                            // посмотреть какой максимум вместится в оставшийся объём.
                            // смотрим на предыдущую строку т.к. текущий предмет уже положен в рюкзак
                            // и в максимуме для оставшегося объёма не участвует
                            var maxForRemainingCapacity = V[i - 1, remainingCapacity];

                            var currValue = currItemValue + maxForRemainingCapacity;

                            var max = Math.Max(prevMaxValue, currValue);
                            V[i, j] = max;
                        }
                        else
                        {
                            V[i, j] = V[i - 1, j];
                        }

                        Print(V, rowCount, maxWeight);
                    }
                }

                return V[rowCount, maxWeight];
            }

            private static void Print(int[,] V, int N, int W)
            {
                for (int i = 0; i < N + 1; i++)
                {
                    for (int j = 0; j < W + 1; j++)
                    {
                        Debug.Write(V[i, j] + "\t");
                    }
                    Debug.WriteLine("");
                }

                Debug.WriteLine("");
                Debug.WriteLine("");
            }
        }
    }
}
