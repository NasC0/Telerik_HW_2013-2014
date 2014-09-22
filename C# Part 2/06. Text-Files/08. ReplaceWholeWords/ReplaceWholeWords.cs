/* 08. Modify the solution of the previous problem to replace only whole words (not substrings). */

using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class ReplaceWholeWords
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
                string pattern = @"\bstart\b";
                string replace = "finish";
                line = Regex.Replace(line, pattern, replace);
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

        Console.WriteLine("Words replaced successfully!");
    }
}
