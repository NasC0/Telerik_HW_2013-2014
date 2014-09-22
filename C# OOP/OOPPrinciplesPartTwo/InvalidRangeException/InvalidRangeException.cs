/* Task 3. Define a class InvalidRangeException<T> that holds information about an error 
 * condition related to invalid range. It should hold error message and a range definition [start … end]. */

namespace InvalidRangeException
{
    using System;
using System.Runtime.Serialization;

    [Serializable]
    public class InvalidRangeException<T> : ApplicationException
    {
        public InvalidRangeException(string message, T min, T max, Exception exceptionCause = null)
            :base(message, exceptionCause)
        {
            this.Min = min;
            this.Max = max;
        }

        public InvalidRangeException(string message, T min, T max)
            :this(message, min, max, null)
        {
            
        }

        public InvalidRangeException(T min, T max)
            :this(null, min, max, null)
        {
            
        }

        protected InvalidRangeException(SerializationInfo info, StreamingContext context)
            :base(info, context)
        {
            
        }

        public T Max { get; private set; }
        
        public T Min { get; private set; }
    }
}
