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
            var bt = new BinaryTreeInt();
            bt.AddRange(nums); ;
            var actual = RangeSumBST(bt.Root, low, high);
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
    }
}
