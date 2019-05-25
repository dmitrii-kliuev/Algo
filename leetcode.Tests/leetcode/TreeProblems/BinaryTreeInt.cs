using System;
using System.Collections.Generic;
using System.Text;

namespace leetcode.Tests.leetcode.TreeProblems
{
    public class TreeNode : IComparable<int>
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }

        public int CompareTo(int other)
        {
            return val.CompareTo(other);
        }
    }

    public class BinaryTreeInt
    {
        TreeNode _root;

        public void Add(int value)
        {
            if (_root == null)
            {
                _root = new TreeNode(value);
            }
            else
            {
                AddTo(_root, value);
            }
        }

        private void AddTo(TreeNode node, int value)
        {
            if (value.CompareTo(node.val) > 0)
            {
                if (node.right == null)
                {
                    node.right = new TreeNode(value);
                }
                else
                {
                    AddTo(node.right, value);
                }
            }

            if (value.CompareTo(node.val) < 0)
            {
                if (node.left == null)
                {
                    node.left = new TreeNode(value);
                }
                else
                {
                    AddTo(node.left, value);
                }

            }
        }
    }
}
