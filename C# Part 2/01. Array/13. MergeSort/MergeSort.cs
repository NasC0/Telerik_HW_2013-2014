/* 13. * Write a program that sorts an array of integers using the merge sort algorithm (find it in Wikipedia). */

using System;

class MergeSort
{
    static int[] MergeSortRecursive(int[] array)
    {
        int length = array.Length;
        if (length <= 1) // stop splitting array if it is smaller than 2 elements.
        {
            return array;
        }
        int middle = length / 2; // get the middle point of the array.
        int[] leftSide = new int[middle]; // populate the left side
        for (int i = 0; i < middle; i++)
        {
            leftSide[i] = array[i];
        }

        int[] rightSide = new int[length - middle]; // populate the right side

        for (int i = 0; i < length - middle; i++)
        {
            rightSide[i] = array[i + middle];
        }

        leftSide = MergeSortRecursive(leftSide); // recursively split boths sides into smaller parts and sort them
        rightSide = MergeSortRecursive(rightSide);

        int left = 0, right = 0; // after splitting is done, sort and merge the arrays back together.
        int[] result = new int[length];

        for (int i = 0; i < length; i++)
        {
            if (right == rightSide.Length || (left < leftSide.Length && leftSide[left] <= rightSide[right])) // if the right side is finished merging, or if the left side is not finished and it's elements are smaller than the right side ones, add the leftSide item to the result array.
            {
                result[i] = leftSide[left];
                left++;
            }
            else if (left == leftSide.Length || (right < rightSide.Length && rightSide[right] <= leftSide[left])) // if the left side is finished merging, or if the right side is not finished and it's elements are smaller than the left side ones, add the rightSide item to the result array.
            {
                result[i] = rightSide[right];
                right++;
            }
        }

        return result; // return the sorted and merged array.
    }

    static void Main()
    {
        int[] arr = { 10, 2, 7, 9, 3, 1, 6, 1, 3, 9, 5, 8, 2 };

        arr = MergeSortRecursive(arr);

        Console.WriteLine("Sorted array: ");
        for (int i = 0; i < arr.Length; i++)
        {
            Console.WriteLine(arr[i]);
        }
    }
}
