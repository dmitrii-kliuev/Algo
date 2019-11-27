using leetcode.Tests.leetcode;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace leetcode.Tests
{
    public class SumLists
    {
        [Theory]
        [InlineData(new[] { 7, 1, 6 }, new[] { 5, 9, 2 }, new[] { 2, 1, 9 })]
        [InlineData(new[] { 7, 1, 6 }, new[] { 5, 9 }, new[] { 2, 1, 7 })]
        [InlineData(new[] { 5, 8 }, new[] { 2, 4, 5 }, new[] { 7, 2, 6 })]
        public void TestReversOrder(int[] firstArr, int[] secondArr, int[] expected)
        {
            var first = ListNode.FillList(firstArr);
            var second = ListNode.FillList(secondArr);

            var actual = SolutionReversOrder.Start(first, second);
            Assert.Equal(expected, actual);
        }

        static class SolutionReversOrder
        {
            public static int[] Start(ListNode first, ListNode second)
            {
                ListNode resultRoot = null;
                ListNode current = null;
                var carryOver = 0;
                while (first != null || second != null)
                {
                    int val = NextValue(first, second, ref carryOver);
                    if (resultRoot == null)
                    {
                        resultRoot = new ListNode(val);
                        current = resultRoot;
                    }
                    else
                    {
                        current.next = new ListNode(val);
                        current = current.next;
                    }

                    if (first != null) first = first.next;
                    if (second != null) second = second.next;
                }

                return ListNode.LinkedListToList(resultRoot).ToArray();
            }

            private static int NextValue(ListNode first, ListNode second, ref int carryOver)
            {
                var val = 0;
                if (first != null && second != null)
                    val = first.val + second.val + carryOver;
                else if (second == null)
                    val = first.val + carryOver;
                else if (first == null)
                    val = second.val + carryOver;

                if (val > 9)
                {
                    carryOver = 1;
                    val -= 10;
                }
                else
                    carryOver = 0;

                return val;

                throw new Exception("first & second is null");
            }
        }


        [Theory]
        [InlineData(new[] { 7, 1, 6 }, new[] { 5, 9, 2 }, new[] { 2, 1, 9 })]
        [InlineData(new[] { 7, 1, 6 }, new[] { 5, 9 }, new[] { 2, 1, 7 })]
        [InlineData(new[] { 5, 8 }, new[] { 2, 4, 5 }, new[] { 7, 2, 6 })]
        public void TestForwardOrder(int[] firstArr, int[] secondArr, int[] expected)
        {
            var first = ListNode.FillList(firstArr);
            var second = ListNode.FillList(secondArr);

            var actual = SolutionForwardOrder.Start(first, second);
            Assert.Equal(expected, actual);
        }

        static class SolutionForwardOrder
        {
            public static int[] Start(ListNode first, ListNode second)
            {
                return null;
            }
        }
    }
}
