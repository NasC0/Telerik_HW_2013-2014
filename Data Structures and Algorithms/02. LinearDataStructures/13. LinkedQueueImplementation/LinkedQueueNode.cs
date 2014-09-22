using System;
using System.Collections.Generic;

namespace LinkedQueueImplementation
{
    public class LinkedQueueNode<T>
    {
        public LinkedQueueNode(T value)
            : this(value, null, null)
        {

        }

        public LinkedQueueNode(T value, LinkedQueueNode<T> nextListItem, LinkedQueueNode<T> prevListItem)
        {
            this.Value = value;
            this.NextInLine = nextListItem;
            this.PrevInLine = prevListItem;
        }

        public T Value { get; private set; }
        public LinkedQueueNode<T> NextInLine { get; set; }

        public LinkedQueueNode<T> PrevInLine { get; set; }
    }
}
