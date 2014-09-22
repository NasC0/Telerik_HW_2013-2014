/* 5. Write a program that gets two numbers from the console and prints the greater of them. Don’t use if statements. */

using System;

class PrintGreater
{
    static void Main()
    {
        int firstInt, secondInt;
        int.TryParse(Console.ReadLine(), out firstInt);
        int.TryParse(Console.ReadLine(), out secondInt);
        Console.WriteLine("{0} is bigger than {1}", Math.Max(firstInt, secondInt), Math.Min(firstInt, secondInt));
    }
}
