/* Task 5. Write a generic class GenericList<T> that keeps a list of elements of some parametric type T. 
 * Keep the elements of the list in an array with fixed capacity which is given as parameter in the class constructor. 
 * Implement methods for adding element, accessing element by index, removing element by index, inserting element at given position, 
 * clearing the list, finding element by its value and ToString(). 
 * Check all input parameters to avoid accessing elements at invalid positions. */

namespace GenericClasses.Common
{
    using System;
    using System.Text;
    using System.Linq;
    using System.Collections.Generic;

    public class GenericList<T> : IEnumerable<T> where T : struct
    {
        private T[] List { get; set; }
        private int count;
        private int size;

        public GenericList(int size)
        {
            this.Size = size;
            this.Count = 0;
            this.List = new T[this.Size];
        }

        public int Count
        {
            get
            {
                return this.count;
            }
            private set
            {
                this.count = value;
            }
        }

        public int Size
        {
            get
            {
                return this.size;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("List size cannot be negative.");
                }

                this.size = value;
            }
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= this.Count)
                {
                    throw new ArgumentOutOfRangeException("Index out of bounds.");
                }
                return this.List[index];
            }
            set
            {
                if (index < 0 || index >= this.Count)
                {
                    throw new ArgumentOutOfRangeException("Index out of bounds.");
                }
                this.List[index] = value;
            }
        }

        public void Add(T element)
        {
            this.List[this.Count] = element;
            this.Count++;

            if (this.Count == this.Size)
            {
                EnsureCapacity();
            }
        }

        public void RemoveAt(int index)
        {
            if (index >= this.Count || index < 0)
            {
                throw new ArgumentOutOfRangeException("Index out of bounds.");
            }

            T[] newList = new T[this.Size];
            Array.Copy(this.List, 0, newList, 0, index);
            this.Count--;
            int newLength = this.Count - (index - 1);
            Array.Copy(this.List, index + 1, newList, index, newLength);
            this.List = newList;
        }

        public void InsertAt(int index, T value)
        {
            if (index > this.Count || index < 0)
            {
                throw new ArgumentOutOfRangeException("Index out of bounds");
            }

            this.Count++;
            if (this.Count == this.Size)
            {
                EnsureCapacity();
            }

            T[] newList = new T[this.Size];
            Array.Copy(this.List, 0, newList, 0, index);
            newList[index] = value;
            int remainingLength = (this.Count - 1) - index;
            Array.Copy(this.List, index, newList, index + 1, remainingLength);

            this.List = newList;
        }

        public void Clear()
        {
            this.Count = 0;
            this.List = new T[this.Size];
        }

        public int Find(T element)
        {
            int index = -1;
            for (int i = 0; i < this.Count; i++)
            {
                if (this[i].Equals(element))
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        /* Task 7. Create generic methods Min<T>() and Max<T>() for finding the minimal and maximal element in the GenericList<T>. 
         * You may need to add generic constraints for the type T. */
        public T Max()
        {
            dynamic max = this.List.Max();
            return max;
        }

        public T Min()
        {
            T[] listToCheck = new T[this.Count];
            Array.Copy(this.List, 0, listToCheck, 0, this.Count);
            dynamic min = listToCheck.Min();
            return min;
        }

        public override string ToString()
        {
            if (this.List == null || this.Count < 1)
            {
                return String.Empty;
            }

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < this.Count; i++)
            {
                sb.AppendFormat("{0}: {1}\n", i, this[i]);
            }

            sb.Remove(sb.Length - 1, 1);
            return sb.ToString();
        }

        /* Task 6. Implement auto-grow functionality: when the internal array is full, create a new array of double size and move all elements to it. */
        private void EnsureCapacity()
        {
            this.Size *= 2;
            T[] copyList = new T[this.Size];
            this.List.CopyTo(copyList, 0);
            this.List = copyList;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T entry in this.List)
            {
                yield return entry;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
