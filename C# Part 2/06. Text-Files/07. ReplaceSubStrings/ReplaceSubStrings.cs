/* 07. Write a program that replaces all occurrences of the substring "start" with the substring "finish" in a text file. Ensure it will work with large files (e.g. 100 MB). */

using System;
using System.Collections.Generic;
using System.IO;

class ReplaceSubStrings
{
    static void Main()
    {
        StreamReader sr = new StreamReader("../../input.txt");
        List<string> inputList = new List<string>();

        using (sr)
        {
            string line = sr.ReadLine();
            while (line != null)
            {
                line = line.Replace("start", "finish");
                inputList.Add(line);
                line = sr.ReadLine();
            }
        }

        StreamWriter sw = new StreamWriter("../../input.txt");

        using (sw)
        {
            for (int i = 0; i < inputList.Count; i++)
            {
                sw.WriteLine(inputList[i]);
            }
        }
    }
}
