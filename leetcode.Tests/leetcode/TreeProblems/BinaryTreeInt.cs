using System;
using System.Diagnostics;

namespace Algo.Tests.leetcode.TreeProblems
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
        public TreeNode Root;

        public void Add(int value)
        {
            if (Root == null)
            {
                Root = new TreeNode(value);
            }
            else
            {
                AddTo(Root, value);
            }
        }

        internal void AddRange(int[] arr)
        {
            foreach (var item in arr)
            {
                Add(item);
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

        public void InOrderTraversal(TreeNode node)
        {
            if (node.left != null)
                InOrderTraversal(node.left);

            Debug.WriteLine(node.val);

            if (node.right != null)
                InOrderTraversal(node.right);
        }

        public TreeNode FindNode(int value)
        {
            var current = Root;

            while (current != null)
            {
                var result = value.CompareTo(current.val);
                if (result > 0)
                {
                    current = current.right;
                }
                else if (result < 0)
                {
                    current = current.left;
                }
                else
                {
                    break;
                }
            }

            return current;
        }
    }
}
