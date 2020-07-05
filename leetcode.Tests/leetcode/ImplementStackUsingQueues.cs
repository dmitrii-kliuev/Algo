using System;
using Xunit;

namespace Algo.Tests.leetcode
{
    public class ImplementStackUsingQueues
    {
        [Fact]
        public void Test()
        {
            var s = new MyStack<int>();
            s.Push(4);
            s.Push(1);
            s.Pop();
            s.Pop();
        }
    }

    public class MyStack<T>
    {
        public class ListNode
        {
            public T val;
            public ListNode next;

            public ListNode(T x) { val = x; }
        }

        public int Quantity { get; set; }

        private ListNode _root;

        /** Initialize your data structure here. */
        public MyStack()
        {
            _root = null;
        }

        /** Push element x onto stack. */
        public virtual void Push(T x)
        {
            var newItem = new ListNode(x) { next = _root };
            _root = newItem;
            Quantity++;
        }

        /** Removes the element on top of the stack and returns that element. */
        public virtual T Pop()
        {
            if (!Empty())
            {
                var res = _root.val;
                _root = _root.next;

                Quantity--;

                return res;
            }

            throw new Exception();
        }

        /** Get the top element. */
        public T Top()
        {
            if (!Empty())
                return _root.val;

            throw new Exception("error!");
        }

        /** Returns whether the stack is empty. */
        public bool Empty()
        {
            if (_root == null)
                return true;

            return false;
        }
    }

    /*
     * Your MyStack object will be instantiated and called as such:
     * MyStack obj = new MyStack();
     * obj.Push(x);
     * int param_2 = obj.Pop();
     * int param_3 = obj.Top();
     * bool param_4 = obj.Empty();
     */
}
