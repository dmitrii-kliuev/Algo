using Xunit;

namespace Algo.Tests.leetcode
{
    public class DivisibleAndNonDivisibleSumsDifference
    {
        [Theory]
        [InlineData(10, 3, 19)]
        public void Test(int n, int m, int expected)
        {
            var actual = DifferenceOfSums(n, m);
            Assert.Equal(expected, actual);
        }

        public int DifferenceOfSums(int n, int m)
        {
            var num1 = 0;
            var num2 = 0;

            for (var i = 1; i <= n; i++)
            {
                if (i % m != 0)
                {
                    num1 += i;
                }
                else
                {
                    num2 += i;
                }
            }

            return num1 - num2;
        }
    }
}
