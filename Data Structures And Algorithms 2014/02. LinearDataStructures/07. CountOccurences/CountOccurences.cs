using System;
using System.Collections.Generic;

namespace _07.CountOccurences
{
    public class CountOccurences
    {
        public static void Main()
        {
            List<int> sequence = new List<int>()
            {
                3, 4, 4, 2, 3, 3, 4, 3, 2
            };

            sequence.Sort();

            int currentLength = 1;

            for (int i = 1; i < sequence.Count; i++)
            {
                int currentNumber = sequence[i];
                int previousNumber = sequence[i - 1];

                if (currentNumber == previousNumber)
                {
                    currentLength++;
                }
                else
                {
                    Console.WriteLine("{0} occurs {1} times", previousNumber, currentLength);
                    currentLength = 1;
                }
            }

            Console.WriteLine("{0} occurs {1} times", sequence[sequence.Count - 1], currentLength);
        }
    }
}
