using GenericClasses.Common;
using System;

namespace GenericListTests
{
    class GenericListTests
    {
        static void Main()
        {
            GenericList<int> testList = new GenericList<int>(1);

            // Test Autogrow
            for (int i = 1; i < 6; i++)
            {
                testList.Add(i);
            }

            // ToString test
            Console.WriteLine("ToString test");
            Console.WriteLine(testList);
            Console.WriteLine();

            // Test indexer
            Console.WriteLine("Indexer test, get element at index 2: {0}", testList[2]);
            Console.WriteLine();

            // Remove element at index
            testList.RemoveAt(2);

            Console.WriteLine("After removal at index 2");
            Console.WriteLine(testList);
            Console.WriteLine();

            // Element insert test
            Console.WriteLine("Insert at index 2");
            testList.InsertAt(2, 3);
            Console.WriteLine("Insert at last index");
            testList.InsertAt(testList.Count, testList[testList.Count - 1] + 1);
            Console.WriteLine(testList);
            Console.WriteLine();

            // Search test
            Console.WriteLine("Find element 5");
            Console.WriteLine("Index of element 5: {0}", testList.Find(5));
            Console.WriteLine();

            // Max() and Min() test
            Console.WriteLine("Max element: {0}", testList.Max());
            Console.WriteLine("Min element: {0}", testList.Min());
            Console.WriteLine();

            // Clear list
            Console.WriteLine("Clear list and print");
            testList.Clear();
            Console.WriteLine(testList);
        }
    }
}
