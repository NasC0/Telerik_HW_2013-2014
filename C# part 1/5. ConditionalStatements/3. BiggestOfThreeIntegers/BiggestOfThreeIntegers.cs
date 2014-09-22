/* 3. Write a program that finds the biggest of three integers using nested if statements. */

using System;

class BiggestOfThreeIntegers
{
    static void Main()
    {
        int firstInt, secondInt, thirdInt;
        int.TryParse(Console.ReadLine(), out firstInt);
        int.TryParse(Console.ReadLine(), out secondInt);
        int.TryParse(Console.ReadLine(), out thirdInt);

        if (firstInt > secondInt)
        {
            if (firstInt > thirdInt)
            {
                Console.WriteLine("{0} is the biggest!", firstInt);
            }
            else
            {
                Console.WriteLine("{0} is the biggest!", thirdInt);
            }
        }
        else if (secondInt > firstInt)
        {
            if (secondInt > thirdInt)
            {
                Console.WriteLine("{0} is the biggest!", secondInt);
            }
            else
            {
                Console.WriteLine("{0} is the biggest!", thirdInt);
            }
        }
    }
}
