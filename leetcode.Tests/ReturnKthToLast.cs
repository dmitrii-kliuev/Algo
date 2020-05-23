using Algo.Tests.leetcode;
using System;
using Xunit;

namespace Algo.Tests
{
    public class ReturnKthToLast
    {
        /*Return Kth to Last: Implement an algorithm to find the kth to last element of a singly linked list.*/

        [Theory]
        [InlineData(new[] { 2, 1, 5, 4, 1, 4 }, 2, 1)]
        [InlineData(new[] { 2, 1, 5, 4, 1, 4 }, 3, 4)]
        public void TestWithLength(int[] arr, int k, int expected)
        {
            var root = ListNode.ArrayToList(arr);

            var actual = SolutionWithLength.Start(root, k);
            Assert.Equal(expected, actual);
        }

        private static class SolutionWithLength
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

                if (current != null) return current.val;

                throw new Exception();
            }
        }

        [Theory]
        [InlineData(new[] { 2, 1, 5, 4, 1, 4 }, 2, 1)]
        [InlineData(new[] { 2, 1, 5, 4, 1, 4 }, 3, 4)]
        public void TestWithStack(int[] arr, int k, int expected)
        {
            var root = ListNode.ArrayToList(arr);

            var actual = SolutionWithStack.Start(root, k);
            Assert.Equal(expected, actual);
        }

        private class SolutionWithStack
        {
            public static int Start(ListNode root, int k)
            {
                if (root == null) throw new Exception("root is null");

                var current = root;
                var s = new MyStack<int>();
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
            var root = ListNode.ArrayToList(arr);

            var actual = SolutionWithTwoPointers.Start(root, k);
            Assert.Equal(expected, actual);
        }

        private class SolutionWithTwoPointers
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
            var root = ListNode.ArrayToList(arr);

            var actual = SolutionWithRecursion.Start(root, k);
            Assert.Equal(expected, actual);
        }

        private class SolutionWithRecursion
        {
            private static int _i;
            private static int _result;

            public static int Start(ListNode root, int k)
            {
                _i = 0;
                _result = 0;

                if (root == null) throw new Exception("root is null");

                Find(root, k);
                return _result;
            }

            private static void Find(ListNode root, int k)
            {
                if (root == null)
                    return;

                Find(root.next, k);
                if (++_i == k)
                    _result = root.val;
            }
        }
    }


}
