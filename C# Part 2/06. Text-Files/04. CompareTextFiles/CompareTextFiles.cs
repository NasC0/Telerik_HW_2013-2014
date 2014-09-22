/* 04. Write a program that compares two text files line by line and prints the number of lines that are the same and the number of lines that are different. 
 * Assume the files have equal number of lines. */

using System;
using System.IO;
using System.Collections.Generic;

class CompareTextFiles
{
    static void Main()
    {
        List<string> firstInput = new List<string>();
        List<string> secondInput = new List<string>();

        StreamReader firstReader = new StreamReader("../../first_input.txt");

        using (firstReader)
        {
            string line = firstReader.ReadLine();
            while (line != null)
            {
                firstInput.Add(line);
                line = firstReader.ReadLine();
            }
        }

        StreamReader secondReader = new StreamReader("../../second_input.txt");

        using (secondReader)
        {
            string line = secondReader.ReadLine();

            while (line != null)
            {
                secondInput.Add(line);
                line = secondReader.ReadLine();
            }
        }

        if (firstInput.Count != secondInput.Count)
        {
            Console.WriteLine("The files length must be equal!");
            return;
        }
        else
        {
            int equalLines = 0;
            int differentLines = 0;
            for (int i = 0; i < firstInput.Count; i++)
            {
                if (firstInput[i] != secondInput[i])
                {
                    differentLines++;
                }
                else
                {
                    equalLines++;
                }
            }

            Console.WriteLine("Number of equal lines: {0}", equalLines);
            Console.WriteLine("Number of different lines: {0}", differentLines);
        }
    }
}
