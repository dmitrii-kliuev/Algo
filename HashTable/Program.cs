using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            var table = new HashTable<string, string>(10);
            table.Add("Surname", "Petrov");
            table.Add("Name", "Ivan");
            table.Add("City1", "Moscow1");
            table.Add("City2", "Moscow2");
            table.Add("City2", "Moscow5");
            table.Add("City2", "Moscow5");
            table.Add("City36", "Moscow7");
            table.Add("City37", "Moscow7");
            table.Add("City24", "Moscow8");
            table.Add("City22", "Moscow8");
            table.Add("City221", "Moscow82");
            table.Add("City222", "Moscow81");
            table.Add("City225", "Moscow85");
            table.Add("ololo225", "Moscow85");
            table.Add("o123lolo225", "Moscow85");
            table.Add("olo235lo225", "Moscow85");
            table.Add("olo456lo225", "Moscow85");


            var res = table.GetValue("City");

            table.Remove("Name");

            table.Clear();
        }

        public class HashTable<TKey, TValue>
        {
            private int _size;
            private int _totalCount;
            private int _capacity;
            private LinkedList<HashTableItem<TKey, TValue>>[] _table;
            private double maxLoadFactor = 0.75;

            public HashTable(int size)
            {
                _capacity = size;
                _table = new LinkedList<HashTableItem<TKey, TValue>>[_capacity];
            }

            public void Clear()
            {
                _size = 0;
                _table = new LinkedList<HashTableItem<TKey, TValue>>[_capacity];
            }

            public double LoadFactor()
            {
                var res = (double)_size / _capacity;
                return res;
            }

            private int Hash(TKey key)
            {
                return Math.Abs(key.GetHashCode()) % _capacity;
            }

            public void Add(TKey key, TValue value)
            {
                var currentLoadFactor = LoadFactor();
                if (currentLoadFactor >= maxLoadFactor)
                    Resize();

                var hash = Hash(key);

                if (_table[hash] == null)
                {
                    _table[hash] = new LinkedList<HashTableItem<TKey, TValue>>();
                    _size++;
                }

                var tableItem = new HashTableItem<TKey, TValue>(key, value);

                _table[hash].AddFirst(tableItem);
                _totalCount++;
            }

            private void Resize()
            {
                var oldTable = _table;
                _capacity = _capacity * 2;
                _size = 0;
                _totalCount = 0;

                _table = new LinkedList<HashTableItem<TKey, TValue>>[_capacity];

                foreach (var tableItem in oldTable)
                {
                    if (tableItem != null)
                    {
                        foreach (var hashTableItem in tableItem)
                        {
                            Add(hashTableItem.Key, hashTableItem.Value);
                        }
                    }
                }
            }

            public TValue GetValue(TKey key)
            {
                var hash = Hash(key);
                if (_table[hash] == null)
                    return default(TValue);
                
                foreach (var hashTableItem in _table[hash])
                {
                    if (hashTableItem.Key.Equals(key))
                        return hashTableItem.Value;
                }

                throw new Exception("Not found");
            }

            public bool Remove(TKey key)
            {
                var hash = Hash(key);
                if(_table[hash] == null)
                    return false;

                foreach (var hashTableItem in _table[hash])
                {
                    if (hashTableItem.Key.Equals(key))
                    {
                        _table[hash].Remove(hashTableItem);
                        _size--;
                        return true;
                    }
                }

                return false;
            }
        }

        public class HashTableItem<TKey, TValue>
        {
            public TKey Key { get; }
            public TValue Value { get; }

            public HashTableItem(TKey key, TValue value)
            {
                Value = value;
                Key = key;
            }
        }
    }
}
