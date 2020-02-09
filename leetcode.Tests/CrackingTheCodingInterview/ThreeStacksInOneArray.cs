using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace leetcode.Tests.CrackingTheCodingInterview
{
    public class ThreeStacksInOneArray
    {
        /*3.1 Three in One: Describe how you could use a single array to implement three stacks.*/

        [Theory]
        [InlineData("", true)]
        public void Test(string str, bool expected)
        {
            var s = new Solution(capacity: 4, stackQty: 3);

            s.Push(0, 55);
            s.Push(0, 54);
            s.Push(0, 57);

            s.Push(1, 24);
            s.Push(1, 80);

            s.Push(2, 17);
            s.Push(2, 27);
            s.Push(2, 37);
            s.Push(2, 47);

            Assert.True(s.IsFull(2));

            Assert.Throws<FullStackException>(() => s.Push(2, 100));


            Assert.Equal(57, s.Pop(0));

            Assert.Equal(54, s.Peek(0));
            Assert.Equal(54, s.Pop(0));

            Assert.Equal(80, s.Peek(1));
            Assert.Equal(80, s.Pop(1));

            Assert.Equal(47, s.Pop(2));
            Assert.Equal(37, s.Pop(2));
            Assert.Equal(27, s.Pop(2));
            Assert.Equal(17, s.Pop(2));

            Assert.Throws<EmptyStackException>(() => s.Pop(2));

            Assert.True(s.IsEmpty(2));
        }

        private class Solution
        {
            private readonly int[] sizes;
            private readonly int[] values;
            private readonly int capacity;

            public Solution(int capacity, int stackQty)
            {
                sizes = new int[stackQty];
                values = new int[capacity * stackQty];
                this.capacity = capacity;
            }

            public void Push(int stackNum, int val)
            {
                if (IsFull(stackNum)) throw new FullStackException();

                var pos = NewElementPosition(stackNum);
                values[pos] = val;
                sizes[stackNum]++;
            }

            public bool IsFull(int stackNum)
            {
                return sizes[stackNum] == capacity;
            }

            public int Pop(int stackNum)
            {
                if (IsEmpty(stackNum)) throw new EmptyStackException();

                var pos = LastElementPosition(stackNum);
                var res = values[pos];
                sizes[stackNum]--;
                values[pos] = 0;

                return res;
            }

            public int Peek(int stackNum)
            {
                if (IsEmpty(stackNum)) throw new EmptyStackException();

                var pos = LastElementPosition(stackNum);
                var res = values[pos];

                return res;
            }

            public bool IsEmpty(int stackNum)
            {
                return sizes[stackNum] == 0;
            }

            private int LastElementPosition(int stackNum)
            {
                return stackNum * capacity + sizes[stackNum] - 1;
            }

            private int NewElementPosition(int stackNum)
            {
                return stackNum * capacity + sizes[stackNum];
            }
        }
    }

    public class EmptyStackException : Exception
    {
        public EmptyStackException() : base("Stack is empty")
        {

        }
    }

    public class FullStackException : Exception
    {
        public FullStackException() : base("Stack is full")
        {

        }
    }
}
