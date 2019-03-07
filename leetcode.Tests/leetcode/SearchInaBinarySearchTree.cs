using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace leetcode.Tests.leetcode
{
    public class SearchInaBinarySearchTree
    {
        [Fact]
        public void Test()
        {
            var tree = new TreeNode(4);
            tree.left = new TreeNode(2);
            tree.left.left = new TreeNode(1);
            tree.left.right = new TreeNode(3);

            tree.right = new TreeNode(7);

            var s = new Solution();
            var res = s.SearchBST(tree, 2);
        }

        public class Solution
        {
            public TreeNode SearchBST(TreeNode root, int val)
            {
                if (root == null) return null;

                if (root.val == val)
                    return root;

                if (root.val > val)
                    return SearchBST(root.left, val);
                if (root.val < val)
                    return SearchBST(root.right, val);

                return null;
            }
        }
    }
}
