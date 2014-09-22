/* 05. Write a program that removes from given sequence all negative numbers. */

using System;
using System.Collections.Generic;

class RemoveNegativeNumbers
{
    static List<int> RemoveNegativeNumbersFunc(List<int> input)
    {
        List<int> result = new List<int>();
        foreach (var number in input)
        {
            if (number >= 0)
            {
                result.Add(number);
            }
        }

        return result;
    }

    static void Main()
    {
        List<int> originalList = new List<int>()
        {
            2, 3, 4, 5, 6, 7, -2, 1, -15, 0, -10, 12
        };

        var result = RemoveNegativeNumbersFunc(originalList);

        Console.WriteLine(string.Join(", ", result));
    }
}