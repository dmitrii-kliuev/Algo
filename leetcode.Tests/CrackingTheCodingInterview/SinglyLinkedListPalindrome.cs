using leetcode.Tests.leetcode;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace leetcode.Tests.CrackingTheCodingInterview
{
    public class SinglyLinkedListPalindrome
    {
        /*2.6 Palindrome: Implement a function to check if a linked list is a palindrome.*/

        #region ReverseListSolution
        [Theory]
        [InlineData(new int[] { 0, 1, 2, 1, 0 }, true)]
        [InlineData(new int[] { 0, 1, 1, 0 }, true)]
        [InlineData(new int[] { 0, 1, 2, 0 }, false)]
        [InlineData(new int[] { 0, 1, 1, 2 }, false)]
        [InlineData(new int[] { 1, 2, 3, 4, 5, 5, 4, 3, 2, 1 }, true)]
        public void Test_ReverseListSolution(int[] arr, bool expected)
        {
            var lst = ListNode.ArrayToList(arr);

            var actual = ReverseListSolution(lst);
            Assert.Equal(expected, actual);
        }

        private static bool ReverseListSolution(ListNode root)
        {
            var qty = 0;
            ListNode reversed = null;
            var src = root;
            while (src != null)
            {
                reversed = InsertBefore(reversed, src.val);
                src = src.next;

                qty++;
            }

            src = root;

            for (int i = 0; i < qty / 2; i++)
            {
                if (src.val != reversed.val)
                    return false;

                src = src.next;
                reversed = reversed.next;
            }

            return true;
        }

        private static ListNode InsertBefore(ListNode node, int val)
        {
            var newRoot = new ListNode(val)
            {
                next = node
            };
            return newRoot;
        }

        #endregion

        #region StackSolution
        [Theory]
        [InlineData(new int[] { 0, 1, 2, 1, 0 }, true)]
        [InlineData(new int[] { 0, 1, 1, 0 }, true)]
        [InlineData(new int[] { 0, 1, 2, 0 }, false)]
        [InlineData(new int[] { 0, 1, 1, 2 }, false)]
        [InlineData(new int[] { 1, 2, 3, 4, 5, 5, 4, 3, 2, 1 }, true)]
        public void Test_StackSolution(int[] arr, bool expected)
        {
            var lst = ListNode.ArrayToList(arr);

            var actual = StackSolution(lst);
            Assert.Equal(expected, actual);
        }

        private bool StackSolution(ListNode origin)
        {
            ListNode slow = origin;
            ListNode fast = origin;

            var stack = new Stack<int>();

            while (fast != null && fast.next != null)
            {
                stack.Push(slow.val);

                slow = slow.next;
                fast = fast.next.next;
            }

            if (fast != null) // if origin is odd
            {
                slow = slow.next;
            }

            while (slow != null)
            {
                var val = stack.Pop();

                if (val != slow.val)
                    return false;

                slow = slow.next;
            }

            return true;
        }

        #endregion

        #region recursive solution
        [Theory]
        [InlineData(new int[] { 0, 1, 2, 1, 0 }, true)]
        [InlineData(new int[] { 0, 1, 2, 3, 2, 1, 0 }, true)]
        [InlineData(new int[] { 0, 1, 1, 0 }, true)]
        [InlineData(new int[] { 0, 1, 2, 0 }, false)]
        [InlineData(new int[] { 0, 1, 1, 2 }, false)]
        [InlineData(new int[] { 1, 2, 3, 4, 5, 5, 4, 3, 2, 1 }, true)]
        public void Test_RecursiveSolution(int[] arr, bool expected) // Thank you Gayle Laakmann McDowell
        {
            var lst = ListNode.ArrayToList(arr);

            var actual = IsPalindrome(lst);
            Assert.Equal(expected, actual);
        }

        private bool IsPalindrome(ListNode node) // recursive solution
        {
            var length = GetLength(node);
            var p = isPalindromeRecurse(node, length);

            return p.result;
        }

        private Result isPalindromeRecurse(ListNode head, int length)
        {
            if (head == null || length == 0) // even
                return new Result(head, true);
            else if (length == 1) // odd
                return new Result(head.next, true);

            var res = isPalindromeRecurse(head.next, length - 2);

            if (!res.result || res.node == null) // if not is palindrome
                return res;

            res.result = head.val == res.node.val;

            res.node = res.node.next;

            return res;
        }

        private static int GetLength(ListNode node)
        {
            int i = 0;
            while (node != null)
            {
                i++;
                node = node.next;
            }

            return i;
        }

        private class Result
        {
            public ListNode node { get; set; }
            public bool result { get; set; }

            public Result(ListNode node, bool result)
            {
                this.node = node;
                this.result = result;
            }
        }

        #endregion
    }
}
