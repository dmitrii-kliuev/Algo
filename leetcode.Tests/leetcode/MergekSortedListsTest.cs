using Xunit;

namespace Algo.Tests.leetcode
{
    public class MergekSortedListsTest
    {
        [Theory]
        [InlineData(new[] { 1, 4, 5 }, new[] { 2, 3, 4 }, new[] { 2, 6 })]
        public void MergeKsortedLists(int[] arr1, int[] arr2, int[] arr3)
        {
            var list = new ListNode[3];
            list[0] = ListNode.ArrayToList(arr1);
            list[1] = ListNode.ArrayToList(arr2);
            list[2] = ListNode.ArrayToList(arr3);

            var s = new Solution();
            s.Insert(ListNode.ArrayToList(arr1), 2);
            //var insertRes1 = Insert(FillList(arr1), 0);
            s.Insert(ListNode.ArrayToList(arr1), 6);

            s.Insert(ListNode.ArrayToList(new[] { 1, 2, 4, 7, 14, 25, 45 }), 6);
            s.Insert(ListNode.ArrayToList(new[] { 1, 2, 4, 7, 14, 25, 45 }), 0);
            s.Insert(ListNode.ArrayToList(new[] { 1, 2, 4, 7, 14, 25, 45 }), 47);

            s.MergeKLists(list);
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
                    var newHead = new ListNode(val)
                    {
                        next = node
                    };
                    return newHead;
                }

                var root = node;
                while (node.next != null)
                {
                    if (val <= node.next.val)
                    {
                        var prev = node;
                        var next = node.next;
                        prev.next = new ListNode(val)
                        {
                            next = next
                        };
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
