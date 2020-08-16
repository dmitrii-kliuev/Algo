using Algo.Tests.leetcode;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Algo.Tests.CrackingTheCodingInterview
{
    public class StackOfPlates
    {
        /*3.3   Stack of Plates: Imagine a (literal) stack of plates. If the stack gets too high, it might topple.
                Therefore, in real life, we would likely start a new stack when the previous stack exceeds some
                threshold. Implement a data structure SetOfStacks that mimics this. SetOfStacks should be
                composed of several stacks and should create a new stack once the previous one exceeds capacity.
                SetOfStacks.push() and SetOfStacks.pop() should behave identically to a single stack
                (that is, pop() should return the same values as it would if there were just a single stack).
                FOLLOW UP
                Implement a function popAt (int index) which performs a pop operation on a specific sub-stack.*/
        [Fact]
        public void SetOfStacks_Push_Pop_Test()
        {
            var s = new SetOfStacks<int>(5);
            s.Push(1);
            s.Push(1);
            s.Push(1);
            s.Push(1);
            s.Push(1);

            s.Push(2);
            s.Push(2);
            s.Push(2);
            s.Push(2);
            s.Push(2);

            s.Push(3);

            Assert.Equal(3, s.Pop());

            Assert.Equal(2, s.Pop());
            Assert.Equal(2, s.Pop());
            Assert.Equal(2, s.Pop());
            Assert.Equal(2, s.Pop());
            Assert.Equal(2, s.Pop());

            Assert.Equal(1, s.Pop());
            Assert.Equal(1, s.Pop());
            Assert.Equal(1, s.Pop());
            Assert.Equal(1, s.Pop());
            Assert.Equal(1, s.Pop());

            Assert.True(s.Empty());
            Assert.Throws<Exception>(() => s.Pop());
        }

        [Fact]
        public void SetOfStacks_PopAt_Test()
        {
            var s = new SetOfStacks<int>(5);
            s.Push(1);
            s.Push(1);
            s.Push(1);
            s.Push(1);
            s.Push(1);

            s.Push(2);
            s.Push(2);
            s.Push(2);
            s.Push(2);
            s.Push(2);

            s.Push(3);

            Assert.Equal(2, s.PopAt(1));
            Assert.Equal(2, s.PopAt(1));
            Assert.Equal(2, s.PopAt(1));
            Assert.Equal(2, s.PopAt(1));
            Assert.Equal(2, s.PopAt(1));

            Assert.Equal(2, s.StackList.Count);

            Assert.Equal(3, s.PopAt(1));

            Assert.Single(s.StackList);

            Assert.Equal(1, s.PopAt(0));
            Assert.Equal(1, s.PopAt(0));
            Assert.Equal(1, s.PopAt(0));
            Assert.Equal(1, s.PopAt(0));
            Assert.Equal(1, s.PopAt(0));

            Assert.True(s.Empty());

            Assert.Throws<Exception>(() => s.Pop());
        }

        private class SetOfStacks<T>
        {
            private readonly int _capacity;
            public readonly List<MyStack<T>> StackList = new List<MyStack<T>>();
            private MyStack<T> _lastStack;

            public SetOfStacks(int capacity)
            {
                _capacity = capacity;
            }

            public void Push(T item)
            {
                if (_lastStack == null)
                {
                    _lastStack = new MyStack<T>();
                    _lastStack.Push(item);
                    StackList.Add(_lastStack);
                }
                else if (_lastStack.Quantity == _capacity)
                {
                    var tmp = new MyStack<T>();
                    StackList.Add(tmp);
                    _lastStack = tmp;
                    _lastStack.Push(item);
                }
                else
                {
                    _lastStack.Push(item);
                }

            }

            public T Pop()
            {
                if (Empty()) throw new Exception("stack is empty");

                var res = _lastStack.Pop();
                if (_lastStack.IsEmpty())
                {
                    StackList.Remove(_lastStack);

                    if (StackList.Count > 0)
                        _lastStack = StackList.Last();
                }

                return res;
            }

            public T PopAt(int index)
            {
                if (Empty()) throw new Exception("stack is empty");

                if (StackList.Count < index + 1) throw new Exception("incorrect index");

                var res = StackList[index].Pop();
                if (StackList[index].IsEmpty())
                {
                    var isLast = StackList.Count == index + 1;

                    StackList.Remove(StackList[index]);

                    if (isLast && !Empty())
                        _lastStack = StackList.Last();
                }

                return res;
            }

            public bool Empty()
            {
                return StackList.Count == 0;
            }
        }
    }
}
