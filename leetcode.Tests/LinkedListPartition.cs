using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace leetcode.Tests
{
    public class LinkedListPartition
    {
        /*  Partition: Write code to partition a linked list around a value x, such that all nodes less than x come
            before all nodes greater than or equal to x. lf x is contained within the list, the values of x only need
            to be after the elements less than x (see below). The partition element x can appear anywhere in the
            "right partition "; it does not need to appear between the left and right partitions.
            EXAMPLE
            Input:  3 -> 5 -> 8 -> 5 -> 10 -> 2 -> 1 [partition = 5)
            Output: 3 -> 1 -> 2 -> 10 -> 5 -> 5 -> 8


            Clarification
            Rephrased question to make it clearer that x doesn't need to be between the partitions: 
            "Partition: Write code to partition a linked list around a value x, such that all nodes 
            less than x come before all nodes greater than or equal to x. (IMPORTANT: The partition 
            element x can appear anywhere in the “right partition”; it does not need to appear 
            between the left and right partitions. The additional spacing the example below indicates 
            the partition.)

            EXAMPLE
            Input: 	3 -> 5 -> 8 -> 5 -> 10 -> 2 -> 1 [partition = 5]
            Output: 	3 -> 1 -> 2       ->        10 -> 5 -> 5 -> 8
        */

        [Theory]
        [InlineData("", true)]
        public void Test(string str, bool expected)
        {
            var actual = Solution.Start(str);
            Assert.Equal(expected, actual);
        }

        public static class Solution
        {
            public static bool Start(string str)
            {
                return false;
            }
        }
    }
}
