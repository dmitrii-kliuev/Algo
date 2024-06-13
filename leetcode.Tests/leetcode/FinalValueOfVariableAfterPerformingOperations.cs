using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Algo.Tests.leetcode
{
    public class FinalValueOfVariableAfterPerformingOperations
    {
        [Fact]
        public void Test()
        {
            var expected = 1;
            var operations = new string[] { "--X", "X++", "X++" };
            var actual = FinalValueAfterOperations(operations);

            Assert.Equal(expected, actual);
        }

        public int FinalValueAfterOperations(string[] operations)
        {
            var res = 0;
            foreach (var operation in operations)
            {
                if (operation == "X++" || operation == "++X")
                    res++;

                if (operation == "X--" || operation == "--X")
                    res--;
            }

            return res;
        }
    }
}
