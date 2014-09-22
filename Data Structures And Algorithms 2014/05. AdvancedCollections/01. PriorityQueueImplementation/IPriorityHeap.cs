using System;

namespace PriorityQueueImplementation
{
    public interface IPriorityQueue<T> where T : IComparable<T>
    {
        int Count { get; }

        void Enqueue(T element);

        T Dequeue();
    }
}
