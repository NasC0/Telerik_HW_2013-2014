/* 23. Write a program that reads a string from the console and replaces all series of consecutive 
 * identical letters with a single one. Example: "aaaaabbbbbcdddeeeedssaa"  "abcdedsa". */

using System;
using System.Collections.Generic;
using System.Text;

class TrimConsecutiveLetters
{
    static void Main()
    {

        StringBuilder sb = new StringBuilder();
        string sequence = "aaaaabbbbbcdddeeeedssaa";
        List<char> trimmed = new List<char>();
        for (int i = 0; i < sequence.Length; i++)
        {
            if (i == sequence.Length - 1)
            {
                trimmed.Add(sequence[i]);
                break;
            }
            else if (sequence[i] != sequence[i + 1])
            {
                trimmed.Add(sequence[i]);
            }
        }
        for (int i = 0; i < trimmed.Count; i++)
        {
            sb.Append(trimmed[i]);
        }
        sequence = sb.ToString();
        Console.WriteLine(sequence);

    }
}
