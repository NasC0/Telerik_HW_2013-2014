/* 11. Write a program that deletes from a text file all words that start with the prefix "test". 
 * Words contain only the symbols 0...9, a...z, A…Z, _. */

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

class DeleteWordsWithPrefix
{
    static void Main()
    {
        StreamReader sr = new StreamReader("../../input.txt");
        List<string> inputList = new List<string>();
        string text = "";

        using (sr)
        {
            string line = sr.ReadLine();
            while (line != null)
            {
                inputList.Add(line);
                line = sr.ReadLine();
            }
        }

        string pattern = @"test(\S+)\s?";
        for (int i = 0; i < inputList.Count; i++)
        {
            inputList[i] = Regex.Replace(inputList[i], pattern, "", RegexOptions.IgnoreCase);
        }

        StreamWriter sw = new StreamWriter("../../input.txt");

        using (sw)
        {
            for (int i = 0; i < inputList.Count; i++)
            {
                sw.WriteLine(inputList[i]);
            }
        }

        Console.WriteLine("Words deleted successfully!");
    }
}
