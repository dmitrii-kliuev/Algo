using System.Collections.Generic;
using Xunit;

namespace Algo.Tests.leetcode
{
    public class SubtractTheProductAndSumOfDigitsOfAnInteger
    {
        [Theory]
        //[InlineData(234, 15)]
        [InlineData(705, -12)]
        public void Test(int n, int expected)
        {
            var actual = SubtractProductAndSum(n);
            Assert.Equal(expected, actual);
        }

        public int SubtractProductAndSum(int n)
        {
            var digits = new List<int>();

            while (n > 0)
            {
                var digit = n % 10;

                digits.Add(digit);

                n /= 10;
            }

            var product = digits[0];
            var sum = digits[0];
            for (int i = 1; i < digits.Count; i++)
            {
                sum += digits[i];
                product *= digits[i];
            }

            return product - sum;
        }
    }
}
