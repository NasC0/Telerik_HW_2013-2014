using System;

namespace LinkeListImplementation
{
    public class ListItem<T>
    {
        public ListItem(T value)
            :this(value, null)
        {
        }

        public ListItem(T value, ListItem<T> nextItem)
        {
            this.Value = value;
            this.NextItem = nextItem;
        }

        public T Value { get; private set; }

        public ListItem<T> NextItem { get; set; }
    }
}
