/* 18. Write a program for extracting all email addresses from given text. 
 * All substrings that match the format <identifier>@<host>…<domain> should be recognized as emails. */

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class ExtractEmailFromText
{
    static void Main()
    {
        string text = "Hello, my email is Test1230@test.bg, Test2@test123.com, Blabla@blabla.hue";
        List<string> emails = new List<string>();
        string pattern = @"\b[!#$%&'*+./0-9=?_`a-z{|}~^-]+@[.0-9a-z-]+\.[a-z]{2,6}\b";
        int count = 0;
        while (true)
        {
            if (Regex.IsMatch(text, pattern, RegexOptions.IgnoreCase) == true)
            {
                emails.Add(Regex.Match(text, pattern, RegexOptions.IgnoreCase).Value);
                int length = text.IndexOf(emails[count]) + emails[count].Length;
                text = text.Remove(0, length);
                count++;
            }
            else
            {
                break;
            }
        }
        for (int i = 0; i < emails.Count; i++)
        {
            Console.WriteLine(emails[i]);
        }
    }
}
