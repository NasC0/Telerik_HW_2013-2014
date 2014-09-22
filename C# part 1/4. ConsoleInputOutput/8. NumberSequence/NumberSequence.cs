/* 8. Write a program that reads an integer number n from the console and prints all the numbers in the interval [1..n], each on a single line. */

using System;

class NumberSequence
{
    static void Main()
    {
        Console.WriteLine("Please enter the length of the sequence you want: ");
        int length;
        int.TryParse(Console.ReadLine(), out length);

        for (int i = 1; i <= length; i++)
        {
            Console.WriteLine(i);
        }
    }
}
