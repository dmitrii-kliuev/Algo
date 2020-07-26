using System;

namespace Stack
{
    internal class Program
    {
        private static void Main()
        {
            var s = new Stack<int>();
            s.Push(5);
            s.Push(7);
            s.Push(1);

            Console.WriteLine(s.Peek());
            Console.WriteLine();

            Console.WriteLine(s.Pop());
            Console.WriteLine(s.Pop());
            Console.WriteLine(s.Pop());

            Console.ReadKey();
        }
    }

    public class Stack<T>
    {
        private StackItem<T> _top;
        private int _count;

        public T Pop()
        {
            if (_count == 0)
                throw new Exception("Stack is empty");

            var res = _top;
            _top = _top.Next;
            _count--;
            return res.Value;
        }

        public T Peek()
        {
            return _top.Value;
        }

        public void Push(T val)
        {
            var node = new StackItem<T>(val);

            if (_top == null)
                _top = node;
            else
            {
                node.Next = _top;
                _top = node;
            }

            _count++;
        }
    }

    public class StackItem<T>
    {
        public T Value;
        public StackItem<T> Next;

        public StackItem(T val)
        {
            Value = val;
        }
    }
}
