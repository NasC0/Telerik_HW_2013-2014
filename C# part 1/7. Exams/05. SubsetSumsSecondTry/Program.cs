using System;

class Program
{
    static void Main(string[] args)
    {
        long sum = int.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());

        long[] numbers = new long[n];

        for (int i = 0; i < n; i++)
        {
            numbers[i] = long.Parse(Console.ReadLine());
        }

        int counter = 0;
        int combinations = (int)Math.Pow(2, n);

        for (int i = 0; i < combinations; i++)
        {
            for (int j = 0; j < n; j++)
            {

            }
        }
    }
}
