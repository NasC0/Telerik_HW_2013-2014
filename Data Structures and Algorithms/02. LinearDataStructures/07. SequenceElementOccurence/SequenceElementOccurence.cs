/* 07. Write a program that finds in given array of integers (all belonging to the range [0..1000]) how many times each of them occurs.
Example: array = {3, 4, 4, 2, 3, 3, 4, 3, 2}
2  2 times
3  4 times
4  3 times */

using System;
using System.Collections.Generic;
using System.Linq;

class SequenceElementOccurence
{
    static Dictionary<int, int> CountOccurences(List<int> input)
    {
        input.Sort();
        Dictionary<int, int> result = new Dictionary<int, int>();

        foreach (var number in input)
        {
            if (result.ContainsKey(number))
            {
                result[number]++;
            }
            else
            {
                result.Add(number, 1);
            }
        }

        return result;
    }

    static void Main()
    {
        List<int> originalList = new List<int>()
        {
            3, 4, 4, 2, 3, 3, 4, 3, 2  
        };

        var result = CountOccurences(originalList);

        foreach (var entry in result)
        {
            Console.WriteLine("{0} -> {1}", entry.Key, entry.Value);
        }
    }
}
