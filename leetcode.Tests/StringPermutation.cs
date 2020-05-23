using System.Diagnostics;
using Xunit;

namespace Algo.Tests
{
    public class StringPermutation
    {
        [Fact]
        public void Test()
        {
            Solution.Start("abc");
        }

        public class Solution
        {
            private static int _count;
            public static void Start(string str)
            {
                string input = str;

                Permutations(input.ToLower().ToCharArray(), 0, input.Length - 1);

                Debug.WriteLine("Total Permutations :{0}", _count);
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
                    _count++;

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
