using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace leetcode.Tests.Algo.DynamicProgramming
{
    public class Knapsack
    {
        [Fact]
        public void Test()
        {
            var res = GFG.Start();

            var t = Knapsack1.Start();
        }


        /* https://www.geeksforgeeks.org/0-1-knapsack-problem-dp-10/
         * A Naive recursive implementation of  
            0-1 Knapsack problem */
        class GFG
        {
            // Driver function 
            public static int Start()
            {
                //int[] val = new int[] { 60, 100, 120 };     // value. цены
                //int[] wt = new int[] { 10, 20, 30 };        // weight. вес каждого
                //int W = 50;                                 // максимальный вес рюкзака
                //int n = val.Length;
                //  гитара, магнитофон, ноутбук
                int[] val = new int[] { 1500, 3000, 2000 };     // value. цена
                int[] wt = new int[] { 1, 4, 3 };        // weight. вес
                int W = 4;                                              // максимальный вес рюкзака
                int n = val.Length;

                var res = knapSack(W, wt, val, n);
                return res;
            }


            // A utility function that returns 
            // maximum of two integers 
            static int max(int a, int b)
            {
                return (a > b) ? a : b;
            }

            // Returns the maximum value that can  
            // be put in a knapsack of capacity W 
            static int knapSack(int W, int[] wt,
                                int[] val, int n)
            {

                // Base Case 
                if (n == 0 || W == 0)
                    return 0;

                // If weight of the nth item is  
                // more than Knapsack capacity W, 
                // then this item cannot be  
                // included in the optimal solution 
                if (wt[n - 1] > W)
                    return knapSack(W, wt, val, n - 1);

                // Return the maximum of two cases:  
                // (1) nth item included  
                // (2) not included 
                else return max(val[n - 1] + knapSack(W - wt[n - 1], wt, val, n - 1),
                           knapSack(W, wt, val, n - 1));
            }
        }
    }

    // good video https://www.dyclassroom.com/dynamic-programming/0-1-knapsack-problem

    class Knapsack1
    {
        // https://www.hackerearth.com/ru/practice/notes/the-knapsack-problem/
        public static int Start()
        {

            var val = new[] { 10, 40, 30, 50 };

            var wt = new[] { 5, 4, 6, 3 };

            int W = 10;

            var res = knapsack(val, wt, W);

            return res;
        }



        public static int knapsack(int[] val, int[] wt, int W)
        {

            //Get the total number of items.

            //Could be wt.length or val.length. Doesn't matter

            int N = wt.Length;


            //Create a matrix.

            //Items are in rows and weight at in columns +1 on each side

            int[,] V = new int[N + 1, W + 1];

            //What if the knapsack's capacity is 0 - Set

            //all columns at row 0 to be 0

            for (int col = 0; col <= W; col++)
            {

                V[0, col] = 0;

            }



            //What if there are no items at home.

            //Fill the first row with 0
            for (int row = 0; row <= N; row++)
            {

                V[row, 0] = 0;
            }

            for (int item = 1; item <= N; item++)
            {


                //Let's fill the values row by row

                for (int weight = 1; weight <= W; weight++)
                {

                    //Is the current items weight less

                    //than or equal to running weight

                    if (wt[item - 1] <= weight)
                    {

                        //Given a weight, check if the value of the current

                        //item + value of the item that we could afford

                        //with the remaining weight is greater than the value

                        //without the current item itself

                        V[item, weight] = Math.Max(val[item - 1] + V[item - 1, weight - wt[item - 1]], V[item - 1, weight]);
                    }

                    else
                    {

                        //If the current item's weight is more than the

                        //running weight, just carry forward the value

                        //without the current item

                        V[item, weight] = V[item - 1, weight];
                    }
                }

            }

            //Printing the matrix

            //foreach (var rows in V)
            //{

            //    foreach (int col in rows)
            //    {

            //        System.out.format("%5d", col);
            //    }
            //    System.out.println();
            //}

            return V[N, W];

        }

    }
}
