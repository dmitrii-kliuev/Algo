using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace Algo.Tests.leetcode
{
    public class KidsWithTheGreatestNumberOfCandies
    {
        [Theory]
        [InlineData(new int[] { 2, 3, 5, 1, 3 }, 3, new bool[] { true, true, true, false, true })]
        public void Test(int[] candies, int extraCandies, bool[] expected)
        {
            var actual = KidsWithCandies(candies, extraCandies);
            actual.Should().BeEquivalentTo(expected);
        }

        public IList<bool> KidsWithCandies(int[] candies, int extraCandies)
        {
            var result = new bool[candies.Length];

            var maxCandies = 0;
            for (int i = 0; i < candies.Length; i++)
            {
                if (candies[i] > maxCandies)
                    maxCandies = candies[i];
            }

            for (int i = 0; i < candies.Length; i++)
            {
                if(candies[i] + extraCandies >= maxCandies)
                {
                    result[i] = true;
                }
            }

            return result;
        }
    }
}
