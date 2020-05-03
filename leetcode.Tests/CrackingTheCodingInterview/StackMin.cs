using leetcode.Tests.leetcode;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace leetcode.Tests.CrackingTheCodingInterview
{
    public class StackMin
    {
        /*
         3.2 Stack Min: How would you design a stack which, in addition to push and pop, has a function min
            which returns the minimum element? Push, pop and min should all operate in 0(1) time.
        */

        [Fact]
        public void StackMitTest()
        {
            var s = new MyStackWithMin<int>();
            s.Push(5);
            Assert.Equal(5, s.Min().Min);
            s.Push(10);
            s.Push(4);
            s.Push(8);
            Assert.Equal(4, s.Min().Min);
            s.Push(4);
            Assert.Equal(4, s.Min().Min);
            s.Push(9);
            s.Push(10);
            s.Push(4);
            s.Push(1);

            Assert.Equal(1, s.Min().Min);

            s.Pop(); // 1
            Assert.Equal(4, s.Min().Min);
            s.Pop(); // 4
            s.Pop(); // 10
            s.Pop(); // 9
            Assert.Equal(4, s.Min().Min);
            s.Pop(); // 4
            Assert.Equal(4, s.Min().Min);
            s.Pop(); // 8
            s.Pop(); // 4
            s.Pop(); // 10
            Assert.Equal(5, s.Min().Min);
            s.Pop();
            Assert.True(s.Empty());
        }

    }

    public class MinElem<T>
    {
        public T Min { get; set; }
        public int Quantity { get; set; }
    }

    public class MyStackWithMin<T> : MyStack<T> where T : IComparable
    {
        private readonly MyStack<MinElem<T>> _stackMin;

        public MyStackWithMin()
        {
            _stackMin = new MyStack<MinElem<T>>();
        }

        public override void Push(T val)
        {
            if (_stackMin.Empty())
            {
                _stackMin.Push(new MinElem<T> { Min = val, Quantity = 0 });
                base.Push(val);
                return;
            }

            var minElem = Min();

            if (val.CompareTo(minElem.Min) < 0)
            {
                _stackMin.Push(new MinElem<T> { Min = val, Quantity = 0 });
            }
            else if (val.CompareTo(minElem.Min) == 0)
            {
                minElem.Quantity++;
            }

            base.Push(val);
        }

        public override T Pop()
        {
            var val = base.Pop();

            var minElem = Min();
            if (val.CompareTo(minElem.Min) == 0 && minElem.Quantity == 0)
                _stackMin.Pop();
            else if (val.CompareTo(minElem.Min) == 0)
                minElem.Quantity--;

            return val;
        }

        public MinElem<T> Min()
        {
            if (_stackMin.Empty())
                throw new Exception("Stack is empty!");

            return _stackMin.Top();
        }
    }

}
