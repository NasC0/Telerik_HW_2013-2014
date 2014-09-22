/* 02. Write a program that reads N integers from the console and reverses them using a stack. Use the Stack<int> class. */ 

using System;
using System.Collections.Generic;

class ReverseStack
{
    static void Main()
    {
        int numbersToRead = int.Parse(Console.ReadLine());
        Stack<int> numbersStack = new Stack<int>();

        for (int i = 0; i < numbersToRead; i++)
        {
            numbersStack.Push(int.Parse(Console.ReadLine()));
        }

        while (numbersStack.Count > 0)
        {
            Console.WriteLine(numbersStack.Pop());
        }
    }
}
