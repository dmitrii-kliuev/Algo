using Algo.Tests.leetcode.TreeProblems;
using Xunit;

// ReSharper disable UseObjectOrCollectionInitializer

namespace Algo.Tests.leetcode
{
    public class MergeTwoBinaryTrees
    {
        [Fact]
        public void Test()
        {
            var t1 = new TreeNode(1)
            {
                left = new TreeNode(3)
                {
                    left = new TreeNode(5)
                },
                right = new TreeNode(2)
            };

            var t2 = new TreeNode(2)
            {
                left = new TreeNode(1)
                {
                    right = new TreeNode(4)
                },
                right = new TreeNode(3)
                {
                    right = new TreeNode(7)
                }
            };

            var s = new Solution();
            s.MergeTrees(t1, t2);
        }

        public class Solution
        {
            private TreeNode _root;
            public TreeNode MergeTrees(TreeNode t1, TreeNode t2)
            {
                Start(t1, t2, out _);

                return _root;
            }

            private void Start(TreeNode t1, TreeNode t2, out TreeNode rt)
            {

                if (t1 == null && t2 == null)
                {
                    rt = null;
                    return;
                }

                if (t1 == null)
                {
                    rt = new TreeNode(t2.val);
                }
                else if (t2 == null)
                {
                    rt = new TreeNode(t1.val);
                }
                else
                {
                    rt = new TreeNode(t1.val + t2.val);
                }

                if (_root == null) _root = rt;

                Start(t1?.left, t2?.left, out rt.left);

                Start(t1?.right, t2?.right, out rt.right);
            }
        }
    }
}
