using System;
using System.Collections.Generic;

namespace LinkeListImplementation
{
    public class LinkedList<T> : IEnumerable<ListItem<T>>
    {
        public LinkedList(ListItem<T> firstElement)
        {
            this.FirstElement = firstElement;    
        }

        public ListItem<T> FirstElement { get; private set; }

        public IEnumerator<ListItem<T>> GetEnumerator()
        {
            var currentElement = this.FirstElement;
            while (true)
            {
                yield return currentElement;
                if (currentElement.NextItem == null)
                {
                    break;
                }

                currentElement = currentElement.NextItem;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
