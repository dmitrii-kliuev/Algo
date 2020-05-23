using Algo.Tests.leetcode;
using System.Collections.Generic;
using Xunit;

namespace Algo.Tests.CrackingTheCodingInterview
{
    public class SinglyLinkedListPalindrome
    {
        /*2.6 Palindrome: Implement a function to check if a linked list is a palindrome.*/

        #region ReverseListSolution
        [Theory]
        [InlineData(new[] { 0, 1, 2, 1, 0 }, true)]
        [InlineData(new[] { 0, 1, 1, 0 }, true)]
        [InlineData(new[] { 0, 1, 2, 0 }, false)]
        [InlineData(new[] { 0, 1, 1, 2 }, false)]
        [InlineData(new[] { 1, 2, 3, 4, 5, 5, 4, 3, 2, 1 }, true)]
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
                if (reversed != null && src.val != reversed.val)
                    return false;

                src = src.next;
                reversed = reversed?.next;
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
        [InlineData(new[] { 0, 1, 2, 1, 0 }, true)]
        [InlineData(new[] { 0, 1, 1, 0 }, true)]
        [InlineData(new[] { 0, 1, 2, 0 }, false)]
        [InlineData(new[] { 0, 1, 1, 2 }, false)]
        [InlineData(new[] { 1, 2, 3, 4, 5, 5, 4, 3, 2, 1 }, true)]
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
        [InlineData(new[] { 0, 1, 2, 1, 0 }, true)]
        [InlineData(new[] { 0, 1, 2, 3, 2, 1, 0 }, true)]
        [InlineData(new[] { 0, 1, 1, 0 }, true)]
        [InlineData(new[] { 0, 1, 2, 0 }, false)]
        [InlineData(new[] { 0, 1, 1, 2 }, false)]
        [InlineData(new[] { 1, 2, 3, 4, 5, 5, 4, 3, 2, 1 }, true)]
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

            return p.Res;
        }

        private Result isPalindromeRecurse(ListNode head, int length)
        {
            if (head == null || length == 0) // even
                return new Result(head, true);
            if (length == 1) // odd
                return new Result(head.next, true);

            var res = isPalindromeRecurse(head.next, length - 2);

            if (!res.Res || res.Node == null) // if not is palindrome
                return res;

            res.Res = head.val == res.Node.val;

            res.Node = res.Node.next;

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
            public ListNode Node { get; set; }
            public bool Res { get; set; }

            public Result(ListNode node, bool res)
            {
                Node = node;
                Res = res;
            }
        }

        #endregion
    }
}
