/* 12 Implement the ADT stack as auto-resizable array. Resize the capacity on demand (when no space is available to add / insert a new element). */

using System;
using System.Collections.Generic;

namespace AutoResizableStack
{
    class AutoResizableStackTest
    {
        static void Main()
        {
            AutoResizableStack<int> resizableStack = new AutoResizableStack<int>();
            Console.WriteLine(resizableStack.Capacity);
            Console.WriteLine(resizableStack.Count);

            for (int i = 0; i < 12; i++)
            {
                resizableStack.Push(i);
            }

            Console.WriteLine();

            Console.WriteLine(resizableStack.Capacity);
            Console.WriteLine(resizableStack.Count);

            Console.WriteLine();

            for (int i = 0; i < 8; i++)
            {
                resizableStack.Pop();
            }

            Console.WriteLine(resizableStack.Count);

            Console.WriteLine(resizableStack.Peek());

            for (int i = 20; i < 25; i++)
            {
                resizableStack.Push(i);
            }

            Console.WriteLine(resizableStack.Peek());
        }
    }
}
