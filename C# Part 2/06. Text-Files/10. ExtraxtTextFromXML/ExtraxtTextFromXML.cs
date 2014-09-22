/* 10. Write a program that extracts from given XML file all the text without the tags. */

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

class ExtraxtTextFromXML
{
    static void Main()
    {
        StreamReader sr = new StreamReader("../../input.xml");

        string fullText = "";

        using (sr)
        {
            fullText = sr.ReadToEnd();
        }

        string pattern = @"(?<=\>).*?(?=<)";

        MatchCollection matches = Regex.Matches(fullText, pattern);

        StreamWriter sw = new StreamWriter("../../result.txt");
        using (sw)
        {
            foreach (var match in matches)
            {
                string current = match.ToString();
                current = current.Trim();
                if (current.Length > 0 && !Char.IsControl(current[0]))
                {
                    sw.WriteLine(current);
                }
            }
        }
    }
}
