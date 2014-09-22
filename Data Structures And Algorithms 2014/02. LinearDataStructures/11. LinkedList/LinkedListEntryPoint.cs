using System;

namespace _11.LinkedList
{
    public class LinkedListEntryPoint
    {
        public static void Main()
        {
            LinkedListItem<int> firstElement = new LinkedListItem<int>(1);
            LinkedList<int> linkedListTest = new LinkedList<int>(firstElement);

            Console.WriteLine(linkedListTest.FirstValue);
            Console.WriteLine(linkedListTest.LastValue);
            Console.WriteLine("-----------------");

            linkedListTest.AddToBack(new LinkedListItem<int>(2));
            linkedListTest.AddToBack(new LinkedListItem<int>(3));

            Console.WriteLine(linkedListTest.FirstValue);
            Console.WriteLine(linkedListTest.LastValue);
            Console.WriteLine("-----------------");

            linkedListTest.AddToFront(new LinkedListItem<int>(0));

            Console.WriteLine(linkedListTest.FirstValue);
            Console.WriteLine(linkedListTest.LastValue);
            Console.WriteLine("-----------------");

            Console.WriteLine(linkedListTest.FirstValue.NextItem);
            Console.WriteLine("-----------------");

            Console.WriteLine(linkedListTest.LastValue.NextItem);
        }
    }
}
