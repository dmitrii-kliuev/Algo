using Xunit;

namespace Algo.Tests.leetcode
{
    public class MergeTwoSortedListsTest
    {
        [Theory]
        [InlineData(new[] { 1, 2, 4 }, new[] { 1, 3, 4 }, new[] { 1, 1, 2, 3, 4, 4 })]
        [InlineData(new[] { 1, 2, 4 }, new[] { 1, 3, 4, 5 }, new[] { 1, 1, 2, 3, 4, 4, 5 })]
        [InlineData(new[] { 2 }, new[] { 1 }, new[] { 1, 2 })]
        [InlineData(null, new[] { 1, 3, 4 }, new[] { 1, 3, 4 })]
        [InlineData(new[] { 1, 2, 4 }, null, new[] { 1, 2, 4 })]
        public void MergeTwoSortedLists(int[] arr1, int[] arr2, int[] expectedArr)
        {
            var l1 = ListNode.ArrayToList(arr1);
            var l2 = ListNode.ArrayToList(arr2);
            var expected = ListNode.ArrayToList(expectedArr);


            var expectedList = ListNode.LinkedListToList(expected);
            var s = new Solution();
            var actual = s.MergeTwoLists(l1, l2);
            var actualList = ListNode.LinkedListToList(actual);
            Assert.Equal(expectedList, actualList);
        }

        public class Solution
        {
            public ListNode MergeTwoLists(ListNode l1, ListNode l2)
            {
                if (l1 == null) return l2;
                if (l2 == null) return l1;

                ListNode root = null;
                ListNode curr = null;
                while (l1 != null || l2 != null)
                {
                    if (root == null)
                    {
                        if (l1.val < l2.val)
                        {
                            root = new ListNode(l1.val);
                            curr = root;
                            l1 = l1.next;
                        }
                        else if (l2.val < l1.val)
                        {
                            root = new ListNode(l2.val);
                            curr = root;
                            l2 = l2.next;
                        }
                        else if (l1.val == l2.val)
                        {
                            root = new ListNode(l1.val);
                            curr = root;
                            l1 = l1.next;

                            curr.next = new ListNode(l2.val);
                            curr = curr.next;
                            l2 = l2.next;
                        }

                    }
                    else
                    {
                        if (l1 != null && l2 != null)
                        {
                            if (l1.val < l2.val)
                            {
                                curr.next = new ListNode(l1.val);
                                curr = curr.next;
                                l1 = l1.next;
                            }
                            else if (l2.val < l1.val)
                            {
                                curr.next = new ListNode(l2.val);
                                curr = curr.next;
                                l2 = l2.next;
                            }
                            else
                            {
                                curr.next = new ListNode(l1.val);
                                curr = curr.next;
                                l1 = l1.next;

                                curr.next = new ListNode(l2.val);
                                curr = curr.next;
                                l2 = l2.next;
                            }
                        }
                        else if (l1 == null || l2 == null)
                        {
                            if (l1 == null)
                            {
                                curr.next = new ListNode(l2.val);
                                curr = curr.next;
                                l2 = l2.next;
                            }

                            if (l2 == null && l1 != null)
                            {
                                curr.next = new ListNode(l1.val);
                                curr = curr.next;
                                l1 = l1.next;
                            }
                        }
                    }


                }

                return root;
            }
        }

        public class SolutionFirst
        {
            public ListNode MergeTwoLists(ListNode l1, ListNode l2)
            {
                ListNode root = null;
                ListNode curr = null;
                while (l1 != null || l2 != null)
                {
                    if (root == null)
                    {
                        if (l1 != null && l2 != null)
                        {
                            if (l1.val < l2.val)
                            {
                                root = new ListNode(l1.val);
                                curr = root;
                                l1 = l1.next;
                            }
                            else if (l2.val < l1.val)
                            {
                                root = new ListNode(l2.val);
                                curr = root;
                                l2 = l2.next;
                            }
                            else if (l1.val == l2.val)
                            {
                                root = new ListNode(l1.val);
                                curr = root;
                                l1 = l1.next;

                                curr.next = new ListNode(l2.val);
                                curr = curr.next;
                                l2 = l2.next;
                            }
                        }
                        else if (l1 == null)
                        {
                            root = new ListNode(l2.val);
                            curr = root;
                            l2 = l2.next;
                        }
                        else
                        {
                            root = new ListNode(l1.val);
                            curr = root;
                            l1 = l1.next;
                        }
                    }
                    else
                    {
                        if (l1 != null && l2 != null)
                        {
                            if (l1.val < l2.val)
                            {
                                curr.next = new ListNode(l1.val);
                                curr = curr.next;
                                l1 = l1.next;
                            }
                            else if (l2.val < l1.val)
                            {
                                curr.next = new ListNode(l2.val);
                                curr = curr.next;
                                l2 = l2.next;
                            }
                            else
                            {
                                curr.next = new ListNode(l1.val);
                                curr = curr.next;
                                l1 = l1.next;

                                curr.next = new ListNode(l2.val);
                                curr = curr.next;
                                l2 = l2.next;
                            }
                        }
                        else if (l1 == null || l2 == null)
                        {
                            if (l1 == null)
                            {
                                curr.next = new ListNode(l2.val);
                                curr = curr.next;
                                l2 = l2.next;
                            }

                            if (l2 == null && l1 != null)
                            {
                                curr.next = new ListNode(l1.val);
                                curr = curr.next;
                                l1 = l1.next;
                            }
                        }
                    }


                }

                return root;
            }
        }

        public class SolutionFromLeetCode
        {
            public ListNode MergeTwoLists(ListNode l1, ListNode l2)
            {

                if (l1 == null)
                    return l2;
                if (l2 == null)
                    return l1;

                ListNode combined = null;
                ListNode end = new ListNode(0);

                while (true)
                {

                    if (l1 == null && l2 == null)
                    {
                        return combined;
                    }

                    if (l2 == null || (l1 != null && l1.val < l2.val))
                    {
                        end.next = new ListNode(l1.val);
                        l1 = l1.next;
                    }
                    else
                    {
                        end.next = new ListNode(l2.val);
                        l2 = l2.next;
                    }

                    if (combined == null)
                    {
                        combined = end.next;
                    }
                    end = end.next;
                }
            }
        }

        public class SolutionOneOfTheBest
        {
            public ListNode MergeTwoLists(ListNode l1, ListNode l2)
            {

                if (l1 == null) { return l2; }
                if (l2 == null) { return l1; }

                ListNode result;
                ListNode resultLastPtr;

                if (l1.val < l2.val)
                {
                    result = new ListNode(l1.val);
                    l1 = l1.next;
                    resultLastPtr = result;
                }
                else
                {
                    result = new ListNode(l2.val);
                    l2 = l2.next;
                    resultLastPtr = result;
                }

                while (l1 != null && l2 != null)
                {
                    if (l1.val < l2.val)
                    {
                        resultLastPtr.next = new ListNode(l1.val);
                        resultLastPtr = resultLastPtr.next;
                        l1 = l1.next;
                    }
                    else
                    {
                        resultLastPtr.next = new ListNode(l2.val);
                        resultLastPtr = resultLastPtr.next;
                        l2 = l2.next;
                    }
                }
                resultLastPtr.next = (l1 != null) ? l1 : l2;

                return result;
            }
        }
    }
}