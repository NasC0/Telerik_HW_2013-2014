/* 04. Write a method that finds the longest subsequence of equal numbers in given List<int> 
 * and returns the result as new List<int>. Write a program to test whether the method works correctly. */

using System;
using System.Collections.Generic;

class LongestEqualSubsequence
{
    static List<int> LongestSubsequence(List<int> input)
    {
        input.Sort();
        int maxSequenceStart = int.MinValue;
        int maxSequenceCount = int.MinValue;
        int currentEqualityCount = 1;
        int currentSequenceStart = 0;

        for (int i = 1; i < input.Count; i++)
        {
            if (input[i] == input[i - 1])
            {
                currentEqualityCount++;
            }
            else
            {
                if (currentEqualityCount > maxSequenceCount)
                {
                    maxSequenceCount = currentEqualityCount;
                    maxSequenceStart = currentSequenceStart;
                }

                currentSequenceStart = i;
                currentEqualityCount = 1;
            }
        }

        List<int> result = new List<int>();
        result.AddRange(input.GetRange(maxSequenceStart, maxSequenceCount));

        return result;
    }

    static void Main()
    {
        List<int> originalList = new List<int>()
        {
            2,
            2,
            2,
            1,
            3,
            2,
            4,
            3,
            1,
            5,
            2,
            1,
            7,
            3,
            1,
            2,
        };

        var result = LongestSubsequence(originalList);

        foreach (var number in result)
        {
            Console.WriteLine(number);
        }
    }
}
