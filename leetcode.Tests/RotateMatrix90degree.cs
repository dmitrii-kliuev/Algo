using System.Diagnostics;
using Xunit;

namespace Algo.Tests
{
    public class RotateMatrix90degree
    {
        private const int N = 4;

        [Fact]
        public void Test()
        {
            /*
                Rotate Matrix: Given an image represented by an NxN matrix, 
                where each pixel in the image is 4
                bytes, write a method to rotate the image by 90 degrees. (an you do this in place?
            */

            var matrix = new[]
            {
                new[]{ 1,  2,  3,  4 },
                new[]{ 5,  6,  7,  8 },
                new[]{ 9,  10, 11, 12 },
                new[]{ 13, 14, 15, 16 }
            };

            //var expected = new int[4][]
            //{
            //    new int[N]{ 13, 9,  5, 1 },
            //    new int[N]{ 14, 10, 6, 2 },
            //    new int[N]{ 15, 11, 7, 3 },
            //    new int[N]{ 16, 12, 8, 4 }
            //};

            Solution.Turn90deg(matrix, N);

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Debug.Write(matrix[i][j] + " ");
                }
                Debug.WriteLine("");
            }
        }

        public static class Solution
        {
            public static void Turn90deg(int[][] m, int n)
            {
                // t t t t r
                // l       r
                // l       r
                // l       r
                // l b b b b

                for (int layer = 0; layer < n / 2; layer++)
                {
                    int first = layer;
                    int last = n - layer - 1;

                    for (int i = first; i < last; i++)
                    {
                        int offset = i - first;

                        // save top
                        int top = m[first][i];

                        // left -> top
                        m[first][i] = m[last - offset][first];

                        // bottom -> left
                        m[last - offset][first] = m[last][last - offset];

                        // right -> bottom
                        m[last][last - offset] = m[i][last];

                        // top -> right
                        m[i][last] = top;
                    }
                }
            }
        }

    }
}
