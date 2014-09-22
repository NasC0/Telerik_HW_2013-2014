using System;

namespace _11.LinkedList
{
    public class LinkedList<T>
    {
        private LinkedListItem<T> firstValue;
        private LinkedListItem<T> lastValue;

        public LinkedList(LinkedListItem<T> element)
        {
            this.FirstValue = element;
            this.LastValue = element;
        }

        public LinkedListItem<T> FirstValue
        {
            get
            {
                return this.firstValue;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("First list item cannot be null.");
                }

                this.firstValue = value;
            }
        }

        public LinkedListItem<T> LastValue
        {
            get
            {
                return this.lastValue;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Last list item cannot be null.");
                }

                this.lastValue = value;
            }
        }

        public void AddToFront(LinkedListItem<T> element)
        {
            element.NextItem = this.FirstValue;
            this.FirstValue = element;
        }

        public void AddToBack(LinkedListItem<T> element)
        {
            if (element.NextItem == null)
            {
                this.LastValue.NextItem = element;
                this.LastValue = element;
            }
            else
            {
                this.LastValue.NextItem = element;
                this.LastValue = element.NextItem;
            }
        }
    }
}
