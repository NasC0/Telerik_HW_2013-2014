/* 4. Write an expression that checks for given integer if its third digit (right-to-left) is 7. E. g. 1732 -> true. */

using System;

class ThirdDigitCheck
{
    static void Main()
    {
        int test = 732;
        for (int i = 0; i < 2; i++)
        {
            test /= 10;
        }
        bool isSeven = (test % 10 == 7);

        Console.WriteLine(isSeven);
    }
}
