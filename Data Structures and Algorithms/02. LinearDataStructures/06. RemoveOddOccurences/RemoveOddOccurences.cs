/* 06. Write a program that removes from given sequence all numbers that occur odd number of times. Example:
{4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2}  {5, 3, 3, 5} */

using System;
using System.Collections.Generic;
using System.Linq;

class RemoveOddOccurences
{
    static List<int> RemoveOddOccurencesFunc(List<int> input)
    {
        Dictionary<int, int> occurencesByKeyValue = new Dictionary<int, int>();
        foreach (var number in input)
        {
            if (occurencesByKeyValue.ContainsKey(number))
            {
                occurencesByKeyValue[number]++;
            }
            else
            {
                occurencesByKeyValue.Add(number, 1);
            }
        }

        List<int> result = new List<int>();

        for (int i = 0; i < input.Count; i++)
        {
            if (occurencesByKeyValue[input[i]] % 2 == 0)
            {
                result.Add(input[i]);
            }
        }

        return result;
    }

    static void Main()
    {
        List<int> originalList = new List<int>()
        {
            4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2
        };

        var result = RemoveOddOccurencesFunc(originalList);

        Console.WriteLine(string.Join(", ", result));
    }
}
