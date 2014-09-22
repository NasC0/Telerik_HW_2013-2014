/* 13. Implement the ADT queue as dynamic linked list. Use generics (LinkedQueue<T>) to allow storing different data types in the queue. */

using System;

namespace LinkedQueueImplementation
{
    class LinkedQueueImplementation
    {
        static void Main()
        {
            LinkedQueue<int> linkedQueue = new LinkedQueue<int>();
            for (int i = 0; i < 30; i++)
            {
                linkedQueue.Enqueue(new LinkedQueueNode<int>(i));
            }

            for (int i = 0; i < linkedQueue.Count; i++)
            {
                Console.WriteLine(linkedQueue.Dequeue().Value);
            }
        }
    }
}
