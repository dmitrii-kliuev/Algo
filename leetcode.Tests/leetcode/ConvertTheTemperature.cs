using FluentAssertions;
using Xunit;

namespace Algo.Tests.leetcode
{
    public class ConvertTheTemperature
    {
        [Theory]
        [InlineData(36.5, new double[] { 309.65000, 97.70000 })]
        public void Test(double celsius, double[] expected)
        {
            var actual = ConvertTemperature(celsius);
            actual.Should().BeEquivalentTo(expected);
        }

        public double[] ConvertTemperature(double celsius)
        {
            return new double[] 
            {
                celsius + 273.15,
                celsius * 1.80 + 32.00
            };
        }
    }
}
