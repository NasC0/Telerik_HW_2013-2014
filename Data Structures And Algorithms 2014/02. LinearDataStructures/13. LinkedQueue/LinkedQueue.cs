using System;
namespace LinkedQueue
{
    public class LinkedQueue<T>
    {
        private LinkedQueueNode<T> firstNode;

        private LinkedQueueNode<T> lastNode;

        public void Enqueue(T value)
        {
            if (this.firstNode == null)
            {
                this.firstNode = new LinkedQueueNode<T>(value);
            }
            else if (this.lastNode == null)
            {
                this.lastNode = new LinkedQueueNode<T>(value);
                this.firstNode.NextNode = this.lastNode;
                this.lastNode.PreviousNode = this.firstNode;
            }
            else
            {
                var newLastNode = new LinkedQueueNode<T>(value);
                this.lastNode.NextNode = newLastNode;
                newLastNode.PreviousNode = this.lastNode;
                this.lastNode = newLastNode;
            }
        }

        public T Dequeue()
        {
            if (this.firstNode == null)
            {
                throw new InvalidOperationException("Queue empty.");
            }

            T result = this.firstNode.Value;

            this.firstNode = this.firstNode.NextNode;
            if (this.firstNode != null)
            {
                this.firstNode.PreviousNode = null;
            }

            return result;
        }

        public T Peek()
        {
            if (this.firstNode == null)
            {
                throw new InvalidOperationException("Queue empty.");
            }

            return this.firstNode.Value;
        }
    }
}
