using System.Collections.Generic;
namespace ImplementHashedTable
{
    public interface IHashedTable<K, T> : IEnumerable<KeyValuePair<K, T>>
    {
        void Add(K key, T value);

        T Find(K key);

        T Remove(K key);

        void Clear();

        int Count { get; }

        int Capacity { get; }

        T this[K key] { get; set; }
    }
}
