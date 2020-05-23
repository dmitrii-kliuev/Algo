using Algo.Tests.leetcode;
using System;
using Xunit;

namespace Algo.Tests
{
    public class LinkedListPartition
    {
        /*  2.4 Partition: Write code to partition a linked list around a value x, such that all nodes less than x come
            before all nodes greater than or equal to x. If x is contained within the list, the values of x only need
            to be after the elements less than x (see below). The partition element x can appear anywhere in the
            "right partition "; it does not need to appear between the left and right partitions.
            EXAMPLE
            Input:  3 -> 5 -> 8 -> 5 -> 10 -> 2 -> 1 [partition = 5)
            Output: 3 -> 1 -> 2 -> 10 -> 5 -> 5 -> 8


            Clarification
            Rephrased question to make it clearer that x doesn't need to be between the partitions: 
            "Partition: Write code to partition a linked list around a value x, such that all nodes 
            less than x come before all nodes greater than or equal to x. (IMPORTANT: The partition 
            element x can appear anywhere in the “right partition”; it does not need to appear 
            between the left and right partitions. The additional spacing the example below indicates 
            the partition.)

            EXAMPLE
            Input: 	3 -> 5 -> 8 -> 5 -> 10 -> 2 -> 1 [partition = 5]
            Output: 	3 -> 1 -> 2       ->        10 -> 5 -> 5 -> 8
        */

        [Theory]
        [InlineData(new[] { 3, 5, 8, 5, 10, 2, 1 }, 5)]
        [InlineData(new[] { 12, 11, 8, 5, 10, 7, 6 }, 5)]
        [InlineData(new[] { 12, 11, 8, 5, 10, 7, 6 }, 15)]
        public void Test(int[] arr, int partition)
        {
            var lst = ListNode.ArrayToList(arr);

            var actual = Solution.Start(lst, partition);

            Assert.True(IsCorrect(actual, partition));
        }

        private bool IsCorrect(ListNode actual, int partition)
        {
            var lessThenPartitionFlag = true;
            while (actual != null)
            {
                if (actual.val < partition)
                {
                    if (lessThenPartitionFlag)
                        actual = actual.next;
                    else
                        return false;
                }
                else if (actual.val >= partition)
                {
                    lessThenPartitionFlag = false;

                    actual = actual.next;
                }
            }

            return true;
        }

        private static class Solution
        {
            public static ListNode Start(ListNode lst, int partition)
            {
                if (lst is null)
                {
                    throw new ArgumentNullException(nameof(lst));
                }

                ListNode left = null;
                ListNode leftRoot = null;

                ListNode right = null;
                ListNode rightRoot = null;

                while (lst != null)
                {
                    if (lst.val < partition)
                        ListNode.AddElement(ref leftRoot, ref left, lst.val);
                    else
                        ListNode.AddElement(ref rightRoot, ref right, lst.val);

                    lst = lst.next;
                }

                if (left != null)
                {
                    left.next = rightRoot;
                    return leftRoot;
                }

                return rightRoot;
            }
        }
    }
}
