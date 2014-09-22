/* 08. * The majorant of an array of size N is a value that occurs in it at least N/2 + 1 times. 
 * Write a program to find the majorant of given array (if exists). Example:
{2, 2, 3, 3, 2, 3, 4, 3, 3}  3 */

using System;
using System.Collections.Generic;
using System.Linq;

class SequenceMajorant
{
    static int FindSequnceMajorant(List<int> input)
    {
        Dictionary<int, int> occurencesByKeyValue = new Dictionary<int, int>();
        for (int i = 0; i < input.Count; i++)
        {
            if (occurencesByKeyValue.ContainsKey(input[i]))
            {
                occurencesByKeyValue[input[i]]++;
            }
            else
            {
                occurencesByKeyValue.Add(input[i], 1);
            }
        }

        int majorantRequirements = (input.Count / 2) + 1;

        foreach (var entry in occurencesByKeyValue)
        {
            if (entry.Value >= majorantRequirements)
            {
                return entry.Key;
            }
        }

        throw new OperationCanceledException("No majorant found");
    }

    static void Main()
    {
        List<int> originalList = new List<int>() { 2, 2, 3, 3, 2, 3, 4, 3, 3 };

        try
        {
            Console.WriteLine(FindSequnceMajorant(originalList));
        }
        catch (OperationCanceledException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
