/* 1. Write a program that reads 3 integer numbers from the console and prints their sum. */

using System;

class ReadAndPrintIntegers
{
    static void Main()
    {
        int firstInt, secondInt, thirdInt;
        int.TryParse(Console.ReadLine(), out firstInt);
        int.TryParse(Console.ReadLine(), out secondInt);
        int.TryParse(Console.ReadLine(), out thirdInt);
        int sum = firstInt + secondInt + thirdInt;
        Console.WriteLine("The sum of {0} + {1} + {2} = {3}", firstInt, secondInt, thirdInt, sum);
    }
}