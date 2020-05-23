namespace DynamicArray
{
    internal class Program
    {
        private static void Main()
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
            private T[] _arr;
            private int _count;

            public DynamicArray(int capacity)
            {
                _arr = new T[capacity];
            }

            public void Insert(T val, int index)
            {
                if (index > _count)
                    return;

                if (IsFull())
                    Resize();

                for (int i = _count; i > index; i--)
                    _arr[i] = _arr[i - 1];

                _arr[index] = val;
                _count++;
            }

            public void Add(T val)
            {
                if (IsFull())
                    Resize();

                _arr[_count] = val;
                _count++;
            }

            private bool IsFull()
            {
                return _count == _arr.Length;
            }

            private void Resize()
            {
                var newSize = _arr.Length == 0 ? 4 : _arr.Length * 2;
                var newArr = new T[newSize];
                for (int i = 0; i < _arr.Length; i++)
                    newArr[i] = _arr[i];

                _arr = newArr;
            }
        }
    }
}
