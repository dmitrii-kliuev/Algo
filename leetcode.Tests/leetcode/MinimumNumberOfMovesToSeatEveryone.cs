﻿using System;
using System.Collections.Generic;
using Xunit;

namespace Algo.Tests.leetcode
{
    public class MinimumNumberOfMovesToSeatEveryone
    {
        /*
            There are n availabe seats and n students standing in a room. You are given an array seats of length n, where seats[i] is the position of the ith seat. You are also given the array students of length n, where students[j] is the position of the jth student.

            You may perform the following move any number of times:

            Increase or decrease the position of the ith student by 1 (i.e., moving the ith student from position x to x + 1 or x - 1)
            Return the minimum number of moves required to move each student to a seat such that no two students are in the same seat.

            Note that there may be multiple seats or students in the same position at the beginning.

 

            Example 1:

            Input: seats = [3,1,5], students = [2,7,4]
            Output: 4
            Explanation: The students are moved as follows:
            - The first student is moved from position 2 to position 1 using 1 move.
            - The second student is moved from position 7 to position 5 using 2 moves.
            - The third student is moved from position 4 to position 3 using 1 move.
            In total, 1 + 2 + 1 = 4 moves were used.
         */

        [Theory]
        [InlineData(new int[] { 3, 1, 5 }, new int[] { 2, 7, 4 }, 4)]
        public void Test(int[] seats, int[] students, int expected)
        {
            var actual = MinMovesToSeat(seats, students);
            Assert.Equal(expected, actual);
        }

        public int MinMovesToSeat(int[] seats, int[] students)
        {
            Array.Sort(seats);
            Array.Sort(students);

            var movements = 0;
            for (int i = 0; i < seats.Length; i++)
            {
                movements += Math.Abs(seats[i] - students[i]);
            }

            return movements;
        }
    }
}
