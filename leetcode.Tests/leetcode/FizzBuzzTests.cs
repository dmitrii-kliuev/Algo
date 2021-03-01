using System.Diagnostics;
using Xunit;

namespace Algo.Tests.leetcode
{
    public class FizzBuzzTests
    {
        /*
            FizzBuzz
            Напишите программу, которая выводит строковое представление от 1 до n. 
            Однако, вместо числа кратного 3 вывести "Fizz", вместо числа кратного 5 вывести "Buzz".

            Для чисел, которые одновременно кратны и 3, и 5 вывести “FizzBuzz”.
         */

        [Fact]
        public void Start()
        {
            FizzBuzz(15);
        }

        private void FizzBuzz(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                if (i % 3 == 0)
                    Debug.WriteLine("Fizz");
                else if (i % 5 == 0)
                    Debug.WriteLine("Buzz");
                else if (i % 3 == 0 && i % 5 == 0)
                    Debug.WriteLine("FizzBuzz");
                else
                    Debug.WriteLine(i);
            }
        }
    }
}
