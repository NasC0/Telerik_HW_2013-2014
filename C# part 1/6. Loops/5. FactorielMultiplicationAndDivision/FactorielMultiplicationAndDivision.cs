/* 5. Write a program that calculates N!*K! / (K-N)! for given N and K (1<N<K). */
 
using System;
using System.Numerics;

class FactorielMultiplicationAndDivision
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
        Console.WriteLine("Input N, K: ");
        int n, k;
        int.TryParse(Console.ReadLine(), out n);
        int.TryParse(Console.ReadLine(), out k);
        if (n > k || k < 1 || n < 1)
        {
            Console.WriteLine("Invalid input!");
        }
        else
        {
            int remainder = k - n;
            BigInteger nFactoriel = CalculateFactoriel(n);
            BigInteger kFactoriel = CalculateFactoriel(k);
            BigInteger remainderFactoriel = CalculateFactoriel(remainder);

            Console.WriteLine("The factoriel of {0} is {1}", n, nFactoriel);
            Console.WriteLine("The factoriel of {0} is {1}", k, kFactoriel);
            Console.WriteLine("N!*K!/(K-N)! = {0}", (nFactoriel * kFactoriel) / remainderFactoriel);
        }

    }
}
