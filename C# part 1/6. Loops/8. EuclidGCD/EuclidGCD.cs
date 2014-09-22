/* 8. Write a program that calculates the greatest common divisor (GCD) of given two numbers. Use the Euclidean algorithm (find it in Internet). */

using System;

class EuclidGCD
{
    static void Main()
    {
        Console.WriteLine("Input the two integers you want the GCD of: ");
        int firstInt, secondInt;
        int.TryParse(Console.ReadLine(), out firstInt);
        int.TryParse(Console.ReadLine(), out secondInt);
        int firstVar = firstInt, secondVar = secondInt;
        int result, remainder;
        while (secondInt > 0)
        {
            result = firstVar / secondVar;
            remainder = firstVar % secondVar;

            int temp = secondVar;
            secondVar = firstVar % secondVar;
            firstVar = temp;

            if (remainder == 0)
            {
                break;
            }
        }

        Console.WriteLine("The greatest common divisor of {0} and {1} is {2}", firstInt, secondInt, firstVar);
    }
}