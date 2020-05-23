using Xunit;

namespace Algo.Tests.Algo
{
    public class DivideAndConquer
    {
        [Theory]
        [InlineData(new[] { 2, 4, 6 }, 12, 6)]
        [InlineData(new[] { 2, 4, 6, 20, 50, 15, 10, 1, 4 }, 112, 50)]
        public void Test(int[] arr, int expected, int expectedMax)
        {

            var s = new Solution();
            var actual = s.Sum(arr, arr.Length - 1);
            Assert.Equal(expected, actual);

            var max = s.Max(arr, arr.Length - 1, arr[0]);
            Assert.Equal(expectedMax, max);
        }

        public class Solution
        {
            public int Sum(int[] arr, int i)
            {
                if (i == 0) return arr[0];

                var s = arr[i] + Sum(arr, --i);

                return s;
            }

            public int Max(int[] arr, int i, int max)
            {
                if (i > -1)
                {
                    max = arr[i] > max ? arr[i] : max;
                    max = Max(arr, --i, max);
                }

                return max;
            }
        }
    }
}
