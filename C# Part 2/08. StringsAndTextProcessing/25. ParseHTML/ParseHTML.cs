/* 25. Write a program that extracts from given HTML file its title (if available), and its body text without the HTML tags. */

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class ParseHTML
{
    static string ExtractTitle(string html)
    {
        if (html.Contains("<title>"))
        {
            int startIndex = html.IndexOf("<title>") + 7;
            int lengt = html.IndexOf("</title>") - startIndex;
            string title = html.Substring(startIndex, lengt);
            return title;
        }
        return string.Empty;
    }

    static List<string> ExtractHTML(string html)
    {
        string duplicate = html.Remove(0, html.IndexOf("<body>") + "<body".Length + 1);
        MatchCollection matches = Regex.Matches(duplicate, @"(?<=\>).*?(?=<)");
        List<string> matchCollection = new List<string>();
        foreach (Match match in matches)
        {
            string current = match.ToString();
            if (current.Length > 0 && Char.IsLetter(current[0]))
            {
                matchCollection.Add(current);
            }
        }

        return matchCollection;
    }

    static void Main()
    {
        string html = @"<html><head><title>News</title></head><body><p><a href=""http://academy.telerik.com"">Telerik Academy</a>aims to provide free real-world practicaltraining for young people who want to turn into skillful .NET software engineers.</p></body> </html>";
        string title = ExtractTitle(html);
        var matches = ExtractHTML(html);

        Console.WriteLine(title);
        foreach (string entry in matches)
        {
            Console.WriteLine(entry);
        }
    }
}
