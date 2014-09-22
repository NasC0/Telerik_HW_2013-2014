/* 3. Write a program that safely compares floating-point numbers with precision of 0.000001. 
 * Examples:(5.3 ; 6.01) -> false;  (5.00000001 ; 5.00000003) -> true */

using System;

class CompareFloatingPointNumbers
{
    static void Main()
    {
        float firstNumber = 5.00000001f;
        float secondNumber = 5.00000003f;

        // checks if the numbers are equal without an "if" condition
        bool areEqual = firstNumber == secondNumber;

        Console.WriteLine(areEqual);
    }
}