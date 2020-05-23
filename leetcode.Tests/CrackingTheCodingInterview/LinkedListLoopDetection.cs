using Algo.Tests.leetcode;
using Xunit;

namespace Algo.Tests.CrackingTheCodingInterview
{
    public class LinkedListLoopDetection
    {
        /*2.8 Loop Detection: Given a circular linked list, implement an algorithm that returns the node at the
            beginning of the loop. 
            Clarification. Rephrase question to read: Given a linked list which might contain a loop, 
            implement an algorithm that returns the node at the beginning of the loop (if one exists)
            DEFINITION
            Circular linked list: A (corrupt) linked list in which a node 's next pointer points to an earlier node, so
            as to make a loop in the linked list.
            EXAMPLE
            Input: A - > B - > C - > D - > E - > C [the same C as earlier)
            Outpu t: C
            
            // 1 → 2 → 3 → 4    
            //         ↑   ↓
            //         ↑ ← 5
             
             */

        [Theory]
        [InlineData(3)]
        private void Test(int expected)
        {
            ListNode root = new ListNode(1);
            var node = root;

            node.next = new ListNode(2);
            node = node.next;

            var loopStart = new ListNode(3);
            node.next = loopStart;
            node = node.next;

            node.next = new ListNode(200);
            node = node.next;

            node.next = new ListNode(4);
            node = node.next;

            node.next = new ListNode(5);
            node = node.next;
            node.next = loopStart;

            var actual = Solution.Start(root);
            Assert.Equal(expected, actual.val);
        }

        [Theory]
        [InlineData(new[] { 1, 2, 3, 4, 5 }, null)]
        [InlineData(new[] { 1, 2, 3, 4, 5, 6 }, null)]
        private void Test1(int[] arr, object obj)
        {
            var lst = ListNode.ArrayToList(arr);

            var actual = Solution.Start(lst);
            Assert.Equal(actual, obj);
        }

        internal static class Solution
        {
            internal static ListNode Start(ListNode root)
            {
                var fast = root;
                var slow = root;

                while (fast != null && fast.next != null && slow != null)
                {
                    fast = fast.next.next;
                    slow = slow.next;

                    if (fast == slow)
                        break;
                }

                if (fast == null || fast.next == null || slow == null)
                    return null;

                slow = root;
                while (slow != fast)
                {
                    slow = slow.next;
                    fast = fast.next;
                }

                return fast;
            }
        }
    }
}
