using Xunit;

namespace Algo.Tests
{
    public class DominatorInAnArrayOfIntegers
    {
        /*a function that finds a value that occurs in more than half of the elements of an array.*/
        [Theory]
        [InlineData(new[] { 0, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 3, 3, 3, 4, 5 }, -1)]
        [InlineData(new[] { 1, 1, 2 }, 1)]
        [InlineData(new[] { 1, 2, 2 }, 2)]
        [InlineData(new[] { 1, 1, 2, 2 }, -1)]
        [InlineData(new[] { 1, 1, 2, 2, 2 }, 2)]
        [InlineData(new[] { 1 }, 1)]
        [InlineData(new[] { 1, 1 }, 1)]
        [InlineData(new[] { 1, 2 }, -1)]
        [InlineData(new int[] { }, -1)]
        public void Test(int[] arr, int expected)
        {
            var s = new Solution();
            var actual = s.solution(arr);
            Assert.Equal(expected, actual);
        }

        private class Solution
        {
            public int solution(int[] a)
            {
                int n = a.Length;
                int[] l = new int[n + 1];
                l[0] = -1;
                for (int i = 0; i < n; i++)
                {
                    l[i + 1] = a[i];
                }
                int count = 0;
                int pos = (n + 1) / 2;
                int candidate = l[pos];
                for (int i = 1; i <= n; i++)
                {
                    if (l[i] == candidate)
                        count = count + 1;
                }
                if (2 * count > n)
                    return candidate;
                return -1;
            }
        }
    }
}
