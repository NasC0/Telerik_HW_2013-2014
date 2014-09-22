/* 2. Write a program that prints all the numbers from 1 to N, that are not divisible by 3 and 7 at the same time. */

using System;

class NonDivisibleBy3And7
{
    static void Main()
    {
        Console.Write("Please enter the number you want counted up to: ");
        int count;
        int.TryParse(Console.ReadLine(), out count);

        for (int i = 1; i <= count; i++)
        {
            if (i % 3 != 0 && i % 7 != 0)
            {
                Console.WriteLine(i);
            }
        }
    }
}
