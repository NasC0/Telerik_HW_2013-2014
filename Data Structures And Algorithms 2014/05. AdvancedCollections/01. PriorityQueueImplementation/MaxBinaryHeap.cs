using System;

namespace PriorityQueueImplementation
{
    internal class MaxBinaryHeap<T> : IBInaryHeap<T> where T : IComparable<T>
    {
        private const int InitialCapacity = 2;
        private const int RootElementIndex = 1;

        private T[] elements;
        private int capacity;
        private int count;

        public MaxBinaryHeap()
        {
            this.capacity = InitialCapacity;
            this.elements = new T[this.capacity];
            this.count = 0;
        }

        public int Count
        {
            get
            {
                return this.count;
            }
        }

        public void Add(T element)
        {
            this.count++;
            if (this.count >= this.capacity)
            {
                this.Resize();
            }

            this.PercolateUp(element, this.Count);
        }

        public T Remove()
        {
            if (this.Count <= 0)
            {
                throw new InvalidOperationException("Heap is empty.");
            }

            T resultElement = this.elements[RootElementIndex];

            if (this.Count == 0)
            {
                return resultElement;
            }

            this.elements[RootElementIndex] = this.elements[this.Count];
            this.elements[this.Count] = default(T);
            this.count--;
            this.PercolateDown(RootElementIndex);
            return resultElement;
        }

        private void PercolateUp(T element, int position)
        {
            int currentPosition = position;
            var parentElement = this.elements[currentPosition / 2];

            while (currentPosition > 1 && element.CompareTo(parentElement) > 0)
            {
                this.elements[currentPosition] = this.elements[currentPosition / 2];
                currentPosition /= 2;
            }

            this.elements[currentPosition] = element;
        }

        private void PercolateDown(int index)
        {
            T currentElement = this.elements[index];
            int childIndex;

            while (index * 2 <= this.Count)
            {
                childIndex = index * 2;

                if (childIndex != this.Count && 
                    this.elements[childIndex].CompareTo(this.elements[childIndex + 1]) < 0)
                {
                    childIndex++;
                }

                if (currentElement.CompareTo(this.elements[childIndex]) < 0)
                {
                    this.elements[index] = this.elements[childIndex];
                    index = childIndex;
                }
                else
                {
                    break;
                }
            }

            this.elements[index] = currentElement;
        }

        private void Resize()
        {
            this.capacity *= 2;
            T[] newElements = new T[this.capacity];
            Array.Copy(this.elements, newElements, this.elements.Length);

            this.elements = newElements;
        }
    }
}
