using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode.Tests.leetcode.TreeProblems
{
    public class BinaryTreeNode<T> : IComparable<T> where T : IComparable<T>
    {
        public BinaryTreeNode<T> Left;
        public BinaryTreeNode<T> Right;

        public T Value;

        public BinaryTreeNode(T value)
        {
            Value = value;
        }

        public int CompareTo(T other)
        {
            return Value.CompareTo(other);
        }

        public int CompareNode(BinaryTreeNode<T> other)
        {
            return Value.CompareTo(other.Value);
        }
    }
}
