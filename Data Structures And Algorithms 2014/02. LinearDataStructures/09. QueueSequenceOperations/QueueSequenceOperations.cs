using System;
using System.Collections.Generic;

namespace _09.QueueSequenceOperations
{
    public class QueueSequenceOperations
    {
        private const int MaxOperations = 50;

        public static void Main()
        {
            int n;
            int.TryParse(Console.ReadLine(), out n);

            Queue<int> operationsQueue = new Queue<int>();
            int operations = 1;
            operationsQueue.Enqueue(n);

            while (operations < MaxOperations)
            {
                int currentNumber = operationsQueue.Dequeue();
                Console.WriteLine(currentNumber);
                operations++;

                operationsQueue.Enqueue(currentNumber + 1);
                operationsQueue.Enqueue((2 * currentNumber) + 1);
                operationsQueue.Enqueue(currentNumber + 2);
            }
        }
    }
}
