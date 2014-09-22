namespace HashedSetImplementation
{
    public interface IHashedSet<T>
    {
        int Count { get; }

        void Add(T toAdd);

        T Find(T toFind);

        T Remove(T toRemove);

        void Clear();
    }
}
