/* 11. Declare  two integer variables and assign them with 5 and 10 and after that exchange their values. */

using System;

class SwapIntegers
{
    static void Main()
    {
        int firstInt = 5;
        int secondInt = 10;
        Console.WriteLine("First int is {0}, second is {1}", firstInt, secondInt);

        int temp = secondInt;
        secondInt = firstInt;
        firstInt = temp;

        Console.WriteLine("Now first int is {0}, second is {1}", firstInt, secondInt);
    }
}
