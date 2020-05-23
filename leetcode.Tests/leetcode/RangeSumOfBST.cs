using Algo.Tests.leetcode.TreeProblems;
using Xunit;

namespace Algo.Tests.leetcode
{
    /*
        Given the root node of a binary search tree, 
        return the sum of values of all nodes with value 
        between L and R (inclusive).

        The binary search tree is guaranteed to have unique values.

        Example 1:

        Input: root = [10,5,15,3,7,null,18], L = 7, R = 15
        Output: 32

                10
           5       15
        3     7        18
              ^    ^
              7+10+15 = 32

        Example 2:
        Input: root = [10,5,15,3,7,13,18,1,null,6], L = 6, R = 10
        Output: 23
                      10
                5           15
            3       7    13     18
        1         6
                  ^    ^
                  6+7+10=23
        Note:

        The number of nodes in the tree is at most 10000.
        The final answer is guaranteed to be less than 2^31.*/

    public class RangeSumOfBst
    {
        [Theory]
        [InlineData(new[] { 10, 5, 15, 3, 7, 18 }, 7, 15, 32)]
        [InlineData(new[] { 10, 5, 15, 3, 7, 13, 18, 1, 6 }, 6, 10, 23)]
        public void Test(int[] arr, int l, int r, int expected)
        {
            var bt = new BinaryTreeInt();
            bt.AddRange(arr);
            bt.InOrderTraversal(bt.Root);

            var s = new Solution();
            var actual = s.RangeSumBst(bt.Root, l, r);
            Assert.Equal(expected, actual);
        }

        private class Solution
        {
            public int RangeSumBst(TreeNode root, int l, int r)
            {
                var res = Sum(root, 0, l, r);

                return res;
            }

            public int Sum(TreeNode node, int s, int l, int r)
            {
                if (node.left != null)
                    s = Sum(node.left, s, l, r);

                if (node.val >= l && node.val <= r)
                    s += node.val;

                if (node.right != null)
                    s = Sum(node.right, s, l, r);

                return s;
            }

        }

        /*
         * Definition for a binary tree node.
         * public class TreeNode {
         *     public int val;
         *     public TreeNode left;
         *     public TreeNode right;
         *     public TreeNode(int x) { val = x; }
         * }
         */
    }
}
