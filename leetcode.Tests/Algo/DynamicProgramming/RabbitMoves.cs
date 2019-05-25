using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace leetcode.Tests.Algo.DynamicProgramming
{
    public class RabbitMoves
    {
        [Theory]
        [InlineData(7, 2, 21)]
        public void Test(int stairs, int jumpLenght, int expected)
        {
            var s = new Solution();
            var actual = s.RabbitMoves(stairs, jumpLenght); // 7 - количество ступенек, 2 - максимальный прыжок
            Assert.Equal(expected, actual);
        }

        public class Solution
        {
            public int RabbitMoves(int n, int k)
            {
                int[] moves = new int[n + 1];
                moves[0] = 1;
                for (int i = 1; i <= n; i++)
                {
                    int start = Math.Max(0, i - k); // вычисление стартовой позиции
                    moves[i] = 0;
                    for (int j = start; j < i; j++)
                    {
                        moves[i] += moves[j];
                    }
                }

                return moves[n];
            }
        }
    }
}
