using Xunit;

namespace Algo.Tests.leetcode
{
    public class FindMinimumOperationsToMakeAllElementsDivisibleByThree
    {
        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4 }, 3)]
        public void Test(int[] nums, int expected)
        {
            var actual = MinimumOperations(nums);
            Assert.Equal(expected, actual);
        }

        public int MinimumOperations(int[] nums)
        {
            var result = 0;
            for (var i = 0; i < nums.Length; i++)
            {
                var mod = nums[i] % 3;
                if (mod != 0)
                {
                    result++;
                }
            }

            return result;
        }
    }
}
