using System.Collections.Generic;
using System.Diagnostics;
using Xunit;

namespace Algo.Tests.Algo.Graphs
{
    public class GraphBfsDfs
    {
        [Fact]
        public void Test()
        {
            double[,] arr = {
                {0, 1, 1, 0},
                {0, 0, 1, 1},
                {1, 0, 0, 1},
                {0, 1, 0, 0}
            };

            Graph g = new Graph(arr);

            g.Bfs(1);

            g.Dfs(1);
        }

        [Fact]
        public void Graph_DFS_Non_recursive()
        {
            double[,] arr = {
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
            private readonly double[,] _matrix;
            private readonly int _n;

            public Graph(double[,] arr)
            {
                _matrix = arr;
                _n = arr.GetLength(0);
            }

            public void Bfs(int from)
            {
                bool[] visited = new bool[_n];
                Queue<int> turn = new Queue<int>();
                turn.Enqueue(from);
                visited[from] = true;
                while (turn.Count != 0)
                {
                    int index = turn.Dequeue();
                    Debug.WriteLine(index);

                    for (int i = 0; i < _n; i++)
                    {
                        // ReSharper disable once CompareOfFloatsByEqualityOperator
                        if (_matrix[index, i] != 0 && !visited[i])
                        {
                            visited[i] = true;
                            turn.Enqueue(i);
                        }
                    }
                }
            }

            public void Dfs(int from)
            {
                Dfs(from, new bool[_n]);
            }

            private void Dfs(int from, bool[] visited)
            {
                // bool[] visited = new bool[n];
                visited[from] = true;

                Debug.WriteLine(from);

                for (int i = 0; i < _n; i++)
                {
                    // ReSharper disable once CompareOfFloatsByEqualityOperator
                    if (_matrix[from, i] != 0 && !visited[i])
                        Dfs(i, visited);
                }
            }

            public void DFS_Non_recursive(int from)
            {
                bool[] visited = new bool[_n];
                Stack<int> stack = new Stack<int>();

                stack.Push(from);
                visited[from] = true;
                while (stack.Count != 0)
                {
                    int index = stack.Pop();
                    Debug.WriteLine(index);

                    for (int i = 0; i < _n; i++)
                    {
                        // ReSharper disable once CompareOfFloatsByEqualityOperator
                        if (_matrix[index, i] != 0 && !visited[i])
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
