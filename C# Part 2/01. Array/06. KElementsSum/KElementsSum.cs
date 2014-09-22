/* 6. Write a program that reads two integer numbers N and K and an array of N elements from the console. 
 * Find in the array those K elements that have maximal sum. */

using System;

class KElementsSum
{
    static void Main()
    {
        Console.Write("Enter the size of your array: ");
        int arrSize;
        int.TryParse(Console.ReadLine(), out arrSize);
        int[] arr = new int[arrSize];

        Console.WriteLine("Populate your array: ");
        for (int i = 0; i < arrSize; i++)
        {
            int.TryParse(Console.ReadLine(), out arr[i]);
        }

        int sequenceLength;
        Console.Write("Enter the sequence length: ");
        int.TryParse(Console.ReadLine(), out sequenceLength);
        sequenceLength--; // Decrement by 1 to accomodate for array index starting at 0

        int currentSum = 0, maxSum = 0;
        int maxSequenceStart = 0, maxSequenceStop = 0;

        for (int i = 0; i < arrSize; i++)
        {
            currentSum = 0;
            if (i + sequenceLength >= arrSize)
            {
                break;
            }
            else
            {
                for (int j = i; j <= i + sequenceLength; j++)
                {
                    currentSum += arr[j];
                }
                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                    maxSequenceStart = i;
                    maxSequenceStop = i + sequenceLength;
                }
            }
        }

        Console.Write("The sequence with maxmimum sum is: { ");

        for (int i = maxSequenceStart; i <= maxSequenceStop; i++)
        {
            Console.Write("{0}, ", arr[i]);
        }
        Console.WriteLine("}");

        Console.WriteLine("Maximum Sum: {0}", maxSum);
    }
}