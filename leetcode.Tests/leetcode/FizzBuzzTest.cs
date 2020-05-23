using System.Diagnostics;
using Xunit;

namespace Algo.Tests.leetcode
{
    public class FizzBuzzTest
    {
        [Fact]
        public void Start()
        {
            FizzBuzz(15);
        }

        private void FizzBuzz(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                    Debug.WriteLine("FizzBuzz");
                else if (i % 3 == 0)
                    Debug.WriteLine("Fizz");
                else if (i % 5 == 0)
                    Debug.WriteLine("Buzz");
                else
                    Debug.WriteLine(i.ToString());
            }
        }
    }


}
