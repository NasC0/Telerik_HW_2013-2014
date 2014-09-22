/* 10. Write a program to calculate the Nth Catalan number by given */

using System;
using System.Numerics;

class CatalanNumber
{
    public static BigInteger CalculateFactoriel(int number)
    {
        BigInteger result = 1;

        for (int i = number; i > 0; i--)
        {
            result *= i;
        }

        return result;
    }
    static void Main()
    {
        Console.WriteLine("Input the number: ");
        int calculateCatalan;
        int.TryParse(Console.ReadLine(), out calculateCatalan);

        BigInteger topPart = CalculateFactoriel(calculateCatalan * 2);
        BigInteger bottomRightFactoriel = CalculateFactoriel(calculateCatalan);
        BigInteger bottomLeftFactoriel = bottomRightFactoriel * (calculateCatalan + 1);
        long catalanNumber = (long)(topPart / (bottomRightFactoriel * bottomLeftFactoriel));

        Console.WriteLine("The catalan number of {0} is {1}", calculateCatalan, catalanNumber);
    }
}
