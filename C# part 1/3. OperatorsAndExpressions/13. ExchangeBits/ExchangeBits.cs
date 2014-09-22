/* 13. Write a program that exchanges bits 3, 4 and 5 with bits 24, 25 and 26 of given 32-bit unsigned integer. */

using System;
using System.Collections.Generic;

class ExchangeBits
{
    static void Main()
    {
        Console.WriteLine("Please enter your number: ");
        int number;
        int.TryParse(Console.ReadLine(), out number);
        int firstSequencePosition = 3;
        int secondSequencePosition = 24;

        for (int i = 0; i < 3; i++)
        {
            int getFirstBit = (number >> firstSequencePosition) & 1;
            int getSecondBit = (number >> secondSequencePosition) & 1;

            if (getFirstBit != getSecondBit)
            {
                if (getFirstBit == 0)
                {
                    number = number & (~(1 << secondSequencePosition));
                }
                else if (getFirstBit == 1)
                {

                    number = number | (1 << secondSequencePosition);
                }

                if (getSecondBit == 0)
                {
                    number = number & (~(1 << firstSequencePosition));
                }
                else if (getSecondBit == 1)
                {

                    number = number | (1 << firstSequencePosition);
                }
            }
            firstSequencePosition++;
            secondSequencePosition++;
        }

        Console.WriteLine("Number after bit exchanging: {0}", number);
    }
}
