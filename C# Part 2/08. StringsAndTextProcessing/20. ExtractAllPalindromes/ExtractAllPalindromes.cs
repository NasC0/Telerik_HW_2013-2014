/* 20. Write a program that extracts from a given text all palindromes, e.g. "ABBA", "lamal", "exe". */

using System;

class ExtractAllPalindromes
{
    static bool IsPalindrome(string word)
    {
        word = word.ToLower();
        bool result = false;
        if (word[0] == word[word.Length - 1])
        {
            int size = word.Length / 2;
            int start = 1;
            int end = word.Length - 2;
            for (int i = 0; i < size - 1; i++)
            {
                if (word[start] == word[end])
                {
                    result = true;
                    start++;
                    end--;
                }
                else
                {
                    result = false;
                    break;
                }
            }
        }
        else
        {
            result = false;
        }
        return result;
    }

    static void Main()
    {
        string test = "Dewed, word, civic, normal, deified, test, devoved, Hannah, peeweep, repaper, aibohphobia";
        char[] splitRegulations = { ' ', '.', '!', '?', ',', '-', ':', ';' };
        string[] split = test.Split(splitRegulations, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < split.Length; i++)
        {
            if (IsPalindrome(split[i]) == true)
            {
                Console.WriteLine(split[i]);
            }
        }
    }
}
