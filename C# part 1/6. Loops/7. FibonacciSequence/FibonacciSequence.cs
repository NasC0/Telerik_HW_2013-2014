/* 7. Write a program that reads a number N and calculates the sum of the first N members of the 
 * sequence of Fibonacci: 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, …
 * Each member of the Fibonacci sequence (except the              first two) is a sum of the previous two members. */

using System;
using System.Numerics;

class FibonacciSequence
{
    static void Main()
    {
        Console.WriteLine("Please input how many members you want: ");
        int sequenceLength;
        int.TryParse(Console.ReadLine(), out sequenceLength);
        BigInteger sum = 1;
        BigInteger firstMember = 0, secondMember = 1, temp = secondMember;

        for (int i = 0; i < sequenceLength - 2; i++)
        {
            secondMember += firstMember;
            firstMember = temp;
            temp = secondMember;
            sum += secondMember;
        }

        Console.WriteLine("The sum of the first {0} members of the fibonacci sequence is: {1}", sequenceLength, sum);
    }
}
