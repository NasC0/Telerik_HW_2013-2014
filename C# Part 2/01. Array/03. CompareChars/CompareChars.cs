/* 3. Write a program that compares two char arrays lexicographically (letter by letter). */

using System;

class CompareChars
{
    static void Main()
    {
        int size;
        Console.Write("Enter the size of the arrays: ");
        int.TryParse(Console.ReadLine(), out size);
        char[] firstArr = new char[size];
        char[] secondArr = new char[size];

        Console.WriteLine("Enter the first array characters: ");
        for (int i = 0; i < size; i++)
        {
            char.TryParse(Console.ReadLine(), out firstArr[i]);
        }

        Console.WriteLine("Enter the second array characters: ");
        for (int i = 0; i < size; i++)
        {
            char.TryParse(Console.ReadLine(), out secondArr[i]);
        }

        for (int i = 0; i < size; i++)
        {
            if (firstArr[i] < secondArr[i])
            {
                Console.WriteLine("The char at position {0} in the second array is bigger than the one in the first array.", i);
            }
            else if (firstArr[i] > secondArr[i])
            {
                Console.WriteLine("The char at position {0} in the first array is bigger than the one in the second array.", i);
            }
            else
            {
                Console.WriteLine("The chars at position {0} are equal", i);
            }
        }
    }
}
