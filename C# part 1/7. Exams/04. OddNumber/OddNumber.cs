using System;
using System.Collections.Generic;

class OddNumber
{
    static void Main()
    {
        long n = long.Parse(Console.ReadLine());
        List<long> sequence = new List<long>();
        for (int i = 0; i < n; i++)
        {
            sequence.Add(long.Parse(Console.ReadLine()));
        }

        sequence.Reverse();

        List<long> checkedNumbers = new List<long>();

        for (int i = 0; i < sequence.Count; i++)
        {
            int countOccurence = 0;
            if (checkedNumbers.Contains(sequence[i]))
            {
                continue;
            }
            else
            {
                checkedNumbers.Add(sequence[i]);
            }
            foreach (long num in sequence)
            {
                if (num == sequence[i])
                {
                    countOccurence++;
                }
            }
            if (countOccurence % 2 != 0)
            {
                Console.WriteLine(sequence[i]);
                break;
            }
        }
    }
}
