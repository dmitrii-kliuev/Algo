using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace leetcode.Tests.leetcode
{
    public class CountingBits
    {
        /*
            https://leetcode.com/problems/counting-bits/

            Given a non negative integer number num. 
            For every numbers i in the range 0 ≤ i ≤ num calculate the number of 1's in their binary 
            representation and return them as an array.

            Example 1:

            Input: 2
            Output: [0,1,1]
            Example 2:

            Input: 5
            Output: [0,1,1,2,1,2]
            Follow up:

            It is very easy to come up with a solution with run time O(n*sizeof(integer)). But can you do it in linear time O(n) /possibly in a single pass?
            Space complexity should be O(n).
            Can you do it like a boss? Do it without using any builtin function like __builtin_popcount in c++ or in any other language.
         */

        [Theory]
        //[InlineData(2, new int[] { 0, 1, 1 })]
        [InlineData(5, new int[] { 0, 1, 1, 2, 1, 2 })]
        public void Test(int num, int[] expected)
        {
            var s = new Solution();
            var qwe0 = CountOnes0(5);
            var qwe1 = CountOnes1(232);

            var actual = s.CountBits(num);
            Assert.Equal(expected, actual);

            var iSol = new InterestingSolution();
            Assert.Equal(expected, iSol.CountBits(num));
        }

        public class Solution
        {
            public int[] CountBits(int num)
            {
                var res = new int[num + 1];

                for (int i = 0; i <= num; i++)
                {
                    var qty = CountOnes(i);
                    res[i] = qty;
                }

                return res;
            }

            public int CountOnes(int n)
            {
                int res = 0;
                while (n != 0)
                {
                    res++;
                    n &= n - 1;
                }
                return res;
            }
        }

        public class InterestingSolution
        {
            public int[] CountBits(int num)
            {
                int[] counts = new int[num + 1];
                for (int i = 0; i < num + 1; i++)
                {
                    int idx = i / 2;
                    int sum = i & 1;
                    counts[i] = counts[idx] + sum;
                }
                return counts;
            }
        }


        public int CountOnes0(int num)
        {
            int res = 0;
            while (num != 0)
            {
                res += num & 1;
                num >>= 1;
            }
            return res;
        }

        public int CountOnes1(int n)
        {
            int res = 0;
            while (n != 0)
            {
                res++;
                n &= n - 1;  // Забираем младшую единичку.
            }
            return res;
        }
    }
}
