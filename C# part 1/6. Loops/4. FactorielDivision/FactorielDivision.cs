/* 4. Write a program that calculates N!/K! for given N and K (1<K<N). */

using System;
using System.Numerics;

class FactorielDivision
{

    // Implement function that calculates the factoriel of the parsed param. Uses BigInteger because of the unknown size of the input
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
        Console.WriteLine("Input N, K: ");
        int n, k;
        int.TryParse(Console.ReadLine(), out n);
        int.TryParse(Console.ReadLine(), out k);
        if (n < k || n < 1 || k < 1)
        {
            Console.WriteLine("Invalid input!");
        }
        else
        {
            BigInteger nFactoriel = CalculateFactoriel(n);
            BigInteger kFactoriel = CalculateFactoriel(k);

            Console.WriteLine("The factoriel of {0} is {1}", n, nFactoriel);
            Console.WriteLine("The factoriel of {0} is {1}", k, kFactoriel);
            Console.WriteLine("N!/K! = {0}", nFactoriel / kFactoriel);
        }
    }
}
