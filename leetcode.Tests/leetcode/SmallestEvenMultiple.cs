using Xunit;

namespace Algo.Tests.leetcode
{
    public class SmallestEvenMultipleSolution
    {
        [Theory]
        [InlineData(5, 10)]
        [InlineData(6, 6)]
        public void Test(int n, int expected)
        {
            var actual = SmallestEvenMultiple(n);
            Assert.Equal(expected, actual);
        }

        public int SmallestEvenMultiple(int n)
        {
            if (n % 2 == 0)
                return n;

            return 2 * n;
        }
    }
}
