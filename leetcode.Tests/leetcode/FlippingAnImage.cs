using Xunit;

namespace Algo.Tests.leetcode
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
            public int[][] FlipAndInvertImage(int[][] a)
            {
                for (int i = 0; i < a.GetLength(0); i++)
                    ArrayReverse(a[i]);

                return a;
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
                        if (left == right)
                            arr[left] = arr[left] == 0 ? 1 : 0;

                        break;
                    }

                }
            }
        }

        private void ArrayReverse(int[] arr)
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
