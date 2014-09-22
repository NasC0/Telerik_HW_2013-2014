/* 1. Write an if statement that examines two integer variables and exchanges their values if the first one is greater than the second one. */

using System;

class CompareTwoIntegers
{
    static void Main()
    {
        int firstInt, secondInt;
        int.TryParse(Console.ReadLine(), out firstInt);
        int.TryParse(Console.ReadLine(), out secondInt);

        if (firstInt > secondInt)
        {

            int temp = firstInt;
            firstInt = secondInt;
            secondInt = temp;
        }
        Console.WriteLine("{0} {1}", firstInt, secondInt);
    }
}
