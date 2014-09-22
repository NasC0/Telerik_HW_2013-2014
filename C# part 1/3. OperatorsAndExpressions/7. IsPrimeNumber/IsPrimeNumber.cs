/* 7. Write an expression that checks if given positive integer number n (n ≤ 100) is prime. E.g. 37 is prime. */

using System;
using System.IO;

class IsPrimeNumber
{
    static void Main()
    {
        int number = 37;
        int numberSquareRoot = (int)Math.Sqrt(number);
        int counter = 2;
        bool isPrime = true;
        while (counter <= numberSquareRoot && isPrime == true)
        {
            if (number % counter == 0)
            {
                isPrime = false;
            }
            counter++;
        }
        Console.WriteLine(isPrime);
    }
}
