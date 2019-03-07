using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleLinkedList
{
    public class LinkedListNode<T>
    {
        public LinkedListNode<T> Prev;
        public LinkedListNode<T> Next;

        public T Value { get; internal set; }

        public LinkedListNode(T value)
        {
            Value = value;
        }
    }
}
