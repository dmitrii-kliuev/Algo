using leetcode.Tests.leetcode;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xunit;

namespace leetcode.Tests
{
    public class RemoveDupsInLinkedList
    {
        /* Write code to remove duplicates from an unsorted linked list.
            FOLLOW UP
            How would you solve this problem if a temporary buffer is not allowed?*/

        [Theory]
        [InlineData(new[] { 2, 1, 5, 4, 1, 4 }, new[] { 2, 1, 5, 4 })]
        [InlineData(new[] { 2, 2, 1, 5, 4, 1, 4 }, new[] { 2, 1, 5, 4 })]
        [InlineData(new[] { 2, 2, 1, 5, 4, 1, 4, 2, 1 }, new[] { 2, 1, 5, 4 })]
        [InlineData(null, null)]
        public void TestViaHashSet(int[] arr, int[] expected)
        {
            var root = ListNode.FillList(arr);

            var actual = SolutionViaHashSet.RemoveDups(root);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new[] { 2, 1, 5, 4, 1, 4 }, new[] { 2, 1, 5, 4 })]
        [InlineData(new[] { 2, 2, 1, 5, 4, 1, 4 }, new[] { 2, 1, 5, 4 })]
        [InlineData(new[] { 2, 2, 1, 5, 4, 1, 4, 2, 1 }, new[] { 2, 1, 5, 4 })]
        [InlineData(null, null)]
        public void TestViaDoublePointer(int[] arr, int[] expected)
        {
            var root = ListNode.FillList(arr);

            var actual = SolutionViaDoublePointer.RemoveDups(root);
            Assert.Equal(expected, actual);
        }

        static class SolutionViaHashSet
        {
            public static int[] RemoveDups(ListNode root)
            {
                if (root == null) return null;

                var current = root;
                var prev = root;
                var hs = new HashSet<int>();
                while (current != null)
                {
                    Debug.WriteLine(current.val);
                    if (!hs.Contains(current.val))
                    {
                        hs.Add(current.val);

                        prev = current;
                        current = current.next;
                    }
                    else
                    {
                        // remove
                        if (current.next != null)
                            prev.next = current.next;
                        else
                            prev.next = null;

                        current = prev;
                        current = current.next;
                    }


                }

                return ListNode.LinkedListToList(root).ToArray();
            }
        }

        static class SolutionViaDoublePointer
        {
            public static int[] RemoveDups(ListNode root)
            {
                if (root == null) return null;

                var slow = root;
                while (slow != null)
                {
                    if (slow.next != null)
                    {
                        var fast = slow.next;
                        var prev = slow;
                        while (fast != null)
                        {
                            if (slow.val != fast.val)
                            {
                                prev = fast;
                                fast = fast.next;
                            }
                            else
                            {
                                if (fast.next != null)
                                    prev.next = fast.next;
                                else
                                    prev.next = null;

                                fast = prev;
                                fast = fast.next;
                            }
                        }

                        slow = slow.next;
                    }
                    else
                        slow = slow.next;
                }

                return ListNode.LinkedListToList(root).ToArray();
            }
        }
    }
}
