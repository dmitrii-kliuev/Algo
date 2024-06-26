﻿using System;
using System.Diagnostics;
using Xunit;

namespace Algo.Tests.leetcode.TreeProblems
{
    public class GenericBinaryTreeTest
    {
        [Fact]
        public void Start()
        {
            Traversal();

            NewMethod1();

            NewMethod2();

            NewMethod3();

            NewMethod4();
        }

        private static void NewMethod4()
        {
            var instance = new BinaryTree<int>();
            instance.Add(100);
            instance.Add(85);
            instance.Add(65);
            instance.Add(50);
            instance.Add(87);
            instance.Add(86);
            instance.Add(88);
            instance.Add(89);
            instance.Add(90);
            instance.Add(200);
            instance.Add(300);
            instance.Add(250);
            instance.Add(400);
            instance.Add(500);
            instance.Add(450);
            instance.Add(470);

            instance.Remove(65);
            instance.Remove(87);
            instance.Remove(400);
            instance.Remove(100);
        }

        private static void Traversal()
        {
            var instance = new BinaryTree<int>();

            instance.Add(8);  //                       8
            instance.Add(5);  //                     /   \
            instance.Add(12); //                    5    12 
            instance.Add(3);  //                   / \   / \  
            instance.Add(7);  //                  3   7 10 15
            instance.Add(10); //                             \
            instance.Add(15); //                             20
            instance.Add(20);

            instance.FindWithParent(12, out _);

            instance.FindWithParent(2, out _);

            instance.InOrderTraversal();
            instance.PreOrderTraversal();
            instance.PostOrderTraversal();
            instance.LevelOrderTraversal();
        }

        private static void NewMethod3()
        {
            // у удаляемого узла правый потомок null
            var instance = new BinaryTree<int>();
            instance.Add(8);
            instance.Add(5);
            instance.Add(2);
            instance.Add(10);
            instance.Add(9);
            instance.Add(16);

            instance.Remove(5);
        }

        private static void NewMethod2()
        {
            // у правого потомка удаляемого узла левый потомок null
            var instance = new BinaryTree<int>();
            instance.Add(8);
            instance.Add(5);
            instance.Add(6);
            instance.Add(7);
            instance.Add(2);
            instance.Add(10);
            instance.Add(9);
            instance.Add(16);

            instance.Remove(5);
        }

        private static void NewMethod1()
        {
            // у правого потомка удаляемого узла есть левый потомок
            var instance = new BinaryTree<int>();
            instance.Add(8);
            instance.Add(5);
            instance.Add(7);
            instance.Add(6);
            instance.Add(2);
            instance.Add(10);
            instance.Add(9);
            instance.Add(16);
            instance.Add(15);
            instance.Add(14);
            instance.Add(13);
            instance.Add(12);

            instance.Remove(5);
            instance.Remove(10);
        }

        private class BinaryTree<T> where T : IComparable<T>
        {
            private BinaryTreeNode<T> _root;

            public void PreOrderTraversal()
            {
                Debug.WriteLine("PreOrderTraversal");
                PreOrderTraversal(_root);
            }

            public void PreOrderTraversal(BinaryTreeNode<T> node)
            {
                if (node != null)
                {
                    Debug.WriteLine(node.Value);
                    PreOrderTraversal(node.Left);
                    PreOrderTraversal(node.Right);
                }
            }


            public void InOrderTraversal()
            {
                Debug.WriteLine("InOrderTraversal");
                InOrderTraversal(_root);
            }

            public void InOrderTraversal(BinaryTreeNode<T> node)
            {
                if (node != null)
                {
                    InOrderTraversal(node.Left);

                    Debug.WriteLine(node.Value);

                    InOrderTraversal(node.Right);
                }
            }

            public void PostOrderTraversal()
            {
                Debug.WriteLine("PostOrderTraversal");
                PostOrderTraversal(_root);
            }

            public void PostOrderTraversal(BinaryTreeNode<T> node)
            {
                if (node != null)
                {
                    PostOrderTraversal(node.Left);
                    PostOrderTraversal(node.Right);

                    Debug.WriteLine(node.Value);
                }
            }

            public BinaryTreeNode<T> FindWithParent(T value, out BinaryTreeNode<T> parent)
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
                    _root = new BinaryTreeNode<T>(value);
                }
                else
                {
                    AddTo(_root, value);
                }
            }

            private void AddTo(BinaryTreeNode<T> node, T value)
            {
                if (value.CompareTo(node.Value) > 0)
                {
                    if (node.Right == null)
                    {
                        node.Right = new BinaryTreeNode<T>(value);
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
                        node.Left = new BinaryTreeNode<T>(value);
                    }
                    else
                    {
                        AddTo(node.Left, value);
                    }

                }
            }

            public void Remove(T value)
            {
                var itemToRemove = FindWithParent(value, out BinaryTreeNode<T> parent);

                if (itemToRemove == null) return;

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
                    BinaryTreeNode<T> leftmost = itemToRemove.Right.Left;
                    BinaryTreeNode<T> leftmostParent = itemToRemove.Right;
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
            }

            public void LevelOrderTraversal()
            {
                Debug.WriteLine("LevelOrderTraversal");
                LevelOrderTraversal(_root);
            }

            private void LevelOrderTraversal(BinaryTreeNode<T> root)
            {
                var h = Height(root);
                Debug.WriteLine(h);
                for (var i = 1; i <= h; i++)
                {
                    Debug.Write($"level {i}: ");
                    printCurrentLevel(root, i);
                    Debug.WriteLine("");
                }
            }

            private void printCurrentLevel(BinaryTreeNode<T> root, int level)
            {
                if (root == null)
                {
                    return;
                }
                else if (level == 1)
                {
                    Debug.Write(root.Value + " ");
                }
                else if (level > 1)
                {
                    printCurrentLevel(root.Left, level - 1);
                    printCurrentLevel(root.Right, level - 1);
                }
            }

            private int Height(BinaryTreeNode<T> root)
            {
                if (root == null)
                {
                    return 0;
                }
                else
                {
                    var lHeight = Height(root.Left);
                    var rHeight = Height(root.Right);

                    if (lHeight > rHeight)
                    {
                        return lHeight + 1;
                    }
                    else
                    {
                        return rHeight + 1;
                    }
                }
            }
        }

    }
}
