using System;
using System.Linq;
using System.Diagnostics;

class AssertionsHomework
{
    public static void SelectionSort<T>(T[] arr) where T : IComparable<T>
    {
        Debug.Assert(arr != null && arr.Length > 0, "Input array must be initialized and not empty.");

        for (int index = 0; index < arr.Length - 1; index++)
        {
            int minElementIndex = FindMinElementIndex(arr, index, arr.Length - 1);
            Swap(ref arr[index], ref arr[minElementIndex]);
        }
    }

    private static int FindMinElementIndex<T>(T[] arr, int startIndex, int endIndex)
        where T : IComparable<T>
    {
        Debug.Assert(startIndex >= 0, "Start index must be positive.");
        Debug.Assert(endIndex < arr.Length, "End index must be smaller than the array length.");
        int minElementIndex = startIndex;

        for (int i = startIndex + 1; i <= endIndex; i++)
        {
            if (arr[i].CompareTo(arr[minElementIndex]) < 0)
            {
                minElementIndex = i;
            }
        }

        return minElementIndex;
    }

    private static void Swap<T>(ref T x, ref T y)
    {
        Debug.Assert(x != null, "X value is null");
        Debug.Assert(y != null, "Y value is null");

        T oldX = x;
        x = y;
        y = oldX;
    }

    public static int BinarySearch<T>(T[] arr, T value) where T : IComparable<T>
    {
        Debug.Assert(arr != null && arr.Length > 0, "Input array must be initialized and not empty.");
        Debug.Assert(value != null, "Search value must not be null.");

        for (int i = 1; i < arr.Length; i++)
        {
            bool isBigger = arr[i].CompareTo(arr[i - 1]) > -1;
            Debug.Assert(isBigger, "Input array must be sorted.");
        }

        var searchResult = BinarySearch(arr, value, 0, arr.Length - 1);

        Debug.Assert(searchResult == -1 || arr[searchResult].Equals(value));

        return searchResult;
    }

    private static int BinarySearch<T>(T[] arr, T value, int startIndex, int endIndex)
        where T : IComparable<T>
    {
        Debug.Assert(endIndex < arr.Length, "End index must be smaller than the array length.");
        Debug.Assert(startIndex >= 0, "Start index must be positive.");

        while (startIndex <= endIndex)
        {
            int midIndex = (startIndex + endIndex) / 2;
            if (arr[midIndex].Equals(value))
            {
                return midIndex;
            }
            if (arr[midIndex].CompareTo(value) < 0)
            {
                // Search on the right half
                startIndex = midIndex + 1;
            }
            else
            {
                // Search on the right half
                endIndex = midIndex - 1;
            }
        }

        // Searched value not found
        return -1;
    }

    static void Main()
    {
        int[] arr = new int[] { 3, -1, 15, 4, 17, 2, 33, 0 };
        Console.WriteLine("arr = [{0}]", string.Join(", ", arr));
        SelectionSort(arr);
        Console.WriteLine("sorted = [{0}]", string.Join(", ", arr));

        // Sorting an empty collection should throw a fatal error if it's one of the program's main features.
        //SelectionSort(new int[0]); // Test sorting empty array

        // Sorting over a one element collection is meaningless, but it's not grounds for
        // a fatal error.
        SelectionSort(new int[1]); // Test sorting single element array

        //Console.WriteLine(BinarySearch(new int[0], 5));
        Console.WriteLine(BinarySearch(arr, -1000));
        Console.WriteLine(BinarySearch(arr, 0));
        Console.WriteLine(BinarySearch(arr, 17));
        Console.WriteLine(BinarySearch(arr, 10));
        Console.WriteLine(BinarySearch(arr, 1000));
    }
}
