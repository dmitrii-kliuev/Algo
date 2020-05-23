using System;
using System.Collections;
using System.Collections.Generic;

namespace DoubleLinkedList
{
    internal class Program
    {
        private static void Main()
        {
            var inst = new DoubleLinkedList<int>();
            inst.AddFirst(5);
            inst.AddFirst(10);

            inst.Display();

            inst.AddLast(25);
            inst.AddLast(14);

            inst.Display();
            Console.WriteLine();

            inst.AddAfter(10, 77);
            inst.Display();
            inst.DisplayReverse();
            Console.WriteLine();

            inst.AddAfter(14, 150);
            inst.Display();
            inst.DisplayReverse();
            Console.WriteLine();

            inst.AddAfter(5, 70);
            inst.Display();
            inst.DisplayReverse();

            Console.WriteLine();
            Console.WriteLine($"contains 70? = {inst.Contains(70)}");
            Console.WriteLine($"contains 111? = {inst.Contains(111)}");
            Console.WriteLine();

            inst.RemoveFirst();
            inst.Display();
            inst.DisplayReverse();

            inst.RemoveLast();
            inst.Display();
            inst.DisplayReverse();

            Console.WriteLine();

            Console.WriteLine("remove 14");
            inst.Remove(14);
            inst.Display();
            inst.DisplayReverse();
            Console.WriteLine();

            Console.WriteLine("remove 70");
            inst.Remove(70);
            inst.Display();
            inst.DisplayReverse();
            Console.WriteLine();

            Console.WriteLine("remove 77");
            inst.Remove(77);
            inst.Display();
            inst.DisplayReverse();

            Console.ReadKey();
        }

        public class DoubleLinkedList<T> : IEnumerable<T>
        {
            private LinkedListNode<T> _head;
            private LinkedListNode<T> _tail;
            public int Count;

            public bool Contains(T value)
            {
                var current = _head;

                while (current != null)
                {
                    if (current.Value.Equals(value))
                        return true;

                    current = current.Next;
                }

                return false;
            }

            public void Clear()
            {
                _head = null;
                _tail = null;
                Count = 0;
            }

            public void AddAfter(T findVal, T value)
            {
                var node = new LinkedListNode<T>(value);
                var current = _head;

                while (current != null)
                {
                    if (current.Value.Equals(findVal))
                    {
                        if (current.Next == null)
                            AddLast(value);
                        else
                        {
                            var prev = current.Next.Prev;
                            var next = current.Next;

                            node.Prev = prev;
                            node.Next = next;

                            prev.Next = node;
                            next.Prev = node;

                            Count++;
                        }

                        break;
                    }

                    current = current.Next;
                }
            }

            public void AddFirst(T value)
            {
                var node = new LinkedListNode<T>(value);
                if (_head == null)
                {
                    _head = node;
                    _tail = node;
                }
                else
                {
                    _head.Prev = node;
                    node.Next = _head;
                    _head = node;
                }

                Count++;
            }

            public void AddLast(T value)
            {
                var node = new LinkedListNode<T>(value);

                if (_head == null)
                {
                    _head = node;
                    _tail = node;
                }
                else
                {
                    node.Prev = _tail;
                    _tail.Next = node;
                    _tail = node;
                }

                Count++;
            }

            public void Remove(T value)
            {
                var current = _head;

                while (current != null)
                {
                    if (current.Value.Equals(value))
                    {
                        if (current.Prev == null)
                            RemoveFirst();
                        else if (current.Next == null)
                            RemoveLast();
                        else
                        {
                            var prev = current.Prev;
                            var next = current.Next;

                            prev.Next = next;
                            next.Prev = prev;

                            Count--;
                        }
                    }

                    current = current.Next;
                }
            }

            public void RemoveFirst()
            {
                _head.Next.Prev = null;
                _head = _head?.Next;
                Count--;
            }

            public void RemoveLast()
            {
                _tail.Prev.Next = null;
                _tail = _tail.Prev;
                Count--;
            }

            public IEnumerator<T> GetEnumerator()
            {
                var current = _head;
                while (current != null)
                {
                    yield return current.Value;
                    current = current.Next;
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            public void Display()
            {
                foreach (var item in this)
                {
                    Console.Write(item + " ");
                }

                Console.WriteLine();
            }

            public void DisplayReverse()
            {
                var current = _tail;

                while (current != null)
                {
                    Console.Write(current.Value + " ");
                    current = current.Prev;
                }

                Console.WriteLine();
            }
        }
    }
}
