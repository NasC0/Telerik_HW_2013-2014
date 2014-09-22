/* 4. Write a program that reads two positive integer numbers and prints how many numbers p exist between them such that the reminder of the division by 5 is 0 (inclusive). Example: p(17,25) = 2. */

using System;
class DivisionBy5
{
    static void Main()
    {
        int firstInt, secondInt;
        int.TryParse(Console.ReadLine(), out firstInt);
        int.TryParse(Console.ReadLine(), out secondInt);
        if (firstInt == 0)
        {
            firstInt += 1;
        }
        int counter = 0;

        for (int i = firstInt; i <= secondInt; i++)
        {
            if (i % 5 == 0)
            {
                counter++;
                i += 4;
            }
        }
        Console.WriteLine(counter);
    }
}