/* 04. Write a program that finds how many times a substring is contained in a given text (perform case insensitive search). */

using System;

class CountAllSpecificSubstrings
{
    static void Main()
    {
        Console.WriteLine("Enter the text: ");
        string text = Console.ReadLine().ToLower();
        Console.WriteLine("Enter the desired substring: ");
        string substring = Console.ReadLine();

        int count = 0;
        int breakFlag = text.IndexOf(substring, 0);
        while (breakFlag != -1)
        {
            text = text.Remove(breakFlag, substring.Length);
            breakFlag = text.IndexOf(substring, 0);
            count++;
        }

        Console.WriteLine("The count of {0} is {1}", substring, count);
    }
}
