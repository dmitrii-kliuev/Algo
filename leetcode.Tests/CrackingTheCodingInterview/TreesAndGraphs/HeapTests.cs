using System;
using System.Diagnostics;
using Xunit;

namespace Algo.Tests.CrackingTheCodingInterview.TreesAndGraphs
{
    public class HeapTests
    {
        [Fact]
        public void Test()
        {
            var heap = new MinHeap(11);
            heap.InsertKey(3);
            heap.InsertKey(2);
            heap.DeleteKey(1);
            heap.InsertKey(15);
            heap.InsertKey(5);
            heap.InsertKey(4);
            heap.InsertKey(45);

            Debug.Write(heap.ExtractMin() + " ");
            Debug.Write(heap.GetMin() + " ");

            heap.DecreaseKey(2, 1);
            Debug.Write(heap.GetMin());
        }
    }

    /// <summary>
    /// A class for Min Heap 
    /// </summary>
    public class MinHeap
    {
        /// <summary> To store array of elements in heap</summary>
        private int[] HeapArray { get; set; }

        /// <summary>max size of the heap</summary>
        private int Capacity { get; set; }

        /// <summary>Current number of elements in the heap</summary>
        private int CurrentHeapSize { get; set; }

        public MinHeap(int capacity)
        {
            this.Capacity = capacity;
            HeapArray = new int[capacity];
            CurrentHeapSize = 0;
        }

        private static void Swap<T>(ref T left, ref T right)
        {
            var tmp = left;
            left = right;
            right = tmp;
        }

        /// <summary>Get the Parent index for the given index</summary>
        private int Parent(int key)
        {
            return (key - 1) / 2;
        }


        // Get the Left Child index for the given index
        public int Left(int key)
        {
            return 2 * key + 1;
        }

        // Get the Right Child index for the given index
        public int Right(int key)
        {
            return 2 * key + 2;
        }

        public bool InsertKey(int key)
        {
            if (CurrentHeapSize == Capacity)
            {
                // heap is full
                return false;
            }

            var i = CurrentHeapSize;
            HeapArray[i] = key;
            CurrentHeapSize++;

            while (i != 0
                   && HeapArray[i] < HeapArray[Parent(i)])
            {
                Swap(ref HeapArray[i], ref HeapArray[Parent(i)]);
                i = Parent(i);
            }

            return true;
        }

        // Decreases value of given key to new_val. 
        // It is assumed that new_val is smaller 
        // than heapArray[key].
        public void DecreaseKey(int key, int newVal)
        {
            HeapArray[key] = newVal;

            while (key != 0
                   && HeapArray[key] < HeapArray[Parent(key)])
            {
                Swap(ref HeapArray[key], ref HeapArray[Parent(key)]);
                key = Parent(key);
            }
        }

        public int GetMin()
        {
            return HeapArray[0];
        }

        public int ExtractMin()
        {
            if (CurrentHeapSize <= 0)
            {
                throw new Exception("heap is empty");
            }

            if (CurrentHeapSize == 1)
            {
                CurrentHeapSize--;
                return HeapArray[0];
            }

            var root = HeapArray[0];

            HeapArray[0] = HeapArray[CurrentHeapSize - 1];
            CurrentHeapSize--;
            MinHeapify(0);

            return root;
        }

        public void DeleteKey(int key)
        {
            DecreaseKey(key, int.MinValue);
            ExtractMin();
        }

        private void MinHeapify(int key)
        {
            var left = Left(key);
            var right = Right(key);

            var smallest = key;

            if (left < CurrentHeapSize
                && HeapArray[left] < HeapArray[smallest])
            {
                smallest = left;
            }

            if (right < CurrentHeapSize
                && HeapArray[right] < HeapArray[smallest])
            {
                smallest = right;
            }

            if (smallest != key)
            {
                Swap(ref HeapArray[key], ref HeapArray[smallest]);
                MinHeapify(smallest);
            }
        }

        public void IncreaseKey(int key, int newVal)
        {
            HeapArray[key] = newVal;
            MinHeapify(key);
        }

        public void ChangeValueOnAKey(int key, int newVal)
        {
            if (HeapArray[key] == newVal)
            {
                return;
            }

            if (HeapArray[key] < newVal)
            {
                IncreaseKey(key, newVal);
            }
            else
            {
                DecreaseKey(key, newVal);
            }
        }
    }
}
