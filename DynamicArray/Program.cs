using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DynamicArray
{
    class Program
    {
        static void Main(string[] args)
        {
            var d = new DynamicArray<int>(2);
            d.Add(1);
            d.Add(2);
            d.Add(4);
            d.Add(5);
            d.Add(7);
            d.Add(8);

            d.Insert(100, 2);
            d.Insert(200, 3);
            d.Insert(500, 4);
        }

        public class DynamicArray<T>
        {
            private T[] arr;
            private int count;

            public DynamicArray(int capacity)
            {
                arr = new T[capacity];
            }

            public void Insert(T val, int index)
            {
                if (index > count)
                    return;

                if (IsFull())
                    Resize();

                for (int i = count; i > index; i--)
                    arr[i] = arr[i - 1];
                
                arr[index] = val;
                count++;
            }

            public void Add(T val)
            {
                if(IsFull())
                    Resize();

                arr[count] = val;
                count++;
            }

            private bool IsFull()
            {
                return count == arr.Length;
            }

            private void Resize()
            {
                var newSize = arr.Length == 0 ? 4 : arr.Length * 2;
                var newArr = new T[newSize];
                for (int i = 0; i < arr.Length; i++)
                    newArr[i] = arr[i];

                arr = newArr;
            }
        }
    }
}
