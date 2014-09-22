/* 7. Sorting an array means to arrange its elements in increasing order. Write a program to sort an array. 
 * Use the "selection sort" algorithm: Find the smallest element, move it at the first position, 
 * find the smallest from the rest, move it at the second position, etc. */

using System;

class SelectionSort
{
    static void Main()
    {
        int arrSize;
        Console.Write("Enter the size of your array: ");
        int.TryParse(Console.ReadLine(), out arrSize);
        int[] arr = new int[arrSize];
        Console.WriteLine("Populate your array: ");

        for (int i = 0; i < arrSize; i++)
        {
            int.TryParse(Console.ReadLine(), out arr[i]);
        }

        for (int i = 0; i < arrSize; i++)
        {
            int minValue = i;
            for (int j = i; j < arrSize; j++)
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

        Console.WriteLine();

        for (int i = 0; i < arrSize; i++)
        {
            Console.WriteLine(arr[i]);
        }
    }
}
