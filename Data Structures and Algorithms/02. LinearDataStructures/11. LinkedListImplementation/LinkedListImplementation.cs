/* 11. Implement the data structure linked list. Define a class ListItem<T> that has two fields: 
 * value (of type T) and NextItem (of type ListItem<T>). Define additionally a class 
 * LinkedList<T> with a single field FirstElement (of type ListItem<T>). */

using System;

namespace LinkeListImplementation
{

    class LinkedListImplementation
    {
        static void Main()
        {
            LinkedList<int> linkedList = new LinkedList<int>(new ListItem<int>(2));
            ListItem<int> secondItem = new ListItem<int>(5);
            ListItem<int> thirdItem = new ListItem<int>(6);
            linkedList.FirstElement.NextItem = secondItem;
            secondItem.NextItem = thirdItem;

            foreach (var item in linkedList)
            {
                Console.WriteLine(item.Value);
            }
        }
    }
}
