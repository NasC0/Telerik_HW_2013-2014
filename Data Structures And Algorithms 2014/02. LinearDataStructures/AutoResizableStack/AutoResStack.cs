using System;
namespace AutoResizableStack
{
    public class AutoResStack<T>
    {
        private const int InitialSize = 4;

        private int capacity;
        private T[] holder;
        private int count;
        private int currentIndex;

        public AutoResStack(int capacity)
        {
            this.capacity = capacity;
            this.holder = new T[capacity];
            this.currentIndex = 0;
            this.Count = 0;
        }

        public AutoResStack()
            : this(InitialSize)
        {
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
                    throw new ArgumentException("Stack count cannot be negative.");
                }

                this.count = value;
            }
        }

        public void Push(T value)
        {
            this.holder[this.currentIndex] = value;
            this.Count++;
            this.currentIndex++;

            if (this.Count >= this.capacity)
            {
                this.Resize();
            }
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Stack empty.");    
            }

            T returnValue = this.holder[this.currentIndex - 1];
            this.currentIndex--;
            this.Count--;

            return returnValue;
        }

        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Stack empty.");
            }

            return this.holder[this.currentIndex - 1];
        }

        private void Resize()
        {
            int doubleCapacity = this.capacity * 2;
            T[] biggerHolder = new T[doubleCapacity];

            for (var i = 0; i < this.holder.Length; i++)
            {
                biggerHolder[i] = this.holder[i];
            }

            this.capacity = doubleCapacity;
            this.holder = biggerHolder;
        }
    }
}
