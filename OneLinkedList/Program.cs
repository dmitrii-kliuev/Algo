using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneLinkedList
{
    class Program
    {
        /*
         односвязный список
         Добавление, удаление по индексу, удаление по значению, поиск элемента по индексу, вывод
         */
        static void Main(string[] args)
        {
            var instance = new LinkedList<int>();
            instance.Add(4);
            instance.Add(5);
            instance.Add(1);
            instance.Add(8);
            instance.Add(0);
            instance.Add(2);
            instance.Add(7);

            foreach (var item in instance)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
            Console.WriteLine();
            instance.Print();

            var res1 = instance.GetValue(2);
            var res2 = instance.GetValue(6);

            instance.Remove(4);
            instance.Remove(7);
            instance.Remove(8);

            Console.WriteLine("After removing");
            instance.Print();


            instance.Clear();
            Console.WriteLine("Reset");

            instance.Add(4);
            instance.Add(5);
            instance.Add(1);
            instance.Add(8);
            instance.Add(0);
            instance.Add(2);
            instance.Add(7);

            instance.RemoveAt(0);
            instance.RemoveAt(3);
            instance.RemoveAt(instance.Count - 1);

            Console.WriteLine("After removing by index");
            instance.Print();

            Console.ReadKey();
        }
    }

    public class LinkedList<T> : IEnumerable<T>
    {
        public int Count;
        private ListNode<T> _head;
        private ListNode<T> _tail;

        public void Remove(T value)
        {
            ListNode<T> prev = null;
            ListNode<T> current = _head;

            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    if (prev == null)
                    {
                        _head = _head.Next;
                        Count--;
                        break;
                    }

                    if (current.Next == null)
                    {
                        prev.Next = null;
                        _tail = prev;
                        Count--;
                        break;
                    }

                    if (current.Next != null)
                    {
                        prev.Next = current.Next;
                        Count--;
                        break;
                    }
                }

                prev = current;
                current = current.Next;
            }

            if (_head == null)
            {
                _tail = null;
            }
        }

        public void RemoveAt(int index)
        {
            if (Count == 0)
                return;

            ListNode<T> prev = null;
            ListNode<T> current = _head;
            var i = 0;

            while (i != index)
            {
                prev = current;
                current = current.Next;
                i++;

                if (i == Count)
                    return;
            }

            if (current.Next == null && prev != null)
            {
                prev.Next = null;
                Count--;
                return;
            }

            if(prev != null)
            {
                prev.Next = current.Next;
                Count--;
                return;
            }

            if (prev == null)
            {
                _head = _head.Next;
                Count--;
            }
        }

        public void Add(T newValue)
        {
            var newNode = new ListNode<T>(newValue);

            if (_head == null)
            {
                _head = newNode;
                _tail = _head;
            }
            else
            {
                _tail.Next = newNode;
                _tail = _tail.Next;
            }

            Count++;
        }

        public ListNode<T> GetItem(int index)
        {
            if (index + 1 > Count)
                throw new Exception("Out of range.");

            var qty = 0;
            var currentItem = _head;

            while (qty != index)
            {
                currentItem = currentItem.Next;
                qty++;
            }

            return currentItem;
        }

        public T GetValue(int index)
        {
            return GetItem(index).Value;
        }

        public void Clear()
        {
            _head = null;
            _tail = null;
            Count = 0;
        }

        public void Print()
        {
            var currentNode = _head;
            while (currentNode != null)
            {
                Console.WriteLine(currentNode.Value);
                currentNode = currentNode.Next;
            }
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
    }

    public class ListNode<T>
    {
        public T Value;
        public ListNode<T> Next;

        public ListNode(T value)
        {
            Value = value;
        }
    }
}
