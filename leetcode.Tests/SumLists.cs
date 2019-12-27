using leetcode.Tests.leetcode;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace leetcode.Tests
{
    public class SumLists
    {
        /*
            Sum Lists: You have two numbers represented by a linked list, where each node contains a single
            digit. The digits are stored in reverse order, such that the 1's digit is at the head of the list. Write a
            function that adds the two numbers and returns the sum as a linked list.
            EXAMPLE
            Input: (7-> 1 -> 6) + (5 -> 9 -> 2) . Thatis,617 + 295.
            Output: 2 -> 1 -> 9. That is, 912 .
            FOLLOW UP
            Suppose the digits are stored in forward order. Repeat the above problem.
            EXAMPLE
            Input: (6 -> 1 -> 7) + (2 -> 9 ->) 5). Thatis, 617 + 295.
            Output: 9 -> 1 -> 2. That is, 912
        */

        [Theory]
        [InlineData(new[] { 7, 1, 6 }, new[] { 5, 9, 2 }, new[] { 2, 1, 9 })]
        [InlineData(new[] { 7, 1, 6 }, new[] { 5, 9 }, new[] { 2, 1, 7 })]
        [InlineData(new[] { 5, 8 }, new[] { 2, 4, 5 }, new[] { 7, 2, 6 })]
        [InlineData(new[] { 9, 7, 8 }, new[] { 6, 8, 5 }, new[] { 5, 6, 4, 1 })]
        public void TestReversOrder(int[] firstArr, int[] secondArr, int[] expected)
        {
            var first = ListNode.FillList(firstArr);
            var second = ListNode.FillList(secondArr);

            var actual = SolutionReversOrder.Start(first, second);
            Assert.Equal(expected, actual);
        }

        private static class SolutionReversOrder
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

                if (carryOver != 0)
                    current.next = new ListNode(1);

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

#pragma warning disable CA1303 // Do not pass literals as localized parameters
                throw new Exception("first & second is null");
#pragma warning restore CA1303 // Do not pass literals as localized parameters
            }
        }

        [Theory]
        [InlineData(new[] { 6, 1, 7 }, new[] { 2, 9, 5 }, new[] { 9, 1, 2 })]
        [InlineData(new[] { 6, 1, 7, 8 }, new[] { 2, 9 }, new[] { 6, 2, 0, 7 })]
        public void TestForwardOrder(int[] firstArr, int[] secondArr, int[] expected)
        {
            var first = ListNode.FillList(firstArr);
            var second = ListNode.FillList(secondArr);

            var actual = SolutionForwardOrder.Start(first, second);
            Assert.Equal(expected, actual);
        }

        private static class SolutionForwardOrder
        {
            public static int[] Start(ListNode l1, ListNode l2)
            {
                var len1 = Length(l1);
                var len2 = Length(l2);

                if (len1 > len2)
                    l2 = PadList(l2, len1 - len2);
                else if (len2 > len1)
                    l1 = PadList(l1, len2 - len1);

                var sum = addListsHelper(l1, l2);

                if (sum.carry == 0)
                    return ListNode.LinkedListToList(sum.sum).ToArray();
                else
                    return ListNode.LinkedListToList(InsertBefore(sum.sum, sum.carry)).ToArray();
            }

            private static PartialSum addListsHelper(ListNode l1, ListNode l2)
            {
                if (l1 == null && l2 == null)
                    return new PartialSum();

                var sum = addListsHelper(l1.next, l2.next);

                var val = sum.carry + l1.val + l2.val;

                var full_result = InsertBefore(sum.sum, val % 10);

                sum.sum = full_result;
                sum.carry = val / 10;

                return sum;
            }

            private static ListNode PadList(ListNode lst, int len)
            {
                for (int i = 0; i < len; i++)
                    lst = InsertBefore(lst, 0);

                return lst;
            }

            private static ListNode InsertBefore(ListNode node, int val)
            {
                var head = new ListNode(val)
                {
                    next = node
                };

                return head;
            }

            private static int Length(ListNode node)
            {
                if (node == null) return 0;

                int i = 0;
                while (node != null)
                {
                    node = node.next;
                    i++;
                }

                return i;
            }

            private class PartialSum
            {
                public ListNode sum { get; set; }
                public int carry { get; set; }
            }
        }
    }
}
