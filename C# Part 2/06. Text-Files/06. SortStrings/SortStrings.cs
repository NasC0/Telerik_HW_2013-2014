/* 06. Write a program that reads a text file containing a list of strings, sorts them and saves them to another text file. */

using System;
using System.Collections.Generic;
using System.IO;

class SortStrings
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

        inputList.Sort();

        StreamWriter sw = new StreamWriter("../../result.txt");

        using (sw)
        {
            for (int i = 0; i < inputList.Count; i++)
            {
                sw.WriteLine(inputList[i]);
            }
        }

        Console.WriteLine("Sorting succesful!");
    }
}
