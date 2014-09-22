/* 01. Write a program that reads from the console a sequence of positive integer numbers. 
 * The sequence ends when empty line is entered. Calculate and print the sum and average of the elements of the sequence. 
 * Keep the sequence in List<int>. */

using System;
using System.Collections.Generic;
using System.Linq;

class SequenceSumAndAverage
{
    static void Main()
    {
        List<int> numbersList = new List<int>();

        string intToParse = Console.ReadLine();
        while (!string.IsNullOrWhiteSpace(intToParse))
        {
            int toAdd = int.Parse(intToParse);
            numbersList.Add(toAdd);

            intToParse = Console.ReadLine();
        }

        Console.WriteLine("Sequence sum: {0}", numbersList.Sum());
        Console.WriteLine("Sequence average: {0}", numbersList.Average());
    }
}
