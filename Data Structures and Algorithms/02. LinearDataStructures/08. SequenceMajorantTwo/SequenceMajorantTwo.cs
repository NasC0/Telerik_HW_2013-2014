using System;
using System.Collections.Generic;
using System.Linq;

class SequenceMajorantTwo
{
    static int DetermineMajorant(List<int> input)
    {
        input.Sort();
        int majorantRequirement = input.Count / 2 + 1;
        int currentCount = 1;

        for (int i = 1; i < input.Count; i++)
        {
            if (input[i] == input[i - 1])
            {
                currentCount++;
                if (currentCount >= majorantRequirement)
                {
                    return input[i];
                }
            }
            else
            {
                currentCount = 1;
                if (i >= majorantRequirement)
                {
                    break;
                }
            }
        }

        throw new InvalidOperationException("No majorant found");
    }

    static void Main()
    {
        List<int> originalList = new List<int>() { 2, 2, 3, 3, 3, 3, 3, 5, 7, 3 };

        Console.WriteLine(DetermineMajorant(originalList));
    }
}
