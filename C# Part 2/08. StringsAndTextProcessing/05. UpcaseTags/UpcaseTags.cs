/* 05. You are given a text. Write a program that changes the text in all regions surrounded by the tags <upcase> and </upcase> to uppercase. 
 * The tags cannot be nested. */

using System;
using System.Collections.Generic;

class UpcaseTags
{
    static void Main()
    {
        Console.WriteLine("Enter the your string, and surround the words you want upcased with the <upcase></upcase> tags: ");
        string upcase = Console.ReadLine();
        string result = UpcaseSubstrings(upcase);
        Console.WriteLine(result);
    }

    static string UpcaseSubstrings(string upcase)
    {
        string duplicate = upcase;
        List<string> subStrings = new List<string>();
        while (true)
        {
            if (upcase.IndexOf("<upcase>") == -1)
            {
                break;
            }
            else
            {
                int startPosition = upcase.IndexOf("<upcase>");
                int endPosition = upcase.IndexOf("</upcase>");
                subStrings.Add(upcase.Substring(startPosition, (endPosition + 9 - startPosition)));
                subStrings.Add(upcase.Substring(startPosition + "<upcase>".Length, endPosition - startPosition - 8).ToUpper());
                upcase = upcase.Remove(0, endPosition + 8);
            }
        }
        for (int i = 0; i < subStrings.Count; i = i + 2)
        {
            duplicate = duplicate.Replace(subStrings[i], subStrings[i + 1]);
        }
        return duplicate;
    }
}

