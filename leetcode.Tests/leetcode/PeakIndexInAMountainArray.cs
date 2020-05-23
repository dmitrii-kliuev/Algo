using Xunit;

namespace Algo.Tests.leetcode
{
    public class PeakIndexInAMountainArray
    {
        [Theory]
        [InlineData(new[] { 0, 1, 0 }, 1)]
        [InlineData(new[] { 0, 2, 1, 0 }, 1)]
        public void Test(int[] arr, int expected)
        {
            var s = new Solution();
            var actual = s.PeakIndexInMountainArray(arr);
            Assert.Equal(expected, actual);
        }

        private class Solution
        {
            public int PeakIndexInMountainArray(int[] a)
            {
                var res = 0;
                if (a.Length < 3) return res;

                var prev = a[0];
                for (int i = 1; i < a.Length; i++)
                {
                    if (prev < a[i])
                    {
                        res = i;
                    }
                    else if (res != 0 && prev < a[i])
                    {
                        return 0;
                    }

                    prev = a[i];
                }

                return res;
            }
        }
    }
}
