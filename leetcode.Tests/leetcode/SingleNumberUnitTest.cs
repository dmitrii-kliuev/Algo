using Xunit;

namespace Algo.Tests.leetcode
{
    public class SingleNumberUnitTest
    {
        [Theory]
        //[InlineData(new int[] {2, 2, 1 }, 1)]
        //[InlineData(new int[] { 4, 1, 2, 1, 2 }, 4)]
        //[InlineData(new int[] { 1, 0, 1 }, 0)]
        [InlineData(new[] { 1, 3, 1, -1, 3 }, -1)]
        public void SingleNumber_SulutionTest(int[] nums, int target)
        {
            // arrange
            var s = new Solution2();

            // act
            var actual = s.SingleNumber(nums);

            // assert
            Assert.Equal(target, actual);
        }

        public class Solution
        {
            public int SingleNumber(int[] nums)
            {
                for (int i = 0; i < nums.Length; i++)
                {
                    var curr = nums[i];

                    if (i == nums.Length - 1)
                        return curr;

                    for (int j = 0; j < nums.Length; j++)
                    {
                        if (curr == nums[j] && i != j)
                        {
                            break;
                        }

                        if (j == nums.Length - 1 && curr != nums[j])
                            return curr;
                    }
                }

                return -1;
            }
        }

        public class Solution2
        {
            /*
             4, 1, 2, 1, 2
             0100
             0001
             0010
             0001
             0010
                 */

            /*
             1, 3, 1, -1, 3
             0001
             0011
             0001
             1111
             0011
             =
             1111
                 */

            public int SingleNumber(int[] nums)
            {
                var n = 0;
                for (var i = 0; i < nums.Length; i++)
                {
                    n ^= nums[i];
                }
                return n;
            }
        }
    }
}
