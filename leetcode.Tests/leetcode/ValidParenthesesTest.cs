using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace leetcode.Tests.leetcode
{
    public class ValidParenthesesTest
    {
        [Theory]
        [InlineData("()", true)]
        [InlineData("()[]{}", true)]
        [InlineData("(]", false)]
        [InlineData("([)]", false)]
        [InlineData("{[]}", true)]
        [InlineData("{{({})}}", true)]
        [InlineData("]", false)]
        [InlineData("", true)]
        [InlineData("{{}[][[[]]]}", true)]
        [InlineData("){", false)]
        [InlineData("((", false)]
        public void ValidParentheses(string str, bool expected)
        {
            var s = new Solution();
            var actual = s.IsValid(str);
            Assert.Equal(expected, actual);
        }

        public class Solution
        {
            public bool IsValid(string s)
            {
                var stack = new Stack<char>();

                bool res = true;

                if (s == "") return true;

                if (s.Length == 1) return false;

                foreach (var c in s)
                {
                    if (stack.Count == 0 && (c == ')' || c == ']' || c == '}'))
                    {
                        res = false;
                        break;
                    }

                    if (c == '(' || c == '[' || c == '{')
                        stack.Push(c);
                    else
                    {
                        var d = stack.Pop();
                        if (d == '{' && c != '}')
                        {
                            res = false;
                            break;
                        }

                        if (d == '(' && c != ')')
                        {
                            res = false;
                            break;
                        }

                        if (d == '[' && c != ']')
                        {
                            res = false;
                            break;
                        }
                    }
                }

                if (stack.Count != 0)
                    return false;

                return res;
            }
        }

        public class Solution2
        {
            public bool IsValid(string x)
            {
                var s = new Stack<char>();
                var open = new char[] { '(', '{', '[' };
                for (int i = 0; i < x.Length; i++)
                {
                    var c = x[i];
                    if (!open.Contains(c) && s.Count == 0)
                        return false;
                    if (open.Contains(c))
                        s.Push(c);
                    else
                    {
                        if (
                            (c == '}' && s.Peek() == '{') ||
                            (c == ')' && s.Peek() == '(') ||
                            (c == ']' && s.Peek() == '[')
                        )
                            s.Pop();
                        else
                            return false;
                    }
                }
                return s.Count == 0;

            }
        }
    }
}
