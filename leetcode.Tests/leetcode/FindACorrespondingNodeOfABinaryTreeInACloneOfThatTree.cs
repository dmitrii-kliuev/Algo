using Algo.Tests.leetcode.TreeProblems;
using System.Diagnostics;
using Xunit;

namespace Algo.Tests.leetcode
{
    public class FindACorrespondingNodeOfABinaryTreeInACloneOfThatTree
    {
        [Fact]
        public void Test()
        {
            /*
                Input: tree = [7,4,3,null,null,6,19], target = 3
                Output: 3
             */

            var root = new BinaryTreeInt();
            root.AddRange(new int[] { 7, 4, 3, 6, 19 });

            var actual = GetTargetCopy(root.Root, root.Root, new TreeNode(3));
            Assert.Equal(3, actual.val);
        }

        public TreeNode GetTargetCopy(TreeNode original, TreeNode cloned, TreeNode target)
        {
            return Traversal(cloned, target.val);
        }

        public TreeNode Traversal(TreeNode node, int target)
        {
            if (node == null)
            {
                return null;
            }

            if (node.val == target)
            {
                return node;
            }

            var l = Traversal(node.left, target);
            if(l != null)
            {
                return l;
            }

            var r = Traversal(node.right, target);
            
            return r;
        }
    }
}
