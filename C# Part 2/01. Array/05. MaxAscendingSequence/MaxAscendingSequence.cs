/* 5. Write a program that finds the maximal increasing sequence in an array. 
 * Example: {3, 2, 3, 4, 2, 2, 4}  {2, 3, 4}. */

using System;

class MaxAscendingSequence
{
    static void Main(string[] args)
    {
        int[] arr = { 1, 2, 3, 4, 5, 1, 1, 2, 6, 5, 7, 3, 4, 5, 6, 9, 8 };
        int size = arr.Length;

        int currentSequenceStart = 0, currentSequenceStop = 0, maxSequenceStart = 0, maxSequenceStop = 0;
        int currentSequence = 0, maxSequence = 0;

        for (int i = 0; i < size - 1; i++)
        {
            if (arr[i] == arr[i + 1] - 1)
            {
                currentSequence = 0;
                int compare = arr[i] + 1;
                currentSequenceStart = i;
                currentSequenceStop = i + 1;
                currentSequence++;

                for (int j = i + 1; j < size - 1; j++)
                {
                    if (compare == arr[j + 1] - 1)
                    {
                        compare++;
                        currentSequence++;
                        currentSequenceStop = j + 1;

                        if (currentSequence > maxSequence)
                        {
                            maxSequence = currentSequence;
                            maxSequenceStart = currentSequenceStart;
                            maxSequenceStop = currentSequenceStop;
                        }
                    }
                    else
                    {
                        currentSequence = 0;
                        break;
                    }
                }
            }
        }

        Console.Write("Max Ascending sequence is: { ");
        for (int i = maxSequenceStart; i <= maxSequenceStop; i++)
        {
            Console.Write("{0}, ", arr[i]);
        }
        Console.WriteLine("}");
    }
}
