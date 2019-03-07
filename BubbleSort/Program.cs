using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[] { 5, 4, 3, 2, 1};
            var bs = new BubbleSort();
            bs.SortIncrease(arr);
            
            Console.WriteLine();
            Console.WriteLine();
            bs.SortDecrease(arr);
            
            Console.ReadKey();
        }
        
        public class BubbleSort
        {
            public void SortIncrease(int[] arr)
            {
                Display(arr);
                Console.WriteLine();

                for (int i = 0; i < arr.Length - 1; i++)
                {
                    for (int j = 0; j < arr.Length - i - 1; j++)
                    {
                        if (arr[j] > arr[j + 1])
                        {
                            var buf = arr[j];
                            arr[j] = arr[j + 1];
                            arr[j + 1] = buf;

                            Display(arr);
                            Console.WriteLine();
                        }
                    }
                }
            }

            public void SortDecrease(int[] arr)
            {
                Display(arr);
                Console.WriteLine();

                for (int i = 0; i < arr.Length - 1; i++)
                {
                    for (int j = 0; j < arr.Length - i - 1; j++)
                    {
                        if (arr[j] < arr[j + 1])
                        {
                            var buf = arr[j];
                            arr[j] = arr[j + 1];
                            arr[j + 1] = buf;

                            Display(arr);
                            Console.WriteLine();
                        }
                    }
                }
            }

            public void Display(int[] arr)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    Console.Write(arr[i] + " ");
                }
            }
        }
    }
}
