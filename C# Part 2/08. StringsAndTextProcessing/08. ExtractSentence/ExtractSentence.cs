/* 08. Write a program that extracts from a given text all sentences containing given word. */

using System;
using System.Text;
using System.Text.RegularExpressions;

class ExtractSentence
{
    static void Main()
    {
        StringBuilder sb = new StringBuilder();
        string str = "We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
        Console.WriteLine("Enter the word you want your sentences extracted by: ");
        string extractPattern = Console.ReadLine();
        string[] split = str.Split('.');
        for (int i = 0; i < split.Length; i++)
        {
            split[i] = split[i].TrimStart();
            if (Regex.Matches(split[i], @"\b" + extractPattern + @"\b", RegexOptions.IgnoreCase).Count > 0)
            {
                sb.Append(split[i]);
                sb.Append(". ");
            }
        }
        string result = sb.ToString();
        Console.WriteLine(result);
    }
}