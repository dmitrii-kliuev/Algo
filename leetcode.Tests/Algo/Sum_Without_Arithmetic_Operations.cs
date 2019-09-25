using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace leetcode.Tests.Algo
{
    public class Sum_Without_Arithmetic_Operations
    {
        [Theory]
        [InlineData(0b_1001, 0b_0011, 0b_1100)]
        [InlineData(0b_1101, 0b_0111, 0b_10100)]
        public void TestRecursive(int a, int b, int expected)
        {
            var actual = Solution.SumRecursive(a, b);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(0b_1001, 0b_0011, 0b_1100)]
        //[InlineData(0b_1101, 0b_0111, 0b_10100)]
        public void Test(int a, int b, int expected)
        {
            var actual = Solution.Sum(a, b);
            Assert.Equal(expected, actual);
        }

        static class Solution
        {
            public static int Sum(int a, int b)
            {
                while(b != 0)
                {
                    int partialSum = a ^ b;
                    b = (a & b) << 1;

                    a = partialSum;
                }

                return a;
            }

            public static int SumRecursive(int a, int b)
            {
                if (b == 0) return a;
                int partialSum = a ^ b;
                int carry = (a & b) << 1;

                return SumRecursive(partialSum, carry);
            }
        }
    }
}
