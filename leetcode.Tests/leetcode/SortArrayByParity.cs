using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace leetcode.Tests.leetcode
{
    public class SortArrayByParity
    {
        [Theory]
        [InlineData(new[] { 3, 1, 2, 4 }, new[] { 2, 4, 3, 1 })]
        [InlineData(new[] { 0, 1 }, new[] { 0, 1 })]
        public void Test(int[] arr, int[] expected)
        {
            var s = new Solution();
            var actual = s.SortArrayByParity(arr);
            Assert.Equal(expected, actual);
        }

        public class Solution
        {
            public int[] SortArrayByParity(int[] A)
            {
                var tailQty = 0;
                var tailIdx = 0;
                for (int i = 0; i < A.Length; i++)
                {
                    if (A[i] % 2 != 0)
                    {
                        tailIdx = FindTail(A, tailIdx);
                        if (i < tailIdx)
                        {
                            Swap(A, i, tailIdx);
                            tailQty++;
                        }
                    }

                    if (i + tailQty == A.Length - 1)
                        break;
                }

                return A;
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
            public int[] SortArrayByParity(int[] A)
            {
                int left = 0;
                int right = A.Length - 1;

                while (true)
                {
                    while (left < right && A[left] % 2 == 0)
                    {
                        left++;
                    }
                    while (left < right && A[right] % 2 != 0)
                    {
                        right--;
                    }
                    int temp = A[left];
                    A[left] = A[right];
                    A[right] = temp;

                    if (left >= right)
                    {
                        break;
                    }
                }
                return A;
            }
        }

        public class SolutionSlow
        {
            public int[] SortArrayByParity(int[] A)
            {
                var res = new int[A.Length];

                var pos = 0;
                for (int i = 0; i < A.Length; i++)
                {
                    if (A[i] % 2 == 0)
                    {
                        res[pos] = A[i];
                        pos++;
                    }
                }

                for (int i = 0; i < A.Length; i++)
                {
                    if (A[i] % 2 != 0)
                    {
                        res[pos] = A[i];
                        pos++;
                    }
                }

                return res;
            }
        }
    }
}
