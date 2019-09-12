using System.Diagnostics;
using Xunit;

namespace leetcode.Tests
{
    public class StringPermutation
    {
        [Fact]
        public void test()
        {
            Solution.Start("abc");
        }

        public class Solution
        {
            static int count = 0;
            public static void Start(string str)
            {
                string input = str;

                Permutations(input.ToLower().ToCharArray(), 0, input.Length - 1);

                Debug.WriteLine("Total Permutations :{0}", count);
            }


            public static char[] Swap(char[] input, int by, int with)
            {

                char c = input[by];
                input[by] = input[with];
                input[with] = c;

                return input;
            }


            public static void Permutations(char[] input, int left, int right)
            {

                if (left == right)
                {
                    Debug.WriteLine(new string(input));
                    count++;

                }
                else
                {

                    for (int i = left; i <= right; i++)
                    {
                        input = Swap(input, left, i);
                        Permutations(input, left + 1, right);
                        input = Swap(input, left, i);
                    }

                }

            }
        }
    }
}
