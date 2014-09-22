/* 10. Write a program to calculate the sum (with accuracy of 0.001): 1 + 1/2 - 1/3 + 1/4 - 1/5 + ... */

using System;

class SequenceSum
{
    static void Main()
    {
        double signChange = 1;
        double sum = 1;
        double counter = 2;
        double temp = 1;

        while (temp > 0.001)
        {
            temp = 1 / counter;
            if (counter % 2 == 0)
            {
                sum += temp;
            }
            else
            {
                sum -= temp;
            }
            counter++;
        }

        Console.WriteLine("{0: 0.000}", sum);
    }
}
