/* 8. Write a program that finds the sequence of maximal sum in given array. Example:
	{2, 3, -6, -1, 2, -1, 6, 4, -8, 8}  {2, -1, 6, 4} */

using System;

class MaximumSum
{

    // Uses Kadane's Algorithm
    // http://en.wikipedia.org/wiki/Maximum_subarray_problem
    static void Main()
    {
        int[] arr = { 2, 3, -6, -1, 2, -1, 6, 4, -8, 8 };
        int currentSum = 0, maxSum = 0;
        int currentStart = 0, currentStop = 0;
        int maxStart = 0, maxStop = 0;
        int size = arr.Length;

        for (int i = 0; i < size; i++)
        {
            currentSum += arr[i];
            if (arr[i] > currentSum)
            {
                currentSum = arr[i];
                currentStart = i;
            }

            if (currentSum > maxSum)
            {
                maxSum = currentSum;
                maxStart = currentStart;
                maxStop = i;
            }
        }

        Console.Write("The maximum sum sequence is: { ");
        for (int i = maxStart; i <= maxStop; i++)
        {
            Console.Write("{0}, ", arr[i]);
        }
        Console.WriteLine("}");
        Console.WriteLine("The maximum sum is: {0}", maxSum);
    }
}
