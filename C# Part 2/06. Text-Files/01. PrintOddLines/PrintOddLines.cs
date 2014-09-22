/* 01. Write a program that reads a text file and prints on the console its odd lines. */

using System;
using System.IO;
using System.Text;

class PrintOddLines
{
    static void Main()
    {
        StreamReader sr = new StreamReader("../../input.txt");

        using (sr)
        {
            int count = 0;

            string line = sr.ReadLine();

            while (line != null)
            {
                if (count % 2 != 0)
                {
                    Console.WriteLine(line);
                }
                count++;
                line = sr.ReadLine();
            }
        }
    }
}
