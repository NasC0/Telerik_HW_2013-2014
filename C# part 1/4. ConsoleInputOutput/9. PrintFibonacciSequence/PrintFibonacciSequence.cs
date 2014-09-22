/* 9. Write a program to print the first 100 members of the sequence of Fibonacci: 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, … */

using System;
using System.Numerics;

class PrintFibonacciSequence
{
    static void Main()
    {
        // using BigInteger, because the later numbers of the sequence are out of long's range
        BigInteger firstNumber = 0;
        BigInteger secondNumber = 1;
        Console.WriteLine(firstNumber);
        Console.WriteLine(secondNumber);
        for (int i = 0; i < 100; i++)
        {
            BigInteger temp = secondNumber;
            secondNumber += firstNumber;
            firstNumber = temp;
            Console.WriteLine("{0} ", secondNumber);
        }
    }
}
