using System;
using System.Collections.Generic;

namespace _03.SortList
{
    public class SortList
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

            numbersList.Sort();

            foreach (var number in numbersList)
            {
                Console.WriteLine(number);
            }
        }
    }
}
