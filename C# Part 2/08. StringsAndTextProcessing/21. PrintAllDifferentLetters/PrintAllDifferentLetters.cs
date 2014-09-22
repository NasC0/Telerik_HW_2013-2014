/* 21. Write a program that reads a string from the console and prints all different letters 
 * in the string along with information how many times each letter is found. */

using System;
using System.Collections.Generic;
using System.Linq;

class PrintAllDifferentLetters
{
    static void Main()
    {
        Console.WriteLine("Enter your text: ");
        string text = Console.ReadLine().ToUpper();
        Dictionary<char, int> lettersAndOccurences = new Dictionary<char, int>();

        for (int i = 0; i < text.Length; i++)
        {
            if (Char.IsLetter(text[i]) && !lettersAndOccurences.ContainsKey(text[i]))
            {
                lettersAndOccurences.Add(text[i], 1);
            }
            else if (Char.IsLetter(text[i]) && lettersAndOccurences.ContainsKey(text[i]))
            {
                lettersAndOccurences[text[i]]++;
            }
        }

        var dictionary = from entry in lettersAndOccurences
                         orderby entry.Value descending, entry.Key ascending
                         select entry;

        foreach (var keyValue in dictionary)
        {
            Console.WriteLine("{0}: {1}", keyValue.Key, keyValue.Value);
        }
    }
}
