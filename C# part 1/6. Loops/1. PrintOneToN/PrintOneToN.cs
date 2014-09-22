/* 1. Write a program that prints all the numbers from 1 to */

using System;

class PrintOneToN
{
    static void Main()
    {
        Console.Write("Please enter the number you want counted up to: ");
        int count;
        int.TryParse(Console.ReadLine(), out count);

        for (int i = 1; i <= count; i++)
        {
            Console.WriteLine(i);
        }
    }
}
