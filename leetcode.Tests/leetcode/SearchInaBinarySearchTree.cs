using Algo.Tests.leetcode.TreeProblems;
using Xunit;

namespace Algo.Tests.leetcode
{
    public class SearchInaBinarySearchTree
    {
        [Fact]
        public void Test()
        {
            var tree = new TreeNode(4)
            {
                left = new TreeNode(2)
                {
                    left = new TreeNode(1),
                    right = new TreeNode(3)
                },

                right = new TreeNode(7)
            };

            var s = new Solution();
            s.SearchBST(tree, 2);
        }

        private class Solution
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
