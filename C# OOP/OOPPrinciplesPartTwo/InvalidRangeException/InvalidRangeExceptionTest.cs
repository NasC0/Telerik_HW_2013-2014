/* Task 3. Write a sample application that demonstrates the InvalidRangeException<int> and InvalidRangeException<DateTime> 
 * by entering numbers in the range [1..100] and dates in the range [1.1.1980 … 31.12.2013]. */

namespace InvalidRangeException
{
    using System;
    using System.Collections.Generic;

    class InvalidRangeExceptionTest
    {
        static void Main()
        {
            try
            {
                List<int> intList = new List<int>();
                Console.WriteLine("Enter your number: ");
                int bla = int.Parse(Console.ReadLine());

                if (bla < 0 || bla > 100)
                {
                    throw new InvalidRangeException<int>(0, 100);
                }
                else
                {
                    intList.Add(bla);
                }
            }
            catch (InvalidRangeException<int> ex)
            {
                Console.WriteLine("Must be in the range {0} - {1}", ex.Min, ex.Max);
            }

            try
            {
                List<DateTime> dateTimeList = new List<DateTime>();
                Console.WriteLine("Enter your date: ");
                DateTime time = DateTime.Parse(Console.ReadLine());

                if (time.Date < new DateTime(1980, 1, 1) || time.Date > new DateTime(2013, 12, 31))
                {
                    throw new InvalidRangeException<DateTime>(new DateTime(1980, 1, 1), new DateTime(2013, 12, 31));
                }
                else
                {
                    dateTimeList.Add(time);
                }
            }
            catch (InvalidRangeException<DateTime> ex)
            {
                Console.WriteLine("Must be in the range {0} - {1}", ex.Min.Date, ex.Max.Date);
            }
        }
    }
}
