/* 9. We are given 5 integer numbers. Write a program that checks if the sum of some subset of them is 0. Example: 3, -2, 1, 1, 8 -> 1+1-2=0. */

using System;

class SubsetSum
{
    static void Main()
    {
        Console.WriteLine("Enter five numbers: ");
        int firstNumber = Int32.Parse(Console.ReadLine());
        int secondNumber = Int32.Parse(Console.ReadLine());
        int thirdNumber = Int32.Parse(Console.ReadLine());
        int fourthNumber = Int32.Parse(Console.ReadLine());
        int fifthNumber = Int32.Parse(Console.ReadLine());
        if (firstNumber + secondNumber + thirdNumber + fourthNumber + fifthNumber == 0)
        {
            Console.WriteLine("The sum of the whole set equals 0");
        }
        if (firstNumber == 0)
        {
            Console.WriteLine("The subset [a] equals zero");
        }
        if (secondNumber == 0)
        {
            Console.WriteLine("The subset [b] equals zero");
        }
        if (thirdNumber == 0)
        {
            Console.WriteLine("The subset [c] equals zero");
        }
        if (fourthNumber == 0)
        {
            Console.WriteLine("The subset [d] equals zero");
        }
        if (fifthNumber == 0)
        {
            Console.WriteLine("The subset [e] equals zero");
        }
        if (firstNumber + secondNumber == 0)
        {
            Console.WriteLine("The sum of the subset [a, b] equals zero");
        }
        if (firstNumber + secondNumber + thirdNumber == 0)
        {
            Console.WriteLine("The sum of the subset [a, b, c] equals zero");
        }
        if (firstNumber + secondNumber + thirdNumber + fourthNumber == 0)
        {
            Console.WriteLine("The sum of the subset [a, b, c, d] equals zero");
        }
        if (secondNumber + thirdNumber == 0)
        {
            Console.WriteLine("The sum of the subset [b, c] equals zero");
        }
        if (secondNumber + thirdNumber + fourthNumber == 0)
        {
            Console.WriteLine("The sum of the subset [b, c, d] equals zero");
        }
        if (secondNumber + thirdNumber + fourthNumber + fifthNumber == 0)
        {
            Console.WriteLine("The sum of the subset [b, c, d, e] equals zero");
        }
        if (thirdNumber + fourthNumber == 0)
        {
            Console.WriteLine("The sum of the subset [c, d] equals zero");
        }
        if (thirdNumber + fourthNumber + fifthNumber == 0)
        {
            Console.WriteLine("The sum of the subset [c, d, e] equals zero");
        }
        if (fourthNumber + fifthNumber == 0)
        {
            Console.WriteLine("The sum of the subset [d, e] equals zero");
        }
    }
}