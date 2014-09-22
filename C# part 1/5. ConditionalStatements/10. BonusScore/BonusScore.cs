/* 10. Write a program that applies bonus scores to given scores in the range [1..9]. The program reads a digit as an input. 
 * If the digit is between 1 and 3, the program multiplies it by 10; if it is between 4 and 6, multiplies it by 100; if it is between 7 and 9, multiplies it by 1000. 
 * If it is zero or if the value is not a digit, the program must report an error.
 * Use a switch statement and at the end print the calculated new value in the console. */

using System;

class BonusScore
{
    static void Main()
    {
        Console.Write("Please enter score multiplier: ");
        byte digit;
        byte.TryParse(Console.ReadLine(), out digit);
        int score = digit;

        switch (digit)
        {
            case 1:
                score = 10 * digit;
                break;
            case 2:
                score = 10 * digit;
                break;
            case 3:
                score = 10 * digit;
                break;
            case 4:
                score = 100 * digit;
                break;
            case 5:
                score = 100 * digit;
                break;
            case 6:
                score = 100 * digit;
                break;
            case 7:
                score = 1000 * digit;
                break;
            case 8:
                score = 1000 * digit;
                break;
            case 9:
                score = 1000 * digit;
                break;
            default:
                Console.WriteLine("Invalid input!");
                break;
        }
        Console.WriteLine("Total score: {0}", score);
    }
}
