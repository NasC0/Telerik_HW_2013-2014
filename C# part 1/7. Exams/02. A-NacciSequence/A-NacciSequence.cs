using System;

class ANacciSequence
{
    static void Main()
    {
        string alphabet = " ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string firstSym = Console.ReadLine();
        string secondSym = Console.ReadLine();
        int firstNumber = alphabet.IndexOf(firstSym);
        int secondNumber = alphabet.IndexOf(secondSym);
        int numberOfLines = int.Parse(Console.ReadLine());
        for (int i = 1; i <= numberOfLines; i++)
        {
            int nextIndex = firstNumber + secondNumber;
            if (nextIndex > 26)
            {
                nextIndex = nextIndex % 26;
            }
            if (i == 1)
            {
                Console.WriteLine(firstSym);
            }
            else if (i == 2)
            {
                Console.WriteLine("{0}{1}", alphabet[firstNumber], alphabet[secondNumber]);
            }
            else
            {
                for (int j = 0; j < 2; j++)
                {
                    nextIndex = firstNumber + secondNumber;
                    if (nextIndex > 26)
                    {
                        nextIndex = nextIndex % 26;
                    }
                    Console.Write("{0}", alphabet[secondNumber]);
                    if (j == 0)
                    {
                        Console.Write(new string(' ', i - 2));
                        firstNumber = secondNumber;
                        secondNumber = nextIndex;
                    }
                }
                Console.WriteLine();
            }
            firstNumber = secondNumber;
            secondNumber = nextIndex;
        }
    }
}
