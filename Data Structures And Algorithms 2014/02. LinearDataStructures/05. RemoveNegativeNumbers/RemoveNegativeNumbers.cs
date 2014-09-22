using System;
using System.Collections.Generic;

namespace _05.RemoveNegativeNumbers
{
    public class RemoveNegativeNumbers
    {
        public static void Main()
        {
            List<int> allNumbers = new List<int>()
            {
                1, -1, 2, 3, -4, -5, -1, -6, 2, 7, 9, 10
            };

            List<int> positiveNumbers = new List<int>();

            foreach (var number in allNumbers)
            {
                if (number > 0)
                {
                    positiveNumbers.Add(number);
                }
            }

            foreach (var number in positiveNumbers)
            {
                Console.WriteLine(number);
            }
        }
    }
}
