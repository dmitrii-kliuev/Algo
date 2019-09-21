using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace leetcode.Tests
{
    public class SecondMinimum
    {
        [Theory]
        [InlineData(new int[] { 10, 15, 1, 5, 20, 2 }, 2)]
        //[InlineData(new int[] { 10, 15, 2, 5, 20, 1 }, 2)]
        public void test(int[] arr, int expected)
        {
            var actual = Solution.Start(arr);
            Assert.Equal(expected, actual);
        }

        static class Solution
        {
            public static int Start(int[] arr)
            {
                var first = arr[1];
                var second = arr[0];

                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] < first)
                    {
                        second = first;
                        first = arr[i];
                    }
                    else if(arr[i] < second && arr[i] != first)
                    {
                        second = arr[i];
                    }
                }

                return second;
            }
        }
    }
}
