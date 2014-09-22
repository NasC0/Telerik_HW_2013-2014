using System;

namespace PriorityQueueImplementation
{
    public class PriorityQueue<T> : IPriorityQueue<T> where T : IComparable<T>
    {
        private IBInaryHeap<T> heap;

        public PriorityQueue(PriorityQueueOrder priority)
        {
            if (priority == PriorityQueueOrder.MaxPriority)
            {
                this.heap = new MaxBinaryHeap<T>();
            }
            else
            {
                this.heap = new MinBinaryHeap<T>();
            }
        }

        public int Count
        {
            get
            {
                return this.heap.Count;
            }
        }

        public void Enqueue(T element)
        {
            this.heap.Add(element);
        }

        public T Dequeue()
        {
            return this.heap.Remove();
        }
    }
}
