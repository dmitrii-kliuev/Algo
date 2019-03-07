using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace leetcode.Tests.leetcode
{
    public class MergekSortedListsTest
    {
        [Theory]
        [InlineData(new int[] { 1, 4, 5 }, new int[] { 2, 3, 4 }, new int[] { 2, 6 })]
        public void MergeKsortedLists(int[] arr1, int[] arr2, int[] arr3)
        {
            var list = new ListNode[3];
            list[0] = ListNode.FillList(arr1);
            list[1] = ListNode.FillList(arr2);
            list[2] = ListNode.FillList(arr3);

            var s = new Solution();
            var insertRes = s.Insert(ListNode.FillList(arr1), 2);
            //var insertRes1 = Insert(FillList(arr1), 0);
            var insertRes2 = s.Insert(ListNode.FillList(arr1), 6);

            var insertRes3 = s.Insert(ListNode.FillList(new int[] { 1, 2, 4, 7, 14, 25, 45 }), 6);
            var insertRes4 = s.Insert(ListNode.FillList(new int[] { 1, 2, 4, 7, 14, 25, 45 }), 0);
            var insertRes5 = s.Insert(ListNode.FillList(new int[] { 1, 2, 4, 7, 14, 25, 45 }), 47);
            
            var res = s.MergeKLists(list);
        }

        public class Solution
        {
            public ListNode MergeKLists(ListNode[] lists)
            {
                ListNode root = null;
                foreach (var list in lists)
                {
                    var tmp = list;

                    if (root == null)
                    {
                        root = tmp;
                    }
                    else
                    {
                        while (tmp != null)
                        {
                            root = Insert(root, tmp.val);
                            tmp = tmp.next;
                        }
                    }

                }

                return root;
            }

            public ListNode Insert(ListNode node, int val)
            {
                if (node == null)
                {
                    node = new ListNode(val);
                    return node;
                }

                if (val < node.val)
                {
                    var newHead = new ListNode(val);
                    newHead.next = node;
                    return newHead;
                }

                var root = node;
                while (node.next != null)
                {
                    if (val <= node.next.val)
                    {
                        var prev = node;
                        var next = node.next;
                        prev.next = new ListNode(val);
                        prev.next.next = next;
                        return root;
                    }

                    
                    node = node.next;
                }

                node.next = new ListNode(val);

                return root;
            }
        }

        
    }
}
