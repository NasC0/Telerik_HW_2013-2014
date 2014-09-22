/* 9. Write a program that prints the first 10 members of the sequence: 2, -3, 4, -5, 6, -7, ... */

using System;

class PrintSequence
{
    static void Main()
    {
        // initialize a variable which will hold the + or - sign for the current number
        int var = 1;
        // starts a for cycle which loops through all 10 numbers;
        for (int i = 2; i < 12; i++)
        {
            // print the current loop number multiplied by @var to change the sign
            Console.WriteLine(i * var);
            // multiply @var by -1 to change the next sign
            var *= -1;
        }
    }
}
