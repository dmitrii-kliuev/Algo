using Algo.Tests.leetcode;
using System;
using Xunit;

namespace Algo.Tests.CrackingTheCodingInterview
{
    public class TwoSinglyListsIntersection
    {
        /*2.7   Intersection : Given two (singly) linked lists, determine if the two lists intersect. Return the inter-
                secting node. Note that the intersection is defined based on reference, not value. That is, if the kth
                node of the first linked list is the exact same node (by reference) as the jth node of the second
                linked list, then they are intersecting.*/

        [Theory]
        [InlineData(new[] { 4, 1 }, new[] { 5, 0, 1 }, new[] { 8, 4, 5 }, true)]
        [InlineData(new[] { 4, 1 }, new[] { 5, 0, 1 }, new[] { 8 }, true)]
        [InlineData(new[] { 4, 1 }, new[] { 5, 0, 1 }, null, false)]
        public void TestJustIntersect(int[] aArr, int[] bArr, int[] cArr, bool expected)
        {
            var d = new ListData(aArr, bArr, cArr);

            var a = d.GetA();
            var b = d.GetB();

            var actual = Solution.JustIntersect(a, b);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new[] { 4, 1 }, new[] { 5, 0, 1 }, new[] { 8, 4, 5 }, true, 8)]
        [InlineData(new[] { 4, 1 }, new[] { 5, 0, 1 }, new[] { 8 }, true, 8)]
        [InlineData(new[] { 4, 1 }, new[] { 5, 0, 2 }, null, false, null)]
        [InlineData(new[] { 7, 4, 1 }, new[] { 5, 0, 1 }, new[] { 8, 4, 5 }, true, 8)]
        [InlineData(new[] { 1, 2, 3, 7, 4, 1 }, new[] { 5, 0, 1 }, new[] { 11, 4, 5 }, true, 11)]
        public void TestIntersectAndFindFirst(int[] aArr, int[] bArr, int[] cArr, bool expectedIntersection, int? expectedVal)
        {
            var d = new ListData(aArr, bArr, cArr);

            var a = d.GetA();
            var b = d.GetB();

            (bool isIntersect, ListNode node) actual = Solution.IntersectAndFindFirst(a, b);
            Assert.Equal(expectedIntersection, actual.isIntersect);

            if (actual.isIntersect)
                Assert.Equal(expectedVal, actual.node.val);
        }

        private static class Solution
        {
            internal static bool JustIntersect(ListNode a, ListNode b)
            {
                var aLast = ListData.GetLast(a);
                var bLast = ListData.GetLast(b);

                if (aLast != null && bLast != null && aLast == bLast)
                    return true;

                return false;
            }

            internal static (bool, ListNode) IntersectAndFindFirst(ListNode a, ListNode b)
            {
                bool isIntersect = false;

                (int len, ListNode last) aInfo = ListNode.LengthAndLastNode(a);
                (int len, ListNode last) bInfo = ListNode.LengthAndLastNode(b);

                if (aInfo.last != bInfo.last) return (false, null);

                var diff = Math.Abs(aInfo.len - bInfo.len);

                if (aInfo.len > bInfo.len)
                {
                    for (int i = 0; i < diff; i++)
                        a = a.next;
                }
                else if (bInfo.len > aInfo.len)
                {
                    for (int i = 0; i < diff; i++)
                        b = b.next;
                }

                while (a != null && b != null)
                {
                    if (a == b)
                    {
                        isIntersect = true;
                        break;
                    }

                    a = a.next;
                    b = b.next;
                }

                if (isIntersect)
                    return (true, a);

                return (false, null);
            }
        }

        private class ListData
        {
            private readonly ListNode _a;
            private readonly ListNode _b;
            public ListData(int[] aArr, int[] bArr, int[] cArr)
            {
                _a = ListNode.ArrayToList(aArr);

                _b = ListNode.ArrayToList(bArr);

                var c = ListNode.ArrayToList(cArr);

                var aLast = GetLast(_a);
                if (aLast != null)
                    aLast.next = c;

                var bLast = GetLast(_b);
                if (bLast != null)
                    bLast.next = c;
            }

            public ListNode GetA()
            {
                return _a;
            }

            public ListNode GetB()
            {
                return _b;
            }

            public static ListNode GetLast(ListNode node)
            {
                var pointer = node;
                ListNode last = null;

                while (pointer != null)
                {
                    last = pointer;
                    pointer = pointer.next;
                }

                return last;
            }
        }
    }
}
