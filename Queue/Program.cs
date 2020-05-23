using System;

namespace Queue
{
    internal class Program
    {
        private static void Main()
        {
            var q = new Queue<int>();

            q.Enqueue(5);
            q.Enqueue(7);
            q.Enqueue(1);

            Console.WriteLine(q.Dequeue());
            Console.WriteLine(q.Dequeue());
            Console.WriteLine(q.Dequeue());

            Console.ReadKey();
        }

        public class Queue<T>
        {
            private LinkedListNode<T> _head;
            private LinkedListNode<T> _tail;
            public int Count;

            public void Enqueue(T val)
            {
                AddLast(val);
            }

            public T Dequeue()
            {
                var result = _head.Value;
                RemoveFirst();
                return result;
            }

            public void Clear()
            {
                _head = null;
                _tail = null;
                Count = 0;
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

            private void AddLast(T value)
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

            private void RemoveFirst()
            {
                if (_head.Next != null)
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
        }
    }
}
