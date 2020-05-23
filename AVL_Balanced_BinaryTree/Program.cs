using System;
using System.Collections.Generic;

namespace AVL_Balanced_BinaryTree
{
    internal class Program
    {
        private static void Main()
        {
            // 56:00
        }

        public class AvlBinaryTree<T> : IEnumerable<T> where T : IComparable<T>
        {
            private AvlTreeNode<T> _root;

            //public void PreOrderTraversal()
            //{
            //    PreOrderTraversal(_root);
            //}

            //public void PreOrderTraversal(AvlTreeNode<T> node)
            //{
            //    Console.WriteLine(node.Value);

            //    if (node.Left != null)
            //        PreOrderTraversal(node.Left);

            //    if (node.Right != null)
            //        PreOrderTraversal(node.Right);
            //}


            //public void InOrderTraversal()
            //{
            //    InOrderTraversal(_root);
            //}

            //public void InOrderTraversal(AvlTreeNode<T> node)
            //{
            //    if (node.Left != null)
            //        InOrderTraversal(node.Left);

            //    Console.WriteLine(node.Value);

            //    if (node.Right != null)
            //        InOrderTraversal(node.Right);
            //}

            //public void PostOrderTraversal()
            //{
            //    PostOrderTraversal(_root);
            //}

            //public void PostOrderTraversal(AvlTreeNode<T> node)
            //{
            //    if (node.Left != null)
            //        PostOrderTraversal(node.Left);

            //    if (node.Right != null)
            //        PostOrderTraversal(node.Right);

            //    Console.WriteLine(node.Value);
            //}

            public AvlTreeNode<T> FindWithParent(T value, out AvlTreeNode<T> parent)
            {
                var current = _root;
                parent = null;

                while (current != null)
                {
                    var result = value.CompareTo(current.Value);
                    if (result > 0)
                    {
                        parent = current;
                        current = current.Right;
                    }
                    else if (result < 0)
                    {
                        parent = current;
                        current = current.Left;
                    }
                    else
                    {
                        break;
                    }
                }

                return current;
            }

            public void Add(T value)
            {
                if (_root == null)
                {
                    _root = new AvlTreeNode<T>(value, null);
                }
                else
                {
                    AddTo(_root, value);
                }
            }

            private void AddTo(AvlTreeNode<T> node, T value)
            {
                if (value.CompareTo(node.Value) > 0)
                {
                    if (node.Right == null)
                    {
                        node.Right = new AvlTreeNode<T>(value, node);
                    }
                    else
                    {
                        AddTo(node.Right, value);
                    }
                }

                if (value.CompareTo(node.Value) < 0)
                {
                    if (node.Left == null)
                    {
                        node.Left = new AvlTreeNode<T>(value, node);
                    }
                    else
                    {
                        AddTo(node.Left, value);
                    }

                }
            }

            public bool Remove(T value)
            {
                var itemToRemove = FindWithParent(value, out AvlTreeNode<T> parent);

                if (itemToRemove == null)
                    return false;

                // удаляемый узел не имеет правого потомка
                if (itemToRemove.Right == null)
                {
                    // если это корень
                    if (parent == null)
                        _root.Left = itemToRemove.Left;
                    else
                    {
                        var cmpRes = itemToRemove.Value.CompareTo(parent.Value);

                        if (cmpRes < 0)
                            parent.Left = itemToRemove.Left;
                        else if (cmpRes > 0)
                            parent.Right = itemToRemove.Left;
                    }
                }
                // удаляемый узел имеет правого потомка, у которого нет левого потомка
                else if (itemToRemove.Right.Left == null)
                {
                    itemToRemove.Right.Left = itemToRemove.Left;

                    if (parent == null) // если это корень
                    {
                        _root = itemToRemove.Right;
                    }
                    else
                    {
                        var cmpRes = itemToRemove.Value.CompareTo(parent.Value);

                        if (cmpRes > 0)
                            parent.Right = itemToRemove.Right;
                        else
                            parent.Left = itemToRemove.Right;
                    }
                }
                // удаляемый узел имеет правого потомка у которого есть левый потомок
                else
                {
                    AvlTreeNode<T> leftmost = itemToRemove.Right.Left;
                    AvlTreeNode<T> leftmostParent = itemToRemove.Right;
                    while (leftmost.Left != null)
                    {
                        leftmostParent = leftmost;
                        leftmost = leftmost.Left;
                    }

                    leftmostParent.Left = leftmost.Right;

                    leftmost.Left = itemToRemove.Left;
                    leftmost.Right = itemToRemove.Right;

                    if (parent == null)
                    {
                        _root = leftmost;
                    }
                    else
                    {
                        var cmpRes = itemToRemove.Value.CompareTo(parent.Value);
                        if (cmpRes < 0)
                            parent.Left = leftmost;
                        else if (cmpRes > 0)
                        {
                            parent.Right = leftmost;
                        }
                    }

                }

                return true;
            }

            #region Итераторы

            public IEnumerator<T> InOrderTraversal()
            {

                // рекурсивное перемищение по дереву

                if (_root != null) // существует ли корень дерева
                {

                    Stack<AvlTreeNode<T>> stack = new Stack<AvlTreeNode<T>>();
                    AvlTreeNode<T> current = _root;

                    // при рекурсивном перемещении по дереву, нужно указывать какой потомок будет слудеющим (правый или левый)

                    bool goLeftNext = true;

                    // Начинаем с помещения корня в стек
                    stack.Push(current);

                    while (stack.Count > 0)
                    {
                        // Если перемещаемся влево ... 
                        if (goLeftNext)
                        {
                            // Перемещение всех левых потомков в стек.

                            while (current.Left != null)
                            {
                                stack.Push(current);
                                current = current.Left;
                            }
                        }

                        yield return current.Value;

                        // Если перемещаемся вправо 

                        if (current.Right != null)
                        {
                            current = current.Right;

                            // Идинажды перемещаемся вправо, после чего опять идем влево. 

                            goLeftNext = true;
                        }
                        else
                        {
                            // Если перейти вправо нельзя - извлекаем родительский узел. 

                            current = stack.Pop();
                            goLeftNext = false;
                        }
                    }
                }
            }

            public IEnumerator<T> GetEnumerator()
            {
                return InOrderTraversal();
            }

            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {

                return GetEnumerator();

            }

            #endregion
        }
    }
}
