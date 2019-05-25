﻿using System;
using System.Collections.Generic;
using System.Text;

namespace leetcode.Tests.leetcode
{
    /*
        Given the root node of a binary search tree, 
        return the sum of values of all nodes with value 
        between L and R (inclusive).

        The binary search tree is guaranteed to have unique values.

        Example 1:

        Input: root = [10,5,15,3,7,null,18], L = 7, R = 15
        Output: 32

                10
           5       15
        3     7        18
              ^    ^
              7+10+15 = 32

        Example 2:
        Input: root = [10,5,15,3,7,13,18,1,null,6], L = 6, R = 10
        Output: 23
                      10
                5           15
            3       7    13     18
        1         6
                  ^    ^
                  6+7+10=23
        Note:

        The number of nodes in the tree is at most 10000.
        The final answer is guaranteed to be less than 2^31.*/
    public class RangeSumOfBST
    {

        /**
         * Definition for a binary tree node.
         * public class TreeNode {
         *     public int val;
         *     public TreeNode left;
         *     public TreeNode right;
         *     public TreeNode(int x) { val = x; }
         * }
         */
        public class Solution
        {
            //public int RangeSumBST(TreeNode root, int L, int R)
            //{

            //}
        }
    }
}
