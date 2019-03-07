using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace leetcode.Tests.leetcode
{
    public class ImplementStackUsingQueues
    {
        [Fact]
        public void Test()
        {
            var s = new MyStack();
            s.Push(4);
            s.Push(1);
            var p1 = s.Pop();
            var p4 = s.Pop();
        }



        public class MyStack
        {
            public class ListNode
            {
                public int val;
                public ListNode next;

                public ListNode(int x) { val = x; }
            }

            private int _size = 0;
            private ListNode _root;

            /** Initialize your data structure here. */
            public MyStack()
            {
                _size = 0;
                _root = null;
            }

            /** Push element x onto stack. */
            public void Push(int x)
            {
                var newItem = new ListNode(x) { next = _root };
                _size++;
                _root = newItem;
            }

            /** Removes the element on top of the stack and returns that element. */
            public int Pop()
            {
                if (!Empty())
                {
                    var res = _root.val;
                    _root = _root.next;
                    _size--;
                    return res;
                }

                throw new Exception();
            }

            /** Get the top element. */
            public int Top()
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

        /**
         * Your MyStack object will be instantiated and called as such:
         * MyStack obj = new MyStack();
         * obj.Push(x);
         * int param_2 = obj.Pop();
         * int param_3 = obj.Top();
         * bool param_4 = obj.Empty();
         */
    }
}
