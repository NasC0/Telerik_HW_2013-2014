/* 14. * Write a program that exchanges bits {p, p+1, …, p+k-1) with bits {q, q+1, …, q+k-1} of given 32-bit unsigned integer. */

using System;

class ExchangeGivenSequenceOfBits
{
    static void Main()
    {
        Console.WriteLine("Please enter your number, length of the sequences, first sequence start position and second sequence start position: ");
        int number, length, firstSequenceStart, secondSequenceStart;
        int.TryParse(Console.ReadLine(), out number);
        int.TryParse(Console.ReadLine(), out length);
        int.TryParse(Console.ReadLine(), out firstSequenceStart);
        int.TryParse(Console.ReadLine(), out secondSequenceStart);

        for (int i = 0; i < length; i++)
        {
            int getFirstBit = (number >> firstSequenceStart) & 1;
            int getSecondBit = (number >> secondSequenceStart) & 1;

            if (getFirstBit != getSecondBit)
            {
                if (getFirstBit == 0)
                {
                    number = number & (~(1 << secondSequenceStart));
                }
                else if (getFirstBit == 1)
                {

                    number = number | (1 << secondSequenceStart);
                }

                if (getSecondBit == 0)
                {
                    number = number & (~(1 << firstSequenceStart));
                }
                else if (getSecondBit == 1)
                {

                    number = number | (1 << firstSequenceStart);
                }
            }
            firstSequenceStart++;
            secondSequenceStart++;
        }

        Console.WriteLine("Number after bit exchanging: {0}", number);
    }
}
