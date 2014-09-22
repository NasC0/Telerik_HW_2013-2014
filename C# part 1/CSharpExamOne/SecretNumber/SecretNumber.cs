using System;
using System.Numerics;

class SecretNumber
{
    static void Main()
    {
        string alphabet = " ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        BigInteger number;
        BigInteger.TryParse(Console.ReadLine(), out number);
        if (number < 0)
        {
            number *= -1;
        }
        BigInteger holder = number;
        BigInteger specialNumber = 0;
        BigInteger counter = 1;

        while (holder > 0)
        {
            BigInteger remainder = holder % 10;
            holder /= 10;

            if (counter % 2 != 0)
            {
                specialNumber += remainder * (counter * counter);
            }
            else
            {
                specialNumber += (remainder * remainder) * counter;
            }

            counter++;
        }

        Console.WriteLine(specialNumber);

        BigInteger alphaSequenceLength = specialNumber % 10;
        if (alphaSequenceLength <= 0)
        {
            Console.WriteLine("{0} has no secret alpha-sequence", number);
        }
        else
        {
            BigInteger startPosition = (int)(specialNumber % 26) + 1;

            for (int i = 0; i < alphaSequenceLength; i++)
            {
                if (startPosition > 26)
                {
                    startPosition = 1;
                }

                Console.Write(alphabet[(int)startPosition]);

                startPosition++;
            }
            Console.WriteLine();
        }
    }
}
