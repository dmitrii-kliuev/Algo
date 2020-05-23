using System;
using Xunit;

namespace Algo.Tests.HackerRank
{
    public class NewYearChaos
    {
        [Fact]
        public void SolutionTest()
        {
            // arrange
            //var arr = new[] { 2, 1, 5, 3, 4 };
            var arr = new[] { 1, 2, 5, 3, 7, 8, 6, 4 };
            //var arr = new[] {2, 5, 1, 3, 4};

            // act
            Solution.MinimumBribes3(arr);

            // assert

        }

        public class Solution
        {

            public static void MinimumBribes(int[] q)
            {
                var totalBribes = 0;
                for (int i = 0; i < q.Length; i++)
                {
                    if (q[i] != i + 1)
                    {
                        var originalIdx = q[i] - 1;
                        var bribes = originalIdx - i;
                        if (bribes > 2)
                        {
                            Console.WriteLine("Too chaotic");
                            return;
                        }

                        if (bribes > 0)
                            totalBribes += bribes;
                    }
                }

                Console.WriteLine(totalBribes);
            }


            public static void MinimumBribes2(int[] q)
            {
                var totalBribes = 0;
                for (int i = 0; i < q.Length; i++)
                {
                    if (q[i] != i + 1)
                    {
                        var originalIdx = q[i] - 1;
                        var bribes = originalIdx - i;
                        if (bribes > 2)
                        {
                            Console.WriteLine("Too chaotic");
                            return;
                        }
                    }

                    for (int j = i; j < q.Length; j++)
                    {
                        if (q[i] > q[j])
                            totalBribes++;
                    }
                }

                Console.WriteLine(totalBribes);
            }

            public static void MinimumBribes3(int[] q)
            {
                var totalBribes = 0;
                for (int i = q.Length - 1; i >= 0; i--)
                {
                    if (q[i] != i + 1)
                    {
                        var originalIdx = q[i] - 1;
                        var bribes = originalIdx - i;
                        if (bribes > 2)
                        {
                            Console.WriteLine("Too chaotic");
                            return;
                        }
                    }

                    for (int j = Math.Max(0, q[i] - 2); j < i; j++)
                        if (q[j] > q[i]) totalBribes++;
                }

                Console.WriteLine(totalBribes);
            }

        }
    }
}
