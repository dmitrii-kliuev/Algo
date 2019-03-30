using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Xunit;

namespace leetcode.Tests.Algo.DynamicProgramming
{
    public class Knapsack
    {
        // good article about knapsack problem https://www.hackerearth.com/ru/practice/notes/the-knapsack-problem/

        [Theory]
        [InlineData(new[] { 5, 4, 6, 3 }, new[] { 10, 40, 30, 50 }, 10, 90)]
        [InlineData(new[] { 1, 4, 3 }, new[] { 1500, 3000, 2000 }, 4, 3500)]
        [InlineData(new[] { 1, 4, 3, 1 }, new[] { 1500, 3000, 2000, 2000 }, 4, 4000)]
        public void Test(int[] weights, int[] values, int maxWeight, int expected)
        {
            var actual = MyKnapsack.knapsack(values, weights, maxWeight);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new[] { 5, 4, 6, 3 }, new[] { 10, 40, 30, 50 }, 10, 90)]
        [InlineData(new[] { 1, 4, 3 }, new[] { 1500, 3000, 2000 }, 4, 3500)]
        [InlineData(new[] { 1, 4, 3, 1 }, new[] { 1500, 3000, 2000, 2000 }, 4, 4000)]
        [InlineData(new[] { 3, 1, 2, 2, 1 }, new[] { 10, 3, 9, 5, 6 }, 6, 25)]
        public void TestExtended(int[] weights, int[] values, int maxWeight, int expected)
        {
            var actual = MyKnapsackExtended.knapsack(values, weights, maxWeight);

            Assert.Equal(expected, actual);
        }

        public class SubItem
        {
            public int TotalValue;
            public List<int> ItemList = new List<int>();
        }

        static class MyKnapsackExtended
        {
            public static int knapsack(int[] values, int[] weights, int maxWeight)
            {
                var rowCount = values.Length;
                var V = new SubItem[rowCount + 1, maxWeight + 1];

                for (int i = 0; i < rowCount + 1; i++)
                    for (int j = 0; j < maxWeight + 1; j++)
                        V[i, j] = new SubItem();

                for (int j = 0; j < maxWeight + 1; j++)
                    V[0, j].TotalValue = 0;

                for (int i = 0; i < rowCount + 1; i++)
                    V[i, 0].TotalValue = 0;


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

                            var currValue = currItemValue + maxForRemainingCapacity.TotalValue;
                            
                            if(prevMaxValue.TotalValue > currValue)
                            {
                                V[i, j].TotalValue = prevMaxValue.TotalValue;
                                V[i, j].ItemList.AddRange(prevMaxValue.ItemList);
                            }
                            else if (currValue > prevMaxValue.TotalValue)
                            {
                                V[i, j].TotalValue = currValue;
                                V[i, j].ItemList.Add(i - 1);
                                V[i, j].ItemList.AddRange(maxForRemainingCapacity.ItemList);
                            }
                        }
                        else
                        {
                            V[i, j] = V[i - 1, j];
                        }

                        Print(V, rowCount, maxWeight);
                    }
                }

                var totalWeight = 0;
                foreach (var itemIndex in V[rowCount, maxWeight].ItemList.OrderBy(c => c))
                {
                    Debug.WriteLine($"Item index: {itemIndex}\t weight: {weights[itemIndex]}\t value: {values[itemIndex]}");
                    totalWeight += weights[itemIndex];
                }
                Debug.WriteLine($"Total weight: {totalWeight}. Total value: {V[rowCount, maxWeight].TotalValue}");


                return V[rowCount, maxWeight].TotalValue;
            }

            private static void Print(SubItem[,] V, int N, int W)
            {
                for (int i = 0; i < N + 1; i++)
                {
                    for (int j = 0; j < W + 1; j++)
                    {
                        Debug.Write(V[i, j].TotalValue + "\t");
                    }
                    Debug.WriteLine("");
                }

                Debug.WriteLine("");
                Debug.WriteLine("");
            }
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
