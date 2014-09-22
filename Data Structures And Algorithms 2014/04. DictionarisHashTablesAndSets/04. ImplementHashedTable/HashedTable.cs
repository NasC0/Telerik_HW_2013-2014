using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ImplementHashedTable
{
    public class HashedTable<K, T> : IHashedTable<K, T>, IEnumerable<KeyValuePair<K, T>>
    {
        private const int InitialCapacity = 16;

        private LinkedList<KeyValuePair<K, T>>[] elements;
        private int count;
        private int capacity;

        public HashedTable()
        {
            this.elements = new LinkedList<KeyValuePair<K, T>>[InitialCapacity];
            this.Capacity = InitialCapacity;
            this.Count = 0;
        }

        public int Count
        {
            get
            {
                return this.count;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Elements count cannot be negative.");
                }

                this.count = value;
            }
        }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Array capacity cannot be negative.");
                }

                this.capacity = value;
            }
        }

        public T this[K key]
        {
            get
            {
                return this.Find(key);
            }
            set
            {
                try
                {
                    int hash = this.GetHashedValue(key);
                    var elements = this.elements[hash];

                    if (elements != null)
                    {
                        if (elements.Any(x => x.Key.Equals(key)))
                        {
                            var searchedElement = elements.First(x => x.Key.Equals(key));
                            elements.Remove(searchedElement);
                        }

                        KeyValuePair<K, T> newPair = new KeyValuePair<K, T>(key, value);
                        elements.AddLast(newPair);
                    }
                    else
                    {
                        this.Add(key, value);
                    }
                }
                catch (Exception ex)
                {
                    throw new ArgumentException("Could not set element.");
                }
            }
        }

        public void Add(K key, T value)
        {
            int hash = this.GetHashedValue(key);

            if (this.elements[hash] == null)
            {
                this.elements[hash] = new LinkedList<KeyValuePair<K, T>>();
            }

            var pair = new KeyValuePair<K, T>(key, value);
            this.elements[hash].AddLast(pair);
            this.Count++;

            if (this.Count >= this.Capacity * 0.75)
            {
                this.ResizeArray();
            }
        }

        public T Find(K key)
        {
            var pair = this.FindPair(key);
            return pair.Value;
        }

        public T Remove(K key)
        {
            int hash = this.GetHashedValue(key);
            var elements = this.elements[hash];

            if (elements != null)
            {
                if (elements.Any(x => x.Key.Equals(key)))
                {
                    var element = elements.FirstOrDefault(x => x.Key.Equals(key));
                    elements.Remove(element);
                    this.Count--;
                    return element.Value;
                }
            }

            throw new ArgumentException("Key not found.");
        }

        public void Clear()
        {
            this.elements = new LinkedList<KeyValuePair<K, T>>[this.Capacity];
            this.Count = 0;
        }

        public IEnumerator<KeyValuePair<K, T>> GetEnumerator()
        {
            foreach (var list in this.elements)
            {
                if (list != null)
                {
                    foreach (var pair in list)
                    {
                        yield return pair;
                    }
                }
            }
        }

        private void ResizeArray()
        {
            this.Capacity *= 2;
            var resizedArray = new LinkedList<KeyValuePair<K, T>>[this.Capacity];

            for (int i = 0; i < this.elements.Length; i++)
            {
                resizedArray[i] = this.elements[i];
            }

            this.elements = resizedArray;
        }

        private int GetHashedValue(K key)
        {
            int hash = key.GetHashCode() % this.Capacity;
            return Math.Abs(hash);
        }

        private KeyValuePair<K, T> FindPair(K key)
        {
            int hash = this.GetHashedValue(key);
            var elements = this.elements[hash];

            foreach (var pair in elements)
            {
                if (pair.Key.Equals(key))
                {
                    return pair;
                }
            }

            throw new ArgumentException("Key not found");
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
