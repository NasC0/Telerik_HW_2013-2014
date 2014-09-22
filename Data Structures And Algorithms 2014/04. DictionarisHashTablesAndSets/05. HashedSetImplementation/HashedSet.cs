using System;
using System.Collections;
using System.Collections.Generic;
using ImplementHashedTable;

namespace HashedSetImplementation
{
    class HashedSet<T> : IHashedSet<T>, IEnumerable<T>
    {
        private IHashedTable<T, T> hashTable;
        private int count;

        public HashedSet()
        {
            this.hashTable = new HashedTable<T, T>();
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
                    throw new ArgumentException("Collection count must be bigger than zero.");
                }

                this.count = value;
            }
        }

        public void Add(T toAdd)
        {
            this.hashTable.Add(toAdd, toAdd);
            this.Count++;
        }

        public T Find(T toFind)
        {
            return this.hashTable.Find(toFind);
        }

        public T Remove(T toRemove)
        {
            var removed = this.hashTable.Remove(toRemove);
            this.Count--;
            return removed;
        }

        public void Clear()
        {
            this.hashTable.Clear();
            this.Count = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var element in this.hashTable)
            {
                yield return element.Value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
