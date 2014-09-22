/* 2. Write a boolean expression that checks for given integer if it can be divided (without remainder) by 7 and 5 in the same time. */
  
using System;

class DivisibleBy5And7
{
    static void Main()
    {
        int test = 35;
        bool divisible = (test % 5 == 0 && test % 7 == 0);
        Console.WriteLine(divisible);
    }
}
