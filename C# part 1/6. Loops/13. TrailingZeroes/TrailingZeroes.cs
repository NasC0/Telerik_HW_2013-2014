/* 13. * Write a program that calculates for given N how many trailing zeros present at the end of the number N!. Examples:
	N = 10 -> N! = 3628800  2
	N = 20 -> N! = 2432902008176640000 -> 4 
    Resources: http://www.purplemath.com/modules/factzero.htm */

using System;

class TrailingZeroes
{
    static void Main()
    {
        Console.WriteLine("Please enter N: ");
        int number;
        int.TryParse(Console.ReadLine(), out number);
        int maxDivisor = 5;
        int trailingZeroes = 0;
        while (maxDivisor <= number)
        {
            if (number - maxDivisor >= 0)
            {
                trailingZeroes += number / maxDivisor;
                maxDivisor *= 5;
            }
        }
        Console.WriteLine("{0}! has {1} trailing zeroes.", number, trailingZeroes);
    }
}
