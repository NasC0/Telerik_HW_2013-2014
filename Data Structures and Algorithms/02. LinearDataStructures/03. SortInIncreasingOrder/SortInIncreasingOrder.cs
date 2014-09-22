using System;
using System.Collections.Generic;
using System.Linq;

class SortInIncreasingOrder
{
    static void Main()
    {
        List<int> numbersList = new List<int>();

        string input = Console.ReadLine();
        while (!string.IsNullOrWhiteSpace(input))
        {
            numbersList.Add(int.Parse(input));

            input = Console.ReadLine();
        }

        numbersList.Sort();

        foreach (var number in numbersList)
        {
            Console.WriteLine(number);
        }
    }
}
