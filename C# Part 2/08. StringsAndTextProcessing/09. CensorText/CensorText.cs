/* 09. We are given a string containing a list of forbidden words and a text containing some of these words. 
 * Write a program that replaces the forbidden words with asterisks. */

using System;

class CensorText
{

    static void Main()
    {
        Console.WriteLine("Enter your text: ");
        string text = Console.ReadLine();
        Console.WriteLine("Enter the list of forbidden words: ");
        string[] words = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < words.Length; i++)
        {
            int currentIndex = text.IndexOf(words[i]);
            while (currentIndex != -1)
            {
                text = text.Replace(words[i], new string('*', words[i].Length));

                currentIndex = text.IndexOf(words[i]);
            }
        }

        Console.WriteLine(text);
    }
}
