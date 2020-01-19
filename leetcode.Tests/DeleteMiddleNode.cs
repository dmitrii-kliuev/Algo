using leetcode.Tests.leetcode;
using Xunit;

namespace leetcode.Tests
{
    public class DeleteMiddleNode
    {
        /*  Delete Middle Node: Implement an algorithm to delete a node in the middle (i.e., any node but
            the first and last node, not necessarily the exact middle) of a singly linked list, given only access to
            that node.
            EXAMPLE
            Input: the node c from the linked list a - >b- >c - >d ->e- >f
            Result: nothing is returned, but the new linked list looks like a - >b- >d ->e- >f*/

        [Theory]
        [InlineData(new[] { 2, 1, 5, 4, 1, 4 }, new[] { 2, 1, 4, 1, 4 }, 2)]
        [InlineData(new[] { 2, 1, 5, 4, 1, 4 }, new[] { 2, 1, 5, 1, 4 }, 3)]
        [InlineData(new[] { 2, 1, 5, 4, 1, 4 }, new[] { 2, 5, 4, 1, 4 }, 1)]
        [InlineData(new[] { 2, 1, 5, 4, 1, 4 }, new[] { 2, 1, 5, 4, 1, 4 }, 5)] // last element
        [InlineData(new[] { 2, 1, 5, 4, 1, 4 }, new[] { 1, 5, 4, 1, 4 }, 0)] // first element. Because I can :)
        public void Test(int[] arr, int[] expected, int idx)
        {
            var root = ListNode.ArrayToList(arr);

            int i = 0;
            var current = root;
            while (current != null && i != idx)
            {
                current = current.next;
                i++;
            }

            Solution.Start(current);
            var actual = ListNode.LinkedListToList(root).ToArray();

            Assert.Equal(expected, actual);
        }

        static class Solution
        {
            public static void Start(ListNode current)
            {
                if (current == null || current.next == null) return;

                var tmp = current;
                while (current != null && current.next != null)
                {
                    tmp = current;
                    current = current.next;
                    tmp.val = current.val;
                }

                tmp.next = null;
            }
        }
    }
}
