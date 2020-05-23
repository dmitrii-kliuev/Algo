using System.Linq;
using Xunit;

namespace Algo.Tests.leetcode
{
    public class ReverseLinkedList
    {
        [Theory]
        [InlineData(new[] { 1, 2, 3, 4, 5 }, new[] { 5, 4, 3, 2, 1 })]
        public void Test(int[] arr, int[] expected)
        {
            var l = ListNode.ArrayToList(arr);
            var s = new Solution();
            var actual = s.ReverseList(l);
            var actualList = ListNode.LinkedListToList(actual);
            Assert.Equal(expected.ToList(), actualList);
        }

        /**
         * Definition for singly-linked list.
         * public class ListNode {
         *     public int val;
         *     public ListNode next;
         *     public ListNode(int x) { val = x; }
         * }
         */
        public class Solution
        {
            public ListNode ReverseList(ListNode head)
            {
                ListNode root = null;
                while (head != null)
                {
                    var node = new ListNode(head.val)
                    {
                        next = root
                    };
                    root = node;

                    head = head.next;
                }

                return root;
            }
        }
    }
}
