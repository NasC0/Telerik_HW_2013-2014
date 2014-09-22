/* 11. Write a program that finds the index of given element in a sorted array of integers 
 * by using the binary search algorithm (find it in Wikipedia). */

using System;

class BinarySearch
{
    static int[] SelectionSort(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            int minValue = i;
            for (int j = i; j < arr.Length; j++)
            {
                if (arr[j] < arr[minValue])
                {
                    minValue = j;
                }
            }
            int temp = arr[minValue];
            arr[minValue] = arr[i];
            arr[i] = temp;
        }

        return arr;
    }

    static void Main()
    {
        int[] arr = { 10, 1, 3, 7, 4, 0, 1, 9, 3, 2, 5, 1 };
        arr = SelectionSort(arr);

        int searchStart = 0, searchEnd = arr.Length - 1, searchMiddle = 0;
        int searchItem = 10;

        while (searchStart <= searchEnd)
        {
            searchMiddle = (searchStart + searchEnd) / 2;
            if (searchItem > arr[searchMiddle])
            {
                searchStart = searchMiddle + 1;
            }
            else if (searchItem < arr[searchMiddle])
            {
                searchEnd = searchMiddle - 1;
            }
            else if (arr[searchMiddle] == searchItem)
            {
                Console.WriteLine("Found item {0}", searchItem);
                break;
            }
        }
    }
}
