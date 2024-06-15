using Xunit;

namespace Algo.Tests.leetcode
{
    public class ShuffleTheArray
    {
        /*
            Given the array nums consisting of 2n elements in the form [x1,x2,...,xn,y1,y2,...,yn].

            Return the array in the form [x1,y1,x2,y2,...,xn,yn].*/

        [Theory]
        [InlineData(new[] { 2, 5, 1, 3, 4, 7 }, 3, new[] { 2, 3, 5, 4, 1, 7 })]
        public void Test(int[] nums, int n, int[] expected)
        {
            var actual = Shuffle(nums, n);
            Assert.Equal(expected, actual);
        }

        public int[] Shuffle(int[] nums, int n)
        {
            var pointerOne = 0;
            var pointerTwo = n;
            
            var res = new int[nums.Length];
            for (int i = 0; i < nums.Length; i+=2)
            {
                res[i] = nums[pointerOne++];
                res[i + 1] = nums[pointerTwo++];
            }

            return res;
        }
    }
}
