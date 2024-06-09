using System;
using System.Collections;
using Xunit;

namespace Algo.Tests.leetcode
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
        [InlineData(5, new[] { 0, 1, 1, 2, 1, 2 })]
        public void Test(int num, int[] expected)
        {
            var s = new Solution();
            CountOnes0(5);
            CountOnes1(232);

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
                    // 0001
                    // 0010
                    // 0011
                    // 0100
                    // 0101
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

    public class Test
    {
        public void TestMethod()
        {
            Pigeon b = new Pigeon();
            b.Fly();
        }
    }

    public class Bird
    {
        public void BirdVoice() { }
    }

    public class FlyingBird : Bird
    {
        public void Fly() { }
    }

    public class Pigeon : FlyingBird { }

    public class Ostrich : Bird { }

    internal sealed class Alala<T> where T : new()
    {
        ArrayList gg = new ArrayList();

        public void Asd()
        {
            gg.Add(new object());
            gg.Add(new Exception());
            Type t1 = 1.GetType();
        }

        public static T asads()
        {
            return new T();
        }
    }

    public class TestRefOut
    {
        void method2(ref int a, out int b)
        {
            b = 12;
            a = 10 + b;
        }

        void method1()
        {
            int a = 1;
            int b = 5;
            method2(ref a, out b);
        }
    }
}
