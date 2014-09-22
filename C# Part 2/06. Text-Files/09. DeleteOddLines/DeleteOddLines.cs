/* 09. Write a program that deletes from given text file all odd lines. The result should be in the same file. */

using System;
using System.Collections.Generic;
using System.IO;

class DeleteOddLines
{
    static void Main()
    {
        List<string> inputList = new List<string>();
        StreamReader sr = new StreamReader("../../input.txt");

        using (sr)
        {
            string line = sr.ReadLine();

            while (line != null)
            {
                inputList.Add(line);
                line = sr.ReadLine();
            }
        }

        StreamWriter sw = new StreamWriter("../../input.txt");

        using (sw)
        {
            for (int i = 0; i < inputList.Count; i += 2)
            {
                sw.WriteLine(inputList[i]);
            }
        }

        Console.WriteLine("Deleted all odd lines!");
    }
}
