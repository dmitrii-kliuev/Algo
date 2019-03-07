using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace leetcode.Tests.leetcode
{
    public class FlippingAnImage
    {
        [Fact]
        public void Test()
        {
            var arr = new[]
            {
                new [] { 1, 1, 0 },
                new [] { 1, 0, 1 },
                new [] { 0, 0, 0 }
            };

            var arr0 = new[]
            {
                new [] { 1 }
            };

            /*
                Output      [[1,1,0],[0,0,0],[1,0,1]]
                Expected    [[1,0,0],[0,1,0],[1,1,1]]
            */

            var a0 = arr.GetLength(0);
            var a1 = arr[0].GetLength(0);

            var s = new Solution();

            var arr1 = new[] { 1, 2, 3 };
            ArrayReverse(arr1);

            var arr2 = new[] { 1, 2, 3, 4, 5, 6 };
            ArrayReverse(arr2);
           
            s.FlipAndInvertImage(arr);

            s.FlipAndInvertImage(arr0);
        }

        public class Solution
        {
            public int[][] FlipAndInvertImage(int[][] A)
            {
                for (int i = 0; i < A.GetLength(0); i++)
                    ArrayReverse(A[i]);

                return A;
            }

            public void ArrayReverse(int[] arr)
            {
                var left = 0;
                var right = arr.Length - 1;
                while (true)
                {

                    arr[left] = arr[left] == 0 ? 1 : 0;

                    if (left == right) break;

                    arr[right] = arr[right] == 0 ? 1 : 0;

                    var tmp = arr[left];
                    arr[left] = arr[right];
                    arr[right] = tmp;

                    left++;
                    right--;

                    if (left >= right)
                    {
                        if(left == right)
                            arr[left] = arr[left] == 0 ? 1 : 0;

                        break;
                    }
                        
                }
            }
        }

        public void ArrayReverse(int[] arr)
        {
            var left = 0;
            var right = arr.Length - 1;
            while (true)
            {
                var tmp = arr[left];
                arr[left] = arr[right];
                arr[right] = tmp;

                left++;
                right--;

                if (left >= right)
                    break;
            }
        }
    }
}
