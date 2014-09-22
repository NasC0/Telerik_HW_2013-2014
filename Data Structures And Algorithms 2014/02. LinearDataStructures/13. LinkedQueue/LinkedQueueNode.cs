using System;

namespace LinkedQueue
{
    internal class LinkedQueueNode<T>
    {
        private T value;

        public LinkedQueueNode(T value)
        {
            this.Value = value;
        }

        public LinkedQueueNode(T value, LinkedQueueNode<T> previousValue)
            : this(value)
        {
            this.PreviousNode = previousValue;
        }

        public LinkedQueueNode(T value, LinkedQueueNode<T> previousValue, LinkedQueueNode<T> nextValue)
            : this(value, previousValue)
        {
            this.NextNode = nextValue;
        }

        public T Value
        {
            get
            {
                return this.value;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Node value cannot be null.");
                }

                this.value = value;
            }
        }

        public LinkedQueueNode<T> NextNode { get; set; }

        public LinkedQueueNode<T> PreviousNode { get; set; }
    }
}
