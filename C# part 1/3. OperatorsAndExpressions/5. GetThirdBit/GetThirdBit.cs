/* 5.  Write a boolean expression for finding if the bit 3 (counting from 0) of a given integer is 1 or 0. */

using System;

class GetThirdBit
{
    static void Main()
    {
        Console.WriteLine("Please enter the int: ");
        int number;
        int.TryParse(Console.ReadLine(), out number);
        int position = 3;
        int result = (number >> position) & 1;
        bool checkBit = (result == 1);
        Console.WriteLine(checkBit);
    }
}
