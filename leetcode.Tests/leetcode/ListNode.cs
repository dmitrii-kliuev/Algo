﻿using System;
using System.Collections.Generic;
using System.Text;

namespace leetcode.Tests.leetcode
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }

        public static void AddElement(ref ListNode root, ref ListNode lst, int val)
        {
            if (lst == null)
            {
                lst = new ListNode(val);
                root = lst;
            }
            else
            {
                lst.next = new ListNode(val);
                lst = lst.next;
            }
        }

        public static ListNode ArrayToList(int[] arr)
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

        public static int Length(ListNode node)
        {
            if (node == null) return 0;

            int i = 0;
            while (node != null)
            {
                node = node.next;
                i++;
            }

            return i;
        }
    }
}
