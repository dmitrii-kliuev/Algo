using Algo.Tests.leetcode;
using System.Collections.Generic;
using Xunit;

namespace Algo.Tests.CrackingTheCodingInterview
{
    public class SortStack
    {
        /*3.5   Sort Stack: Write a program to sort a stack such that the smallest items are on the top. You can use
                an additional temporary stack, but you may not copy the elements into any other data structure
                (such as an array). The stack supports the following operations: push, pop, peek, and isEmpty.*/
        [Fact]
        public void Test()
        {
            var lst = new List<int> { 8, 4, 1, 2, 5 };
            var stack = new MyStack<int>();

            foreach (var item in lst)
            {
                stack.Push(item);
            }

            SortStackSolution.Sort(stack);

            var sorted = new List<int>();
            while (!stack.IsEmpty())
            {
                sorted.Add(stack.Pop());
            }

            var expected = new List<int> { 1, 2, 4, 5, 8 };
            Assert.Equal(expected, sorted);
        }
    }

    public static class SortStackSolution
    {
        public static void Sort(MyStack<int> mainStack)
        {
            if (mainStack == null || mainStack.IsEmpty()) return;

            var secondStack = new MyStack<int>();

            var totalQty = mainStack.Quantity;


            for (var i = totalQty; i > 0; i--)
            {
                var smallest = mainStack.Top();

                for (var j = 0; j < i; j++)
                {
                    var current = mainStack.Pop();
                    if (current < smallest) smallest = current;
                    secondStack.Push(current);
                }

                for (var j = 0; j < i; j++)
                {
                    var item = secondStack.Pop();
                    if (item != smallest)
                        mainStack.Push(item);
                }

                secondStack.Push(smallest);
            }

            while (!secondStack.IsEmpty())
            {
                mainStack.Push(secondStack.Pop());
            }
        }
    }
}
