using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace leetcode.Tests
{
    public class TurnMatrix90degree
    {
        [Fact]
        public void Test()
        {
            var matrix = new int[4][]
            {
                new int[5]{ 1, 2, 3, 4, 5 },
                new int[5]{ 1, 2, 3, 4, 5 },
                new int[5]{ 1, 2, 3, 4, 5 },
                new int[5]{ 1, 2, 3, 4, 5 }
            };

            var expected = new int[5][]
            {
                new int[4]{ 1, 1, 1, 1 },
                new int[4]{ 2, 2, 2, 2 },
                new int[4]{ 3, 3, 3, 3 },
                new int[4]{ 4, 4, 4, 4 },
                new int[4]{ 5, 5, 5, 5 }
            };

            var actual = new int[5, 4];

            var size0 = matrix.GetLength(0);

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {

                }
            }

            //var actual = Solution.Start("");
            //Assert.Equal("", actual);
        }

        public static class Solution
        {
            public static string Start(string str)
            {
                return "";
            }
        }

    }
}
