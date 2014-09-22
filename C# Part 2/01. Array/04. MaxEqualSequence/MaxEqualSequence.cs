/* 4. Write a program that finds the maximal sequence of equal elements in an array.
		Example: {2, 1, 1, 2, 3, 3, 2, 2, 2, 1}  {2, 2, 2}. */

using System;

class MaxEqualSequence
{
    static void Main()
    {
        int[] arr = { 1, 1, 1, 1, 2, 1, 3, 4, 1, 5, 5, 5, 5, 6 };
        int size = arr.Length;

        int currentSequenceStart = 0, currentSequenceStop = 0;
        int maxSequenceStart = 0, maxSequenceStop = 0;
        int maxSequence = 0;
        int currentCount = 0;
        for (int i = 0; i < size - 1; i++)
        {
            if (arr[i] == arr[i+ 1])
            {
                currentCount = 0;
                int compare = arr[i];
                for (int j = i; j < size - 1; j++)
                {
                    if (arr[j + 1] == compare)
                    {
                        currentCount++;
                        currentSequenceStart = i;
                        currentSequenceStop = j + 1;

                        if (currentCount > maxSequence)
                        {
                            maxSequence = currentCount;
                            maxSequenceStart = currentSequenceStart;
                            maxSequenceStop = currentSequenceStop;
                        }
                    }
                    else
                    {
                        currentCount = 0;
                        break;
                    }
                }
            }
        }

        Console.Write("The maximum sequence is : { ");
        for (int i = maxSequenceStart; i <= maxSequenceStop; i++)
        {
            Console.Write("{0}, ", arr[i]);
        }
        Console.WriteLine("}");
    }
}
