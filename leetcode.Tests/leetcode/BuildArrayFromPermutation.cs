using FluentAssertions;
using Xunit;

namespace Algo.Tests.leetcode
{
    public class BuildArrayFromPermutation
    {
        [Theory]
        [InlineData(new int[] { 0, 2, 1, 5, 3, 4 }, new int[] { 0, 1, 2, 4, 5, 3 })]
        [InlineData(new int[] { 5, 0, 1, 2, 3, 4 }, new int[] { 4, 5, 0, 1, 2, 3 })]
        public void Test(int[] nums, int[] expected)
        {
            var result = BuildArrayWithEuclidsDivisionAlgorithm(nums);
            result.Should().BeEquivalentTo(expected);
        }

        public int[] BuildArray(int[] nums)
        {
            var ans = new int[nums.Length];
            for (var i = 0; i < nums.Length; i++)
            {
                ans[i] = nums[nums[i]];
            }

            return ans;
        }

        public int[] BuildArrayWithEuclidsDivisionAlgorithm(int[] nums)
        {
            int n = nums.Length;

            var q = n;

            for (int i = 0; i < n; i++)
            {
                var r = nums[i];

            /*
                retrieve correct value from potentially already processed element
                i.e. get r from something maybe already in the form a = qb + r
                if it isnt already processed (doesnt have qb yet), that's ok b/c
                r < q, so r % q will return the same value
            */
            var b = nums[nums[i]] % q;

            //put it all together
            nums[i] = q * b + r;

                // https://www.cuemath.com/numbers/euclids-division-algorithm/
            }

            for (int i = 0; i < n; i++)
            {
                var a = nums[i];
                nums[i] = a / q; //  // i = 0, nums[i] = 29, n = 6. nums[0] = 29 / 6 = 4
            }

            return nums;
        }
    }
}
