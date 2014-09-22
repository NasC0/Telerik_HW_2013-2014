/* 02. Implement a set of extension methods for IEnumerable<T> that implement the 
 * following group functions: sum, product, min, max, average.  */

namespace ExtendIEnumerable
{
    using System;
    using System.Collections.Generic;

    public class ExtendIEnumerable
    {
        static void Main()
        {
            List<int> intList = new List<int>();

            for (int i = 0; i < 10; i++)
            {
                intList.Add(i);
            }

            Console.WriteLine("The sum of the int collection is: {0}", intList.Sum());

            List<double> doubleList = new List<double>();

            for (int i = 0; i < 10; i++)
            {
                doubleList.Add(i + 0.1);
            }

            Console.WriteLine("The average of the double collection is: {0}", doubleList.Average());

            List<float> floatList = new List<float>();

            for (int i = 0; i < 10; i++)
            {
                floatList.Add(i + 0.1f);
            }

            Console.WriteLine("The maximum value of the float collection is: {0}", floatList.Max());

            List<byte> byteList = new List<byte>();

            for (int i = 0; i < 10; i++)
            {
                byteList.Add((byte)i);
            }

            Console.WriteLine("The minimum value of the byte collectionsi: {0}", byteList.Min());

            List<decimal> decimalList = new List<decimal>();

            for (int i = 0; i < 10; i++)
            {
                decimalList.Add(i + 0.1m);
            }

            Console.WriteLine("The product of the decimal list if: {0}", decimalList.Product());
        }
    }
}
