using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Set
{
    class Program
    {
        static void Main(string[] args)
        {
            var set = new SimpleSet<int>();
            set.Add(1);
            set.Add(5);
            set.Add(7);
            set.Add(8);
            set.Add(0);
            set.Add(2);
            set.Add(4);

            var unionRes = set.MyUnion(new SimpleSet<int> {100, 200, 500});

            var intersectionRes = set.MyIntersection(new SimpleSet<int> {1, 4, 0});

            var differenceRes = set.Difference(new SimpleSet<int> {100, 200, 7, 8, 1, 0});

            var symmetricDifference = set.SymmetricDifference(new SimpleSet<int> { 1, 8, 0, 4, 25, 77, 100}); // 5, 7, 2, 25, 77, 100

            var isSUbset = set.IsSubset(new SimpleSet<int> {5, 4, 1});
            var notIsSUbset = set.IsSubset(new SimpleSet<int> { 5, 4, 1 , 100});
        }

        public class SimpleSet<T> : IEnumerable<T> where  T : IComparable
        {
            private readonly List<T> _items = new List<T>();

            public SimpleSet()
            {
                
            }

            public SimpleSet(IEnumerable<T> items)
            {
                AddRange(items);
            }

            private void AddRange(IEnumerable<T> items)
            {
                foreach (var item in items)
                {
                    Add(item);
                }
            }

            public void Add(T value)
            {
                if (_items.Contains(value))
                    throw new Exception("Такой элемент уже содержится во множестве");

                _items.Add(value);
            }

            public SimpleSet<T> MyUnion(SimpleSet<T> other)
            {
                var result = new SimpleSet<T>(_items);
                foreach (var otherItem in other)
                {
                    if(!_items.Contains(otherItem))
                        result.Add(otherItem);
                }

                return result;
            }

            public SimpleSet<T> MyIntersection(SimpleSet<T> other)
            {
                var result = new SimpleSet<T>();
                foreach (var item in _items)
                {
                    if(other.Contains(item))
                        result.Add(item);
                }

                return result;
            }

            public SimpleSet<T> Difference(SimpleSet<T> other)
            {
                var result = new SimpleSet<T>(_items);
                foreach (var otherItem in other)
                {
                    if (_items.Contains(otherItem))
                        result.Remove(otherItem);
                }

                return result;
            }

            public SimpleSet<T> SymmetricDifference(SimpleSet<T> other)
            {
                var c = this.Difference(other);
                var d = other.Difference(this);

                var result = c.MyUnion(d);

                return result;
            }

            public bool IsSubset(SimpleSet<T> other)
            {
                var result = new SimpleSet<T>(other);
                foreach (var item in _items)
                    result.Remove(item);

                return !result.Any();
            }

            private void Remove(T val)
            {
                _items.Remove(val);
            }

            public IEnumerator<T> GetEnumerator()
            {
                foreach (var item in _items)
                {
                    yield return item;
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
}
