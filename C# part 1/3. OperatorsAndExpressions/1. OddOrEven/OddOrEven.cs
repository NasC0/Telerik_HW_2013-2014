/* 1. Write an expression that checks if given integer is odd or even. */

using System;

class OddOrEven
{
    static void Main()
    {
        int test = 15;
        bool oddOrEven = (test % 2 == 0);
        Console.WriteLine(oddOrEven);
    }
}
