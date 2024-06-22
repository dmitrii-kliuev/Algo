using Xunit;

namespace Algo.Tests.leetcode
{
    public class FindTheNumberOfGoodPairsI
    {
        [Theory]
        [InlineData(new int[] { 1, 3, 4 }, new int[] { 1, 3, 4 }, 1, 5)]
        [InlineData(new int[] { 1, 2, 4, 12 }, new int[] { 2, 4 }, 3, 2)]
        public void Test(int[] nums1, int[] nums2, int k, int expected)
        {
            var actual = NumberOfPairs(nums1, nums2, k);
            Assert.Equal(expected, actual);
        }

        public int NumberOfPairs(int[] nums1, int[] nums2, int k)
        {
            var res = 0;

            for (int i = 0; i < nums1.Length; i++)
            {
                for (int j = 0; j < nums2.Length; j++)
                {
                    if (nums1[i] % (nums2[j] * k) == 0)
                    {
                        res++;
                    }
                }
            }

            return res;
        }
    }
}
