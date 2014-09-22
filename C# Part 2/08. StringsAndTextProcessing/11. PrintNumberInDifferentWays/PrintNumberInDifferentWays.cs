/* 11 Write a program that reads a number and prints it as a decimal number, hexadecimal number, percentage and in scientific notation. 
 * Format the output aligned right in 15 symbols. */

using System;

class PrintNumberInDifferentWays
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        string[] outputs = { number.ToString("E"), number.ToString("P"), number.ToString("X"), number.ToString() };
        for (int i = 0; i < outputs.Length; i++)
        {
            outputs[i] = outputs[i].PadLeft(15);
            Console.WriteLine(outputs[i]);
        }
    }
}