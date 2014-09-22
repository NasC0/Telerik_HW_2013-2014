using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.ReadNumberSequence
{
    public class ReadNumberSequence
    {
        public static void Main()
        {
            List<int> numbersList = new List<int>();
            string readNumber = Console.ReadLine();

            while (!string.IsNullOrWhiteSpace(readNumber))
            {
                int currentNumber;
                int.TryParse(readNumber, out currentNumber);

                numbersList.Add(currentNumber);

                readNumber = Console.ReadLine();
            }

            int collectionSum = numbersList.Sum();
            double collectionAverage = numbersList.Average();

            Console.WriteLine("Collection sum: {0}", collectionSum);
            Console.WriteLine("Collection average: {0}", collectionAverage);
        }
    }
}
