/* 10. Write a boolean expression that returns if the bit at position p (counting from 0) in a given integer number v has value of 1. Example: v=5; p=1 -> false. */

using System;

class CheckBit
{
    static void Main()
    {
        Console.WriteLine("Please enter your number and position: ");
        int number, position;
        int.TryParse(Console.ReadLine(), out number);
        int.TryParse(Console.ReadLine(), out position);

        int bit = (number >> position) & 1;
        bool checkBit = bit == 1;
        Console.WriteLine(checkBit);
    }
}