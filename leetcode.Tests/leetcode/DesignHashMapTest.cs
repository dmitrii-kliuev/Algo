using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace leetcode.Tests.leetcode
{
    public class DesignHashMapTest
    {
        /*Design a HashMap without using any built-in hash table libraries.

To be specific, your design should include these functions:

put(key, value) : Insert a (key, value) pair into the HashMap. If the value already exists in the HashMap, update the value.
get(key): Returns the value to which the specified key is mapped, or -1 if this map contains no mapping for the key.
remove(key) : Remove the mapping for the value key if this map contains the mapping for the key.

Example:

MyHashMap hashMap = new MyHashMap();
hashMap.put(1, 1);          
hashMap.put(2, 2);         
hashMap.get(1);            // returns 1
hashMap.get(3);            // returns -1 (not found)
hashMap.put(2, 1);          // update the existing value
hashMap.get(2);            // returns 1 
hashMap.remove(2);          // remove the mapping for 2
hashMap.get(2);            // returns -1 (not found) 

Note:

All keys and values will be in the range of [0, 1000000].
The number of operations will be in the range of [1, 10000].
Please do not use the built-in HashMap library.*/

        [Fact]
        public void Test()
        {
            var hashMap = new MyHashMap();
            hashMap.Put(1, 1);
            hashMap.Put(2, 2);
            Assert.Equal(1, hashMap.Get(1));    // returns 1
            Assert.Equal(-1, hashMap.Get(3));   // returns -1 (not found)
            hashMap.Put(2, 1);                  // update the existing value
            Assert.Equal(1, hashMap.Get(2));    // returns 1 
            hashMap.Remove(2);                  // remove the mapping for 2
            Assert.Equal(-1, hashMap.Get(2));   // returns -1 (not found) 
        }

        public class MyHashMap
        {
            private LinkedList<HashTableItem>[] _hashTable;

            private int _capacity = 1000000;
            /** Initialize your data structure here. */
            public MyHashMap()
            {
                _hashTable = new LinkedList<HashTableItem>[_capacity];
            }

            /** value will always be non-negative. */
            public void Put(int key, int value)
            {
                var hash = key.GetHashCode() % _capacity;

                var item = new HashTableItem(key, value);
                _hashTable[hash] = new LinkedList<HashTableItem> {item};
            }

            /** Returns the value to which the specified key is mapped, or -1 if this map contains no mapping for the key */
            public int Get(int key)
            {
                var hash = key.GetHashCode() % _capacity;
                var res = _hashTable[hash];

                if (res == null) return -1;

                foreach (var hashTableItem in res)
                {
                    if (hashTableItem.Key == key)
                        return hashTableItem.Value;
                }

                //if (res != null)
                //    return res.Value.Value;

                return -1;
            }

            /** Removes the mapping of the specified value key if this map contains a mapping for the key */
            public void Remove(int key)
            {
                var hash = key.GetHashCode() % _capacity;
                _hashTable[hash] = null;
            }

            public class HashTableItem
            {
                public int Key { get; }
                public int Value { get; }

                public HashTableItem(int key, int value)
                {
                    Key = key;
                    Value = value;
                }
            }

            public class LinkedList<T> : IEnumerable<T>
            {
                public int Count;
                private ListNode<T> _head;
                private ListNode<T> _tail;

                public void Remove(T value)
                {
                    ListNode<T> prev = null;
                    ListNode<T> current = _head;

                    while (current != null)
                    {
                        if (current.Value.Equals(value))
                        {
                            if (prev == null)
                            {
                                _head = _head.Next;
                                Count--;
                                break;
                            }

                            if (current.Next == null)
                            {
                                prev.Next = null;
                                _tail = prev;
                                Count--;
                                break;
                            }

                            if (current.Next != null)
                            {
                                prev.Next = current.Next;
                                Count--;
                                break;
                            }
                        }

                        prev = current;
                        current = current.Next;
                    }

                    if (_head == null)
                    {
                        _tail = null;
                    }
                }

                public void RemoveAt(int index)
                {
                    if (Count == 0)
                        return;

                    ListNode<T> prev = null;
                    ListNode<T> current = _head;
                    var i = 0;

                    while (i != index)
                    {
                        prev = current;
                        current = current.Next;
                        i++;

                        if (i == Count)
                            return;
                    }

                    if (current.Next == null && prev != null)
                    {
                        prev.Next = null;
                        Count--;
                        return;
                    }

                    if (prev != null)
                    {
                        prev.Next = current.Next;
                        Count--;
                        return;
                    }

                    if (prev == null)
                    {
                        _head = _head.Next;
                        Count--;
                    }
                }

                public void Add(T newValue)
                {
                    var newNode = new ListNode<T>(newValue);

                    if (_head == null)
                    {
                        _head = newNode;
                        _tail = _head;
                    }
                    else
                    {
                        _tail.Next = newNode;
                        _tail = _tail.Next;
                    }

                    Count++;
                }

                public ListNode<T> GetItem(int index)
                {
                    if (index + 1 > Count)
                        throw new Exception("Out of range.");

                    var qty = 0;
                    var currentItem = _head;

                    while (qty != index)
                    {
                        currentItem = currentItem.Next;
                        qty++;
                    }

                    return currentItem;
                }

                public T GetValue(int index)
                {
                    return GetItem(index).Value;
                }

                public void Clear()
                {
                    _head = null;
                    _tail = null;
                    Count = 0;
                }

                public void Print()
                {
                    var currentNode = _head;
                    while (currentNode != null)
                    {
                        Console.WriteLine(currentNode.Value);
                        currentNode = currentNode.Next;
                    }
                }

                public IEnumerator<T> GetEnumerator()
                {
                    var current = _head;
                    while (current != null)
                    {
                        yield return current.Value;
                        current = current.Next;
                    }
                }

                IEnumerator IEnumerable.GetEnumerator()
                {
                    return GetEnumerator();
                }
            }

            public class ListNode<T>
            {
                public T Value;
                public ListNode<T> Next;

                public ListNode(T value)
                {
                    Value = value;
                }
            }
        }

        /**
         * Your MyHashMap object will be instantiated and called as such:
         * MyHashMap obj = new MyHashMap();
         * obj.Put(key,value);
         * int param_2 = obj.Get(key);
         * obj.Remove(key);
         */
    }
}
