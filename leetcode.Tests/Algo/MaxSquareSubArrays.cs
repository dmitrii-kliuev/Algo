using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using Xunit;

namespace leetcode.Tests.Algo
{
    public class MaxSquareSubArrays
    {
        [Fact]
        public void Test0()
        {
            var arr = new int[][]
            {
                new int[]{ 1, 1, 1, 0 },
                new int[]{ 1, 1, 1, 0 },
                new int[]{ 1, 1, 1, 0 },
                new int[]{ 0, 0, 0, 0 }
            };

            Assert.Equal(expected: 3, actual: Solution.Start(arr));
        }

        [Fact]
        public void Test1()
        {
            var arr = new int[][]
            {
                new int[]{ 1, 1, 1, 0, 1, 1, 1, 1 },
                new int[]{ 1, 1, 1, 0, 1, 1, 1, 1 },
                new int[]{ 1, 1, 1, 0, 1, 1, 1, 1 },
                new int[]{ 0, 0, 0, 0, 1, 1, 1, 1 }
            };

            Assert.Equal(expected: 4, actual: Solution.Start(arr));
        }

        [Fact]
        public void Test2()
        {
            var arr = new int[][]
            {
                new int[]{ 0, 0, 0, 0, 0, 0, 0, 0 },
                new int[]{ 0, 0, 0, 0, 0, 0, 0, 0 },
                new int[]{ 0, 0, 1, 1, 0, 0, 0, 0 },
                new int[]{ 0, 0, 1, 1, 0, 0, 0, 0 },
                new int[]{ 0, 0, 0, 0, 0, 0, 0, 0 },
                new int[]{ 0, 0, 0, 0, 0, 0, 0, 0 },
                new int[]{ 0, 0, 0, 0, 0, 0, 0, 0 },
                new int[]{ 0, 0, 0, 0, 1, 1, 1, 0 },
                new int[]{ 0, 0, 0, 0, 1, 1, 1, 0 },
                new int[]{ 0, 0, 0, 0, 1, 1, 1, 0 },
                new int[]{ 0, 0, 0, 0, 0, 0, 0, 0 }
            };

            Assert.Equal(expected: 3, actual: Solution.Start(arr));
        }

        [Fact]
        public void Test3()
        {
            var arr = new int[][]
            {
                new int[]{ 0, 0, 0, 0, 0, 0, 0, 0 },
                new int[]{ 0, 0, 0, 0, 0, 0, 0, 0 },
                new int[]{ 0, 0, 1, 1, 1, 0, 0, 0 },
                new int[]{ 0, 0, 1, 1, 1, 0, 0, 0 },
                new int[]{ 0, 0, 1, 1, 1, 0, 0, 0 },
                new int[]{ 0, 0, 0, 0, 0, 0, 0, 0 },
                new int[]{ 0, 0, 0, 0, 0, 0, 0, 0 },
                new int[]{ 0, 1, 1, 0, 1, 1, 1, 0 },
                new int[]{ 0, 1, 1, 0, 1, 1, 1, 0 },
                new int[]{ 0, 0, 0, 0, 1, 1, 1, 0 },
                new int[]{ 0, 0, 0, 0, 0, 0, 0, 0 }
            };

            Assert.Equal(expected: 3, actual: Solution.Start(arr));
        }

        class maximum
        {
            public Point TopLeft { get; set; }
            public Point BottomRight { get; set; }
            public int Size { get; set; }
        }


        static class Solution
        {
            public static int Start(int[][] arr)
            {

                var x = arr.GetLength(0);
                if (x == 0) throw new Exception("0 dimension length is 0");

                var y = arr[0].GetLength(0);
                if (y == 0) throw new Exception("1 dimension length is 0");

                var sizes = new int[x, y];

                var max = 0;

                var mStack = new Stack<maximum>();

                for (int i = 0; i < x; i++)
                {
                    for (int j = 0; j < y; j++)
                    {
                        if (i == 0 || j == 0)
                            sizes[i, j] = arr[i][j];
                        else if (arr[i][j] == 1)
                            sizes[i, j] = Math.Min(Math.Min(
                                                            sizes[i - 1, j - 1],
                                                            sizes[i - 1, j]),
                                                            sizes[i, j - 1]) + 1;
                        Debug.Write($"{sizes[i, j]} ");


                        if (sizes[i, j] >= max)
                        {
                            max = sizes[i, j];

                            var m = new maximum
                            {
                                BottomRight = new Point(i, j),
                                TopLeft = new Point(i - (max - 1), j - (max - 1)),
                                Size = max
                            };

                            mStack.Push(m);
                        }

                    }

                    Debug.WriteLine("");
                }


                while (mStack.Count != 0)
                {
                    var curr = mStack.Pop();

                    if (curr.Size == max)
                    {
                        Debug.WriteLine($"topLeft: {curr.TopLeft.ToString()}");
                        Debug.WriteLine($"bottomRight: {curr.BottomRight.ToString()}");
                    }
                }

                return max;
            }
        }

    }
}
