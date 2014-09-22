/* 10. Write a program that finds in given array of integers a sequence of given sum S (if present). 
 * Example:	 {4, 3, 1, 4, 2, 5, 8}, S=11  {4, 2, 5} */

using System;

class GivenSequenceSum
{
    static void Main()
    {
        int sum = 13;
        int[] arr = { 4, 3, 1, 4, 2, 5, 2, 8 };
        int size = arr.Length;
        int currentSum = 0, subSequenceStart = 0, subSequenceStop = 0;
        bool flag = false;

        for (int i = 0; i < size; i++)
        {
            if (arr[i] > sum)
            {
                continue;
            }

            if (flag == true)
            {
                break;
            }

            currentSum += arr[i];
            subSequenceStart = i;
            for (int j = i + 1; j < size; j++)
            {
                currentSum += arr[j];
                if (currentSum > sum)
                {
                    currentSum = 0;
                    break;
                }
                else if (currentSum == sum)
                {
                    subSequenceStop = j;
                    flag = true;
                    break;
                }

            }
        }

        Console.Write("The sequence with sum {0} is: ", sum);
        Console.Write("{ ");
        for (int i = subSequenceStart; i <= subSequenceStop; i++)
        {
            Console.Write("{0}, ", arr[i]);
        }
        Console.WriteLine("}");
    }
}