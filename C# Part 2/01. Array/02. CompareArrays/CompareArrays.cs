/* 2. Write a program that reads two arrays from the console and compares them element by element. */

using System;

class CompareArrays
{
    static void Main()
    {
        Console.Write("Enter the size of the arrays: ");
        int size;
        int.TryParse(Console.ReadLine(), out size);
        int[] firstArr = new int[size];
        int[] secondArr = new int[size];

        Console.WriteLine("Enter the first array members: ");
        for (int i = 0; i < size; i++)
        {
            int.TryParse(Console.ReadLine(), out firstArr[i]);
        }

        Console.WriteLine("Enter the second array members: ");
        for (int i = 0; i < size; i++)
        {
            int.TryParse(Console.ReadLine(), out secondArr[i]);
        }

        for (int i = 0; i < size; i++)
        {
            if (firstArr[i] < secondArr[i])
            {
                Console.WriteLine("The number in position {0} in the second array is bigger than the one in the first array.", i);
            }
            else if (firstArr[i] > secondArr[i])
            {
                Console.WriteLine("The number in position {0} in the first array is bigger than the one in the second array.", i);
            }
            else
            {
                Console.WriteLine("The numbers in position {0} are equal", i);
            }
        }
    }
}
