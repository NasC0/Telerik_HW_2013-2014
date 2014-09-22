using System;
using System.Collections.Generic;

namespace AutoResizableStack
{
    public class AutoResizableStack<T>
    {
        private const int StartingElementsCount = 0;
        private const int StartingCapacity = 8;

        private T[] elements;

        public AutoResizableStack()
        {
            this.Count = StartingElementsCount;
            this.Capacity = StartingCapacity;
            this.elements = new T[this.Capacity];
        }

        public int Count { get; private set; }
        public int Capacity { get; private set; }

        public void Push(T element)
        {
            if (this.Count == this.Capacity)
            {
                this.ResizeArray();
            }

            this.Count++;
            this.elements[this.Count - 1] = element;
        }

        public T Pop()
        {
            try
            {
                T element = this.elements[this.Count - 1];
                T[] newArray = new T[this.Capacity];
                for (int i = 0; i < this.Count - 2; i++)
                {
                    newArray[i] = this.elements[i];
                }

                this.elements = newArray;
                this.Count--;

                return element;
            }
            catch (IndexOutOfRangeException ex)
            {
                throw new IndexOutOfRangeException("Index was outside the bounds of the array.");
            }
        }

        public T Peek()
        {
            return this.elements[this.Count - 1];
        }

        private void ResizeArray()
        {
            this.Capacity *= 2;
            T[] newArray = new T[this.Capacity];

            for (int i = 0; i < this.elements.Length; i++)
            {
                newArray[i] = this.elements[i];
            }

            this.elements = newArray;
        }
    }
}
