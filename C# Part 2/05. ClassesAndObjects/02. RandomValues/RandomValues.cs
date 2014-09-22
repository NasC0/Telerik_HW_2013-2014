/* 02. Write a program that generates and prints to the console 10 random values in the range [100, 200]. */

using System;

class RandomValues
{
    static Random randomGenerator = new Random();

    static void Main()
    {
        for (int i = 0; i < 11; i++)
        {
            int rand = randomGenerator.Next(100, 201);
            Console.WriteLine(rand);
        }
    }
}
