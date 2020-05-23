namespace SelectionSort
{
    internal class Program
    {
        private static void Main()
        {
            var arr = new[] { 7, 10, 5, 2, 4, 0, 1 };
            SelectionSort(arr);
        }

        private static void SelectionSort(int[] arr)
        {
            var sortedIndexEndRange = 0;
            while (sortedIndexEndRange != arr.Length)
            {
                var minIndex = FindMinIndex(arr, sortedIndexEndRange);
                Swap(arr, minIndex, sortedIndexEndRange);
                sortedIndexEndRange++;
            }
        }

        private static void Swap(int[] arr, int minIndex, int sortedIndexEndRange)
        {
            var tmp = arr[sortedIndexEndRange];
            arr[sortedIndexEndRange] = arr[minIndex];
            arr[minIndex] = tmp;
        }

        private static int FindMinIndex(int[] arr, int sortedIndexEndRange)
        {
            int minIndex = sortedIndexEndRange;
            int minValue = arr[sortedIndexEndRange];
            for (int i = sortedIndexEndRange; i < arr.Length; i++)
            {
                if (arr[i] < minValue)
                {
                    minValue = arr[i];
                    minIndex = i;
                }
            }

            return minIndex;
        }

        public static int FindMaxIndex(int[] arr, int sortedIndexEndRange)
        {
            int maxIndex = sortedIndexEndRange;
            int maxValue = arr[sortedIndexEndRange];
            for (int i = sortedIndexEndRange; i < arr.Length; i++)
            {
                if (arr[i] > maxValue)
                {
                    maxValue = arr[i];
                    maxIndex = i;
                }
            }

            return maxIndex;
        }
    }
}
