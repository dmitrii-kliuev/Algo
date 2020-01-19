using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.ObjectModel;
using Xunit;

namespace leetcode.Tests.leetcode
{
    public class AddTwoNumbersTest
    {
        [Theory]
        [InlineData(new[] { 2, 4, 3 }, new[] { 5, 6, 4 }, new[] { 7, 0, 8 })]
        [InlineData(new[] { 5, 8, 2 }, new[] { 1, 5, 6, 5 }, new[] { 6, 3, 9, 5 })]
        [InlineData(new[] { 5 }, new[] { 5 }, new[] { 0, 1 })]
        [InlineData(new[] { 9, 8 }, new[] { 1 }, new[] { 0, 9 })]
        public void Test(int[] arr1, int[] arr2, int[] expected)
        {
            var l1 = ListNode.ArrayToList(arr1);
            var l2 = ListNode.ArrayToList(arr2);
            

            var s = new Solution();
            var actualList = s.AddTwoNumbers(l1, l2);
            var actual = ListNode.LinkedListToList(actualList);
            Assert.Equal(expected.ToList(), actual);
        }


        public class Solution
        {
            public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
            {
                ListNode res = null;
                ListNode root = null;
                var oneInMind = 0;
                while (l1 != null || l2 != null)
                {
                    if (l1 != null && l2 != null && res == null)
                    {
                        var tmp = l1.val + l2.val;
                        if (tmp > 9)
                        {
                            res = new ListNode(tmp - 10);
                            root = res;
                            oneInMind = 1;
                        }
                        else
                        {
                            res = new ListNode(tmp);
                            root = res;
                        }

                        l1 = l1.next;
                        l2 = l2.next;
                    }
                    else if (l1 != null && l2 != null && res != null)
                    {
                        var tmp = l1.val + l2.val + oneInMind;
                        if (tmp > 9)
                        {
                            res.next = new ListNode(tmp - 10);
                            oneInMind = 1;
                            res = res.next;
                        }
                        else
                        {
                            res.next = new ListNode(tmp);
                            oneInMind = 0;
                            res = res.next;
                        }

                        l1 = l1.next;
                        l2 = l2.next;
                    }
                    else if (l1 == null && res != null)
                    {
                        var tmp = l2.val + oneInMind;
                        if (tmp > 9)
                        {
                            res.next = new ListNode(tmp - 10);
                            oneInMind = 1;
                        }
                        else
                        {
                            res.next = new ListNode(tmp);
                            oneInMind = 0;
                        }
                        
                        res = res.next;
                        l2 = l2.next;
                    }
                    else if (l2 == null && res != null)
                    {
                        var tmp = l1.val + oneInMind;
                        if (tmp > 9)
                        {
                            res.next = new ListNode(tmp - 10);
                            oneInMind = 1;
                        }
                        else
                        {
                            res.next = new ListNode(tmp);
                            oneInMind = 0;
                        }

                        res = res.next;
                        l1 = l1.next;
                    }   
                }

                if (oneInMind != 0 && res != null)
                {
                    res.next = new ListNode(1);
                }

                return root;
            }

        }
    }
}
