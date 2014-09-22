/* 11. Write an expression that extracts from a given integer i the value of a given bit number b. 
 * Example: i=5; b=2 -> value=1. */

using System;

class ExtractBit
{
    static void Main()
    {
        Console.Write("Please enter your number: ");
        int number, bit;
        int.TryParse(Console.ReadLine(), out number);
        Console.Write("Please enter the bit you want extracted: ");
        int.TryParse(Console.ReadLine(), out bit);
        int result = (number >> bit) & 1;
        Console.WriteLine(result);
    }
}