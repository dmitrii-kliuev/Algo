using System;
using System.Collections.Generic;
using System.Text;

namespace leetcode.Tests.leetcode
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }

        public static ListNode FillList(int[] arr)
        {
            if (arr == null) return null;

            ListNode root = null;
            ListNode curr = null;
            foreach (var x in arr)
            {
                if (root == null)
                {
                    root = new ListNode(x);
                    curr = root;
                }
                else
                {
                    curr.next = new ListNode(x);
                    curr = curr.next;
                }
            }

            return root;
        }

        public static List<int> LinkedListToList(ListNode l)
        {
            var list = new List<int>();

            while (l != null)
            {
                list.Add(l.val);
                l = l.next;
            }

            return list;
        }
    }
}
