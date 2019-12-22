using System.Collections.Generic;
using System.Diagnostics;
using Xunit;

namespace leetcode.Tests.Algo.Graphs
{
    public class Graph_BFS_DFS
    {
        [Fact]
        public void Test()
        {
            double[,] arr = new double[,]
            {
                {0, 1, 1, 0},
                {0, 0, 1, 1},
                {1, 0, 0, 1},
                {0, 1, 0, 0}
            };

            Graph g = new Graph(arr);

            g.BFS(1);

            //g.DFS(1);
        }

        [Fact]
        public void Graph_DFS_Non_recursive()
        {
            double[,] arr = new double[,]
            {
                {0, 1, 0, 0, 1},
                {1, 0, 1, 1, 0},
                {0, 1, 0, 0, 1},
                {0, 1, 0, 0, 1},
                {1, 0, 1, 1, 0}
            };

            //double[,] arr = new double[,]
            //{
            //    {0, 1, 1, 0},
            //    {0, 0, 1, 1},
            //    {1, 0, 0, 1},
            //    {0, 1, 0, 0}
            //};


            Graph g = new Graph(arr);

            g.DFS_Non_recursive(0);
        }

        private class Graph
        {
            private readonly double[,] matrix;
            private readonly int n;
            public Graph(int n)
            {
                matrix = new double[n, n];
                this.n = n;
            }

            public Graph(double[,] arr)
            {
                matrix = arr;
                this.n = arr.GetLength(0);
            }

            public void BFS(int from)
            {
                bool[] visited = new bool[n];
                Queue<int> turn = new Queue<int>();
                turn.Enqueue(from);
                visited[from] = true;
                while (turn.Count != 0)
                {
                    int index = turn.Dequeue();
                    Debug.WriteLine(index);

                    for (int i = 0; i < n; i++)
                    {
                        if (matrix[index, i] != 0 && !visited[i])
                        {
                            visited[i] = true;
                            turn.Enqueue(i);
                        }
                    }
                }
            }

            public void DFS(int from)
            {
                DFS(from, new bool[n]);
            }

            private void DFS(int from, bool[] visited)
            {
                // bool[] visited = new bool[n];
                visited[from] = true;

                Debug.WriteLine(from);

                for (int i = 0; i < n; i++)
                {
                    if (matrix[from, i] != 0 && !visited[i])
                        DFS(i, visited);
                }
            }

            public void DFS_Non_recursive(int from)
            {
                bool[] visited = new bool[n];
                Stack<int> stack = new Stack<int>();

                stack.Push(from);
                visited[from] = true;
                while (stack.Count != 0)
                {
                    int index = stack.Pop();
                    Debug.WriteLine(index);

                    for (int i = 0; i < n; i++)
                    {
                        if (matrix[index, i] != 0 && !visited[i])
                        {
                            stack.Push(i);
                            visited[i] = true;
                        }
                    }
                }

            }
        }
    }
}
