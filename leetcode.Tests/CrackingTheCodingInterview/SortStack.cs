using Algo.Tests.leetcode;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace Algo.Tests.CrackingTheCodingInterview
{
    public class SortStack
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public SortStack(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        /*3.5   Sort Stack: Write a program to sort a stack such that the smallest items are on the top. You can use
                an additional temporary stack, but you may not copy the elements into any other data structure
                (such as an array). The stack supports the following operations: push, pop, peek, and isEmpty.*/
        [Fact]
        public void MySolutionTest()
        {
            var lst = new List<int> { 8, 4, 1, 2, 5, 1, 2 };
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

            lst.Sort();
            Assert.Equal(lst, sorted);
        }

        [Fact]
        public void SecondSolutionTest()
        {
            var lst = new List<int> { 8, 4, 1, 2, 5 };
            var stack = new MyStack<int>();

            foreach (var item in lst)
            {
                stack.Push(item);
            }

            SortStackSecondSolution.Sort(stack, _testOutputHelper);

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

                var skipped = false;
                for (var j = 0; j < i; j++)
                {
                    var item = secondStack.Pop();
                    if (item == smallest && !skipped)
                    {
                        skipped = true;
                    }
                    else
                    {
                        mainStack.Push(item);
                    }
                }

                secondStack.Push(smallest);
            }

            while (!secondStack.IsEmpty())
            {
                mainStack.Push(secondStack.Pop());
            }
        }
    }

    public static class SortStackSecondSolution
    {
        public static void Sort(MyStack<int> mainStack, ITestOutputHelper testOutputHelper)
        {
            if (mainStack == null || mainStack.IsEmpty() || testOutputHelper == null) return;

            var secondStack = new MyStack<int>();

            testOutputHelper.WriteLine("\t\t\t\ttop\t\ttail");
            while (!mainStack.IsEmpty())
            {
                PrintStack(mainStack, testOutputHelper, "mainStack:\t\t");
                PrintStack(secondStack, testOutputHelper, "secondStack:\t");

                var tmp = mainStack.Pop();
                while (!secondStack.IsEmpty() && secondStack.Top() > tmp)
                {
                    mainStack.Push(secondStack.Pop());
                }

                secondStack.Push(tmp);
            }

            while (!secondStack.IsEmpty())
            {
                mainStack.Push(secondStack.Pop());
            }

            testOutputHelper.WriteLine("result:");
            PrintStack(mainStack, testOutputHelper, "mainStack:\t\t");
        }

        private static void PrintStack(MyStack<int> stack, ITestOutputHelper testOutputHelper, string info)
        {
            var secondStack = new MyStack<int>();
            var sb = new StringBuilder();

            while (!stack.IsEmpty())
            {
                var tmp = stack.Pop();
                sb.Append($"{tmp} ");
                secondStack.Push(tmp);
            }

            testOutputHelper.WriteLine($"{info} {sb}");

            while (!secondStack.IsEmpty())
            {
                stack.Push(secondStack.Pop());
            }
        }
    }
}
