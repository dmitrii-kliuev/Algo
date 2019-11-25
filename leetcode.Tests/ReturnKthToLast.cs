using leetcode.Tests.leetcode;
using System;
using Xunit;
using static leetcode.Tests.leetcode.ImplementStackUsingQueues;

namespace leetcode.Tests
{
    public class ReturnKthToLast
    {
        /*Return Kth to Last: Implement an algorithm to find the kth to last element of a singly linked list.*/

        [Theory]
        [InlineData(new[] { 2, 1, 5, 4, 1, 4 }, 2, 1)]
        [InlineData(new[] { 2, 1, 5, 4, 1, 4 }, 3, 4)]
        public void TestWithLength(int[] arr, int k, int expected)
        {
            var root = ListNode.FillList(arr);

            var actual = SolutionWithLength.Start(root, k);
            Assert.Equal(expected, actual);
        }

        static class SolutionWithLength
        {
            public static int Start(ListNode root, int k)
            {
                if (root == null) throw new Exception("root is null");
                var current = root;

                var len = 0;
                while (current != null)
                {
                    current = current.next;
                    len++;
                }

                var i = 0;
                current = root;
                while (current != null && i < len - k)
                {
                    current = current.next;
                    i++;
                }

                return current.val;
            }
        }

        [Theory]
        [InlineData(new[] { 2, 1, 5, 4, 1, 4 }, 2, 1)]
        [InlineData(new[] { 2, 1, 5, 4, 1, 4 }, 3, 4)]
        public void TestWithStack(int[] arr, int k, int expected)
        {
            var root = ListNode.FillList(arr);

            var actual = SolutionWithStack.Start(root, k);
            Assert.Equal(expected, actual);
        }

        class SolutionWithStack
        {
            public static int Start(ListNode root, int k)
            {
                if (root == null) throw new Exception("root is null");

                var current = root;
                var s = new MyStack();
                while (current != null)
                {
                    s.Push(current.val);
                    current = current.next;
                }

                for (int i = 0; i < k - 1; i++)
                    s.Pop();

                return s.Top();
            }
        }

        [Theory]
        [InlineData(new[] { 2, 1, 5, 4, 1, 4 }, 2, 1)]
        [InlineData(new[] { 2, 1, 5, 4, 1, 4 }, 3, 4)]
        public void TestWithTwoPointers(int[] arr, int k, int expected)
        {
            var root = ListNode.FillList(arr);

            var actual = SolutionWithTwoPointers.Start(root, k);
            Assert.Equal(expected, actual);
        }

        class SolutionWithTwoPointers
        {
            public static int Start(ListNode root, int k)
            {
                if (root == null) throw new Exception("root is null");

                var slow = root;
                var fast = root;

                for (int i = 0; i < k; i++)
                    fast = fast.next;

                while (fast != null)
                {
                    slow = slow.next;
                    fast = fast.next;
                }

                return slow.val;
            }
        }

        [Theory]
        [InlineData(new[] { 2, 1, 5, 4, 1, 4 }, 2, 1)]
        [InlineData(new[] { 2, 1, 5, 4, 1, 4 }, 3, 4)]
        public void TestWithRecursion(int[] arr, int k, int expected)
        {
            var root = ListNode.FillList(arr);

            var actual = SolutionWithRecursion.Start(root, k);
            Assert.Equal(expected, actual);
        }

        class SolutionWithRecursion
        {
            static int i;
            static int result;

            public static int Start(ListNode root, int k)
            {
                i = 0;
                result = 0;

                if (root == null) throw new Exception("root is null");

                Find(root, k);
                return result;
            }

            public static void Find(ListNode root, int k)
            {
                if (root == null)
                    return;

                Find(root.next, k);
                if (++i == k)
                    result = root.val;
            }
        }
    }


}
