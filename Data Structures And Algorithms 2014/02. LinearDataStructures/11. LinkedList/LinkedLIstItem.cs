
using System;
namespace _11.LinkedList
{
    public class LinkedListItem<T>
    {
        private T value;

        private LinkedListItem<T> nextItem;

        public LinkedListItem(T value)
        {
            this.Value = value;
        }

        public LinkedListItem(T value, LinkedListItem<T> nextItem)
            : this(value)
        {
            this.NextItem = nextItem;
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
                    throw new ArgumentNullException("Cannot assign value null.");
                }

                this.value = value;
            }
        }

        public LinkedListItem<T> NextItem
        {
            get
            {
                return this.nextItem;
            }

            set
            {
                this.nextItem = value;
            }
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}
