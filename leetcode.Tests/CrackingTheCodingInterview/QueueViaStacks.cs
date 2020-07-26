using Algo.Tests.leetcode;
using Xunit;

namespace Algo.Tests.CrackingTheCodingInterview
{
    public class QueueViaStacks
    {
        // 3.4 Implement a MyQueue class which implements a queue using two stacks

        [Fact]
        public void Test()
        {
            var queue = new MyQueue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            Assert.Equal(1, queue.Dequeue());
            queue.Enqueue(4);
            Assert.Equal(2, queue.Dequeue());
            Assert.Equal(3, queue.Peek());
            Assert.Equal(3, queue.Dequeue());
            Assert.Equal(4, queue.Dequeue());
        }

        public class MyQueue<T>
        {
            private readonly MyStack<T> _stackNewest = new MyStack<T>();
            private readonly MyStack<T> _stackOldest = new MyStack<T>();

            public void Enqueue(T item)
            {
                _stackNewest.Push(item);
            }

            private void ShiftStacks()
            {
                if (_stackOldest.Empty())
                {
                    while (!_stackNewest.Empty())
                    {
                        _stackOldest.Push(_stackNewest.Pop());
                    }
                }
            }

            public T Dequeue()
            {
                ShiftStacks();
                return _stackOldest.Pop();
            }

            public T Peek()
            {
                ShiftStacks();
                return _stackOldest.Top();
            }
        }
    }
}
