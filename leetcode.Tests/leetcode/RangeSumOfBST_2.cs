using Algo.Tests.leetcode.TreeProblems;
using Xunit;

namespace Algo.Tests.leetcode
{
    public class RangeSumOfBST_2
    {
        [Theory]
        [InlineData(new int[] { 10, 5, 15, 3, 7, 18 }, 7, 15, 32)]
        public void Test(int[] nums, int low, int high, int expected)
        {
            var root = FillTree(nums);
            var actual = RangeSumBST(root, low, high);
            Assert.Equal(expected, actual);
        }

        public int RangeSumBST(TreeNode root, int low, int high)
        {
            var result = 0;
            TraverseTree(root, low, high, ref result);

            return result;
        }

        private void TraverseTree(TreeNode root, int low, int high, ref int result)
        {
            if (root.left != null)
                TraverseTree(root.left, low, high, ref result);

            if (root.val >= low && root.val <= high)
            {
                result += root.val;
            }

            if (root.right != null)
                TraverseTree(root.right, low, high, ref result);
        }

        private TreeNode FillTree(int[] nums)
        {
            TreeNode root = new TreeNode(nums[0]);
            for (int i = 1; i < nums.Length; i++)
            {
                Insert(ref root, nums[i]);
            }

            return root;
        }

        private void Insert(ref TreeNode root, int num)
        {
            var node = root;
            while (node != null)
            {
                if (num < node.val)
                {
                    if (node.left == null)
                    {
                        node.left = new TreeNode(num);
                        break;
                    }

                    node = node.left;
                }
                else if (num > node.val)
                {
                    if (node.right == null)
                    {
                        node.right = new TreeNode(num);
                        break;
                    }
                    node = node.right;
                }
                else
                {
                    // что делать? Зациклимся же
                }
            }
        }
    }
}
