/* 22. Write a program that reads a string from the console and lists all different words in the string,
 * along with information how many times each word is found. */

using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

class PrintAllDifferentWords
{
    static void Main()
    {
        Console.WriteLine("Enter your text: ");
        string text = Console.ReadLine();

        string[] splitText = text.Split(new char[] { ' ', ',', '.', ':', ';', '!', '?', '\t' }, StringSplitOptions.RemoveEmptyEntries);

        Dictionary<string, int> wordsAndOccurences = new Dictionary<string, int>();

        for (int i = 0; i < splitText.Length; i++)
        {
            if (wordsAndOccurences.ContainsKey(splitText[i]))
            {
                wordsAndOccurences[splitText[i]]++;
            }
            else
            {
                wordsAndOccurences.Add(splitText[i], 1);
            }
        }

        var dictionary = from entry in wordsAndOccurences
                         orderby entry.Value descending, entry.Key ascending
                         select entry;

        foreach (var keyValue in dictionary)
        {
            Console.WriteLine("{0}: {1}", keyValue.Key, keyValue.Value);
        }
    }
}
