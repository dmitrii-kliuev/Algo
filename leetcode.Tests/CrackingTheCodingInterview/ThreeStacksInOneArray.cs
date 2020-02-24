using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Text;
using Xunit;

namespace leetcode.Tests.CrackingTheCodingInterview
{
    public class ThreeStacksInOneArray
    {
        /*3.1 Three in One: Describe how you could use a single array to implement three stacks.*/

        #region fixed size
        [Fact]
        public void FixedSizeTest()
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
        #endregion

        #region flexible size
        [Fact]
        public void FlexibleSizeTest()
        {
            var s = new MultiStack(numberOfStacks: 3, defaultCapacity: 4);

            s.Push(0, 55);
            s.Push(0, 54);
            s.Push(0, 57);

            s.Push(1, 24);
            s.Push(1, 80);

            s.Push(2, 17);
            s.Push(2, 27);
            s.Push(2, 37);
            s.Push(2, 47);

            //Assert.True(s.IsFull(2));

            //Assert.Throws<FullStackException>(() => s.Push(2, 100));
            s.Push(2, 100);

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

            //Assert.True(s.IsEmpty(2));
        }

        private class MultiStack
        {
            private class StackInfo
            {
                public int start, size, capacity;
                public StackInfo(int start, int capacity)
                {
                    this.start = start;
                    this.capacity = capacity;
                }

                public bool IsWithinStackCapacity(int index, int[] values)
                {
                    if (index < 0 || index > values.Length)
                        return false;

                    int contiguousIndex = index < start ? index + values.Length : index;
                    int end = start + capacity;
                    return start <= contiguousIndex && contiguousIndex < end;
                }

                public int LastCapacityIndex()
                {
                    return AdjustIndex(start + capacity - 1);
                }

                public int LastElementIndex()
                {
                    return AdjustIndex(start + size - 1);
                }

                public bool IsFull()
                {
                    return size == capacity;
                }

                public bool IsEmpty()
                {
                    return size == 0;
                }
            }

            private readonly StackInfo[] info;
            public static int[] values;

            public MultiStack(int numberOfStacks, int defaultCapacity)
            {
                info = new StackInfo[numberOfStacks];

                for (int i = 0; i < info.Length; i++)
                    info[i] = new StackInfo(defaultCapacity * i, defaultCapacity);

                values = new int[numberOfStacks * defaultCapacity];
            }

            public void Push(int stackNum, int value)
            {
                if (AllStacksAreFull()) throw new FullStackException();

                var stack = info[stackNum];

                if (stack.IsFull())
                    Expand(stackNum);

                stack.size++;

                values[stack.LastElementIndex()] = value;
            }

            public int Pop(int stackNum)
            {
                var stack = info[stackNum];

                if (stack.IsEmpty()) throw new EmptyStackException();

                var value = values[stack.LastElementIndex()];
                values[stack.LastElementIndex()] = 0;
                stack.size--;

                return value;
            }

            public int Peek(int stackNum)
            {
                var stack = info[stackNum];
                if (stack.IsEmpty()) throw new EmptyStackException();

                return values[stack.LastElementIndex()];
            }

            private void Shift(int StackNum)
            {
                var stack = info[StackNum];

                if (stack.size >= stack.capacity)
                {
                    int nextStack = (StackNum + 1) % info.Length;
                    Shift(nextStack);
                    stack.capacity++;
                }

                int index = stack.LastCapacityIndex();
                while (stack.IsWithinStackCapacity(index, values))
                {
                    values[index] = values[PreviousIndex(index)];
                    index = PreviousIndex(index);
                }

                values[stack.start] = 0;
                stack.start = NextIndex(stack.start);
                stack.capacity--;
            }

            private void Expand(int stackNum)
            {
                Shift((stackNum + 1) % info.Length);
                info[stackNum].capacity++;
            }

            private int NumberOfElements()
            {
                int size = 0;
                foreach (var item in info)
                    size += item.size;

                return size;
            }

            private bool AllStacksAreFull()
            {
                return NumberOfElements() == values.Length;
            }

            public static int AdjustIndex(int index)
            {
                int max = values.Length;
                return ((index % max) + max) % max;
            }

            private int NextIndex(int index)
            {
                return AdjustIndex(index + 1);
            }

            public static int PreviousIndex(int index)
            {
                return AdjustIndex(index - 1);
            }


        }
        #endregion
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
