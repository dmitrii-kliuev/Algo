using Xunit;

namespace Algo.Tests.leetcode
{
    public class SortArrayByParity
    {
        [Theory]
        [InlineData(new[] { 3, 1, 2, 4 })]
        [InlineData(new[] { 0, 1 })]
        [InlineData(new[] { 1, 2, 3, 4, 5, 6, 7, 8 })]
        [InlineData(new[] { 1, 1, 1 })]
        [InlineData(new[] { 2, 2, 2 })]
        public void Test(int[] arr)
        {
            var s = new Solution();
            var actual = s.SortArrayByParity(arr);

            var check = Check(actual);
            Assert.True(check);
        }

        private bool Check(int[] arr)
        {
            var isChecked = true;
            var evenPart = true;
            var oddPart = false;
            foreach (var a in arr)
            {
                if (!(evenPart && a % 2 == 0))
                {
                    evenPart = false;
                    oddPart = true;
                }

                if (oddPart && a % 2 == 0)
                {
                    isChecked = false;
                    break;
                }
            }

            return isChecked;
        }

        public class Solution
        {
            public int[] SortArrayByParity(int[] a)
            {
                var tailQty = 0;
                var tailIdx = 0;
                for (int i = 0; i < a.Length; i++)
                {
                    if (a[i] % 2 != 0)
                    {
                        tailIdx = FindTail(a, tailIdx);
                        if (i < tailIdx)
                        {
                            Swap(a, i, tailIdx);
                            tailQty++;
                        }
                    }

                    if (i + tailQty == a.Length - 1)
                        break;
                }

                return a;
            }

            private int FindTail(int[] arr, int tailIdx)
            {
                var maxIdx = tailIdx == 0 ? arr.Length - 1 : tailIdx - 1;

                for (int i = maxIdx; i >= 0; i--)
                    if (arr[i] % 2 == 0) return i;

                return 0;
            }

            private void Swap(int[] arr, int i, int j)
            {
                var tmp = arr[i];
                arr[i] = arr[j];
                arr[j] = tmp;
            }
        }

        public class SolutionFast
        {
            public int[] SortArrayByParity(int[] a)
            {
                int left = 0;
                int right = a.Length - 1;

                while (true)
                {
                    while (left < right && a[left] % 2 == 0)
                    {
                        left++;
                    }
                    while (left < right && a[right] % 2 != 0)
                    {
                        right--;
                    }
                    int temp = a[left];
                    a[left] = a[right];
                    a[right] = temp;

                    if (left >= right)
                    {
                        break;
                    }
                }
                return a;
            }
        }

        public class SolutionSlow
        {
            public int[] SortArrayByParity(int[] a)
            {
                var res = new int[a.Length];

                var pos = 0;
                for (int i = 0; i < a.Length; i++)
                {
                    if (a[i] % 2 == 0)
                    {
                        res[pos] = a[i];
                        pos++;
                    }
                }

                for (int i = 0; i < a.Length; i++)
                {
                    if (a[i] % 2 != 0)
                    {
                        res[pos] = a[i];
                        pos++;
                    }
                }

                return res;
            }
        }
    }
}
