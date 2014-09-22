using System;
using System.Collections.Generic;

namespace LinkedQueueImplementation
{
    public class LinkedQueue<T>
    {
        public int Count { get; private set; }

        public LinkedQueueNode<T> FirstElement { get; private set; }

        public LinkedQueueNode<T> LastElement { get; private set; }

        public void Enqueue(LinkedQueueNode<T> element)
        {
            if (this.FirstElement == null)
            {
                this.FirstElement = element;
            }
            else
            {
                if (this.FirstElement.NextInLine == null)
                {
                    this.FirstElement.NextInLine = element;
                    element.PrevInLine = this.FirstElement;
                }
                else
                {
                    this.LastElement.NextInLine = element;
                    element.PrevInLine = this.LastElement;
                }

                this.LastElement = element;
            }

            this.Count++;
        }

        public LinkedQueueNode<T> Dequeue()
        {
            if (this.FirstElement != null)
            {
                var result = this.FirstElement;
                this.FirstElement = this.FirstElement.NextInLine;
                if (this.FirstElement != null)
                {
                    this.FirstElement.PrevInLine = null;
                }
                return result;
            }
            else
            {
                throw new NullReferenceException("End of queue reached");
            }
        }
    }
}
