/* 6. Write a program that, for a given two integer numbers N and X, calculates the sumS = 1 + 1!/X + 2!/X2 + … + N!/XN */

using System;
using System.Numerics;

class SequenceFactoriel
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
        Console.WriteLine("Please enter N and X: ");
        int n, x;
        int.TryParse(Console.ReadLine(), out n);
        int.TryParse(Console.ReadLine(), out x);
        BigInteger sum = 1;

        for (int i = 1; i <= n; i++)
        {
            BigInteger currentFactoriel = CalculateFactoriel(i);

            BigInteger powerOfX = 1;
            for (int j = 0; j < i; j++)
            {
                powerOfX *= x;    
            }

            sum += currentFactoriel / powerOfX;
        }

        Console.WriteLine("S = {0}", sum);
    }
}
