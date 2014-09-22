namespace ExtendIEnumerable
{
    using System;
    using System.Collections.Generic;

    public static class ExtendIEnumerableClass
    {
        public static T Sum<T>(this IEnumerable<T> collection)
           where T : struct
        {
            dynamic totalSum = 0;
            foreach (T entry in collection)
            {
                totalSum += entry;
            }

            return (T)totalSum;
        }

        public static T Product<T>(this IEnumerable<T> collection)
            where T : struct
        {
            dynamic product = 1;
            foreach (T entry in collection)
            {
                product *= entry;
            }

            return (T)product;
        }

        public static T Min<T>(this IEnumerable<T> collection)
            where T : struct
        {
            dynamic min;

            using (IEnumerator<T> iter = collection.GetEnumerator())
            {
                min = iter.Current;
                while (iter.MoveNext())
                {
                    if (min > iter.Current)
                    {
                        min = iter.Current;
                    }
                }
            }

            return (T)min;
        }

        public static T Max<T>(this IEnumerable<T> collection)
            where T : struct
        {
            dynamic max;

            using (IEnumerator<T> iterator = collection.GetEnumerator())
            {
                max = iterator.Current;

                while (iterator.MoveNext())
                {
                    if (max < iterator.Current)
                    {
                        max = iterator.Current;
                    }
                }
            }

            return max;
        }

        public static T Average<T>(this IEnumerable<T> collection)
            where T : struct
        {
            int count = 0;
            dynamic average;

            using (IEnumerator<T> iter = collection.GetEnumerator())
            {
                average = iter.Current;
                count++;

                while (iter.MoveNext())
                {
                    count++;
                    average += iter.Current;
                }
            }

            return (T)(average / count);
        }
    }
}
