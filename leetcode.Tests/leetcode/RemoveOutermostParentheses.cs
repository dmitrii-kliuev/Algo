using System.Collections.Generic;
using Xunit;

namespace Algo.Tests.leetcode
{
    public class RemoveOutermostParentheses
    {
        /*
           https://leetcode.com/problems/remove-outermost-parentheses/
            A valid parentheses string is either empty (""), "(" + A + ")", or A + B, 
            where A and B are valid parentheses strings, and + represents string concatenation.  
            For example, "", "()", "(())()", and "(()(()))" are all valid parentheses strings.

            A valid parentheses string S is primitive if it is nonempty,
            and there does not exist a way to split it into S = A+B, with A and B nonempty 
            valid parentheses strings.

            Given a valid parentheses string S, consider its primitive decomposition: 
            S = P_1 + P_2 + ... + P_k, where P_i are primitive valid parentheses strings.

            Return S after removing the outermost parentheses of every primitive string 
            in the primitive decomposition of S.

            Example 1:

            Input: "(()())(())"
            Output: "()()()"
            Explanation: 
            The input string is "(()())(())", with primitive decomposition "(()())" + "(())".
            After removing outer parentheses of each part, this is "()()" + "()" = "()()()".


            Example 2:

            Input: "(()())(())(()(()))"
            Output: "()()()()(())"
            Explanation: 
            The input string is "(()())(())(()(()))", with primitive decomposition "(()())" + "(())" + "(()(()))".
            After removing outer parentheses of each part, this is "()()" + "()" + "()(())" = "()()()()(())".

            Example 3:

            Input: "()()"
            Output: ""
            Explanation: 
            The input string is "()()", with primitive decomposition "()" + "()".
            After removing outer parentheses of each part, this is "" + "" = "".

            Note:
            S.length <= 10000
            S[i] is "(" or ")"
            S is a valid parentheses string
         */

        [Theory]
        [InlineData("(()())(())", "()()()")]
        [InlineData("(()())(())(()(()))", "()()()()(())")]
        [InlineData("()()", "")]

        public void Test(string input, string expected)
        {
            var s = new Solution();
            var actual = s.RemoveOuterParentheses(input);
            Assert.Equal(expected, actual);
        }

        private class Solution
        {
            public string RemoveOuterParentheses(string s)
            {
                var stack = new Stack<char>();
                var res = "";
                int openQty = 0;
                int closeQty = 0;
                int qty = 0;

                foreach (var p in s)
                {
                    if (p == '(') openQty++;
                    if (p == ')') closeQty++;
                    qty++;
                    stack.Push(p);

                    if (openQty == closeQty)
                    {
                        stack.Pop();
                        qty--;

                        var tmp = "";
                        for (int i = 0; i < qty - 1; i++)
                            tmp = stack.Pop() + tmp;

                        res += tmp;

                        openQty = 0;
                        closeQty = 0;
                        qty = 0;
                    }
                }

                return res;
            }
        }
    }
}
