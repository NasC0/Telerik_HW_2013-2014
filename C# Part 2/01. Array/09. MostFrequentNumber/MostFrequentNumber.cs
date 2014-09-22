/* 9. Write a program that finds the most frequent number in an array. Example:
	{4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3}  4 (5 times) */

using System;

class MostFrequentNumber
{
    static void Main()
    {
        int[] arr = { 4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3 };
        int size = arr.Length;
        int currentOccurence = 0, maxOccurence = 0, number = 0, finalNumber = 0;
        for (int i = 0; i < size; i++)
        {
            number = arr[i];
            currentOccurence = 1;
            for (int j = i + 1; j < size; j++)
            {
                if (arr[j] == number)
                {
                    currentOccurence++;
                }
            }
            if (currentOccurence > maxOccurence)
            {
                maxOccurence = currentOccurence;
                finalNumber = number;
            }
        }
        Console.WriteLine("The most repeated number is {0} with {1} occurences", finalNumber, maxOccurence);
    }
}
