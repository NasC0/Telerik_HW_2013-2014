using System;

namespace PriorityQueueImplementation
{
    public interface IBInaryHeap<T> where T : IComparable<T>
    {
        int Count { get; }

        void Add(T element);

        T Remove();
    }
}
