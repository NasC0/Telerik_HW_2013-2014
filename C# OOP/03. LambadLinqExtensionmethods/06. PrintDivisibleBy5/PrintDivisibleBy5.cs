/* 06. Write a program that prints from given array of integers all numbers that are divisible by 7 and 3. 
 * Use the built-in extension methods and lambda expressions. Rewrite the same with LINQ. */

namespace _06.PrintDivisibleBy5
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class PrintDivisibleBy5
    {
        static void Main()
        {
            List<int> intList = new List<int>();
            for (int i = 1; i < 100; i++)
            {
                intList.Add(i);
            }

            // Lambda solution
            var lambdaResult = intList.Where(x => x % 7 == 0 && x % 3 == 0);

            Console.WriteLine("Lambda solution: \n");

            foreach (var entry in lambdaResult)
            {
                Console.WriteLine(entry);
            }

            Console.WriteLine("\nLINQ solution: \n");
            // LINQ solution
            var linqResult = from number in intList
                             where number % 3 == 0 &&
                                   number % 7 == 0
                             select number;

            foreach (var number in linqResult)
            {
                Console.WriteLine(number);
            }
        }
    }
}
