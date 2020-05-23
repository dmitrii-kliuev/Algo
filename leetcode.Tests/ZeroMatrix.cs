using System.Diagnostics;
using Xunit;

namespace Algo.Tests
{
    public class ZeroMatrix
    {
        /*Zero Matrix: Write an algorithm such that if an element in an MxN matrix is 0, its entire row and
            column are set to O.*/
        [Fact]
        public void Test()
        {
            var arr = new[]
            {
                new[]{1, 1, 1, 0, 1, 1, 1, 1},
                new[]{1, 1, 1, 1, 1, 1, 1, 1},
                new[]{1, 1, 1, 1, 1, 0, 1, 1},
                new[]{1, 1, 1, 1, 1, 1, 1, 1},
                new[]{1, 1, 0, 1, 1, 1, 1, 1},
                new[]{1, 1, 1, 1, 1, 1, 1, 1},
                new[]{0, 1, 1, 1, 1, 1, 1, 1},
                new[]{1, 1, 1, 1, 1, 1, 1, 1},
                new[]{1, 1, 1, 1, 1, 1, 1, 1},
                new[]{1, 1, 1, 1, 1, 1, 1, 1}
            };

            Solution.Print(arr, 10, 8);

            GetActual(arr, 10, 8);

            var expected = new[]
            {
                new[]{0, 0, 0, 0, 0, 0, 0, 0},
                new[]{0, 1, 0, 0, 1, 0, 1, 1},
                new[]{0, 0, 0, 0, 0, 0, 0, 0},
                new[]{0, 1, 0, 0, 1, 0, 1, 1},
                new[]{0, 0, 0, 0, 0, 0, 0, 0},
                new[]{0, 1, 0, 0, 1, 0, 1, 1},
                new[]{0, 0, 0, 0, 0, 0, 0, 0},
                new[]{0, 1, 0, 0, 1, 0, 1, 1},
                new[]{0, 1, 0, 0, 1, 0, 1, 1},
                new[]{0, 1, 0, 0, 1, 0, 1, 1}
            };

            Debug.WriteLine("______________");
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Assert.Equal(expected[i][j], arr[i][j]);
                    Debug.Write($"{arr[i][j]}\t");
                }
                Debug.WriteLine("");
            }
        }

        private static void GetActual(int[][] arr, int r, int c)
        {
            Solution.Start(arr, r, c);
        }

        public static class Solution
        {
            public static void Start(int[][] arr, int r, int c)
            {
                if (arr == null) return;

                var firstColumnIsZero = false;
                // first column
                for (int i = 0; i < r; i++)
                {
                    if (arr[i][0] == 0)
                    {
                        firstColumnIsZero = true;
                        break;
                    }
                }

                var firstRowIsZero = false;
                // first row
                for (int j = 0; j < c; j++)
                {
                    if (arr[0][j] == 0)
                    {
                        firstRowIsZero = true;
                        break;
                    }
                }

                for (int i = 1; i < r; i++)
                {
                    for (int j = 1; j < c; j++)
                    {
                        if (arr[i][j] == 0)
                        {
                            arr[i][0] = 0;
                            arr[0][j] = 0;
                        }

                    }
                }

                // process columns
                for (int j = 1; j < c; j++)
                {
                    if (arr[0][j] == 0)
                    {
                        for (int i = 1; i < r; i++)
                        {
                            arr[i][j] = 0;
                        }
                    }
                }

                // process rows
                for (int i = 0; i < r; i++)
                {
                    if (arr[i][0] == 0)
                    {
                        for (int j = 1; j < c; j++)
                        {
                            arr[i][j] = 0;
                        }
                    }
                }

                // process first column
                if (firstColumnIsZero)
                {
                    for (int i = 0; i < r; i++)
                    {
                        arr[i][0] = 0;
                    }
                }

                // process first row
                if (firstRowIsZero)
                {
                    for (int j = 0; j < c; j++)
                    {
                        arr[0][j] = 0;
                    }
                }

                Print(arr, r, c);
            }

            public static void Print(int[][] arr, int r, int c)
            {
                if (arr == null) return;
                for (int i = 0; i < r; i++)
                {
                    for (int j = 0; j < c; j++)
                    {
                        Debug.Write($"{arr[i][j]}\t");
                    }

                    Debug.WriteLine("");
                }
            }
        }

    }
}
