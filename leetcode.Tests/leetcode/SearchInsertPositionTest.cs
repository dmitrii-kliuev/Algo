using Xunit;

namespace Algo.Tests.leetcode
{
    public class SearchInsertPositionTest
    {
        [Theory]
        [InlineData(new[] { 1, 3, 5, 6 }, 5, 2)]
        [InlineData(new[] { 1, 3, 5, 6 }, 2, 1)]
        [InlineData(new[] { 1, 3, 5, 6 }, 7, 4)]
        [InlineData(new[] { 1, 3, 5, 6 }, 0, 0)]
        [InlineData(new int[0], 5, 0)]
        public void Test(int[] nums, int target, int expected)
        {
            var s = new Solution();
            var actual = s.SearchInsert(nums, target);
            Assert.Equal(expected, actual);
        }

        public class Solution
        {
            public int SearchInsert(int[] nums, int target)
            {
                var pos = 0;
                var len = nums.Length;

                if (len == 0 || target < nums[0])
                    return pos;

                if (nums[len - 1] < target)
                    return len;

                for (int i = len - 1; i >= 0; i--)
                {
                    if (nums[i] < target)
                        return i + 1;
                }

                return 0;
            }
        }
    }
}
