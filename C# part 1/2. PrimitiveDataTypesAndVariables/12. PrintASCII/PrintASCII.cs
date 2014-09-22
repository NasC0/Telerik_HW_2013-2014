/* 12. Find online more information about ASCII (American Standard Code for Information Interchange) and write a program that prints the entire ASCII table of characters on the console. */

using System;

class PrintASCII
{
    static void Main()
    {
        char symbol = '\0';
        for (int i = 0; i < 256; i++)
        {
            Console.Write(" {0} ", symbol);
            symbol++;

            if (i % 10 == 0)
            {
                Console.WriteLine();
            }
        }
        Console.WriteLine();
    }
}
