using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVL_Balanced_BinaryTree
{
    public class AvlTreeNode<T> : IComparable<T> where T : IComparable<T>
    {
        private AvlTreeNode<T> _left;
        private AvlTreeNode<T> _right;

        public AvlTreeNode<T> Left
        {
            get => _left;

            internal set
            {
                _left = value;

                if (_left != null)
                    _left.Parent = this;
            }
        }

        public AvlTreeNode<T> Right
        {
            get => _right;

            internal set
            {
                _right = value;

                if (_right != null)
                    _right.Parent = this;
            }
        }
        public AvlTreeNode<T> Parent;


        public T Value;

        public AvlTreeNode(T value, AvlTreeNode<T> parent)
        {
            Value = value;
            Parent = parent;
        }

        public int CompareTo(T other)
        {
            return Value.CompareTo(other);
        }

        public int CompareNode(AvlTreeNode<T> other)
        {
            return Value.CompareTo(other.Value);
        }
    }
}
