/* 12. Write a program that creates an array containing all letters from the alphabet (A-Z). 
 * Read a word from the console and print the index of each of its letters in the array. */

using System;

class CharArray
{
    static string alphabet = " ABCDEFGHIJKLMNOPQRSTUVWXYZ"; // interval at the start to accomodate for the first element being index 0.

    static void Main()
    {
        Console.Write("Enter your wod: ");
        string word = Console.ReadLine();

        for (int i = 0; i < word.Length; i++)
        {
            int index = alphabet.IndexOf(word[i].ToString().ToUpper());
            Console.WriteLine("{0, -2} - {1}", index, alphabet[index]);
        }
    }
}
