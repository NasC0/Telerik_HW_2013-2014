// Dat task name though :D

using System;
using System.Collections.Generic;

namespace _10.HardSequenceOperaions
{
    public class HardSequenceOperations
    {
        public static void Main()
        {
            Console.Write("Enter n: ");
            int n;
            int.TryParse(Console.ReadLine(), out n);

            Console.Write("Enter m (must be bigger than n): ");
            int m;
            int.TryParse(Console.ReadLine(), out m);

            Queue<Operation> operationsQueue = new Queue<Operation>();
            Operation initial = new Operation(n);
            operationsQueue.Enqueue(initial);

            Operation result;
            while (true)
            {
                Operation currentOperation = operationsQueue.Dequeue();
                int currentValue = currentOperation.Value;
                if (currentValue == m)
                {
                    result = currentOperation;
                    break;
                }

                operationsQueue.Enqueue(new Operation(currentValue + 1, currentOperation));
                operationsQueue.Enqueue(new Operation(currentValue + 2, currentOperation));
                operationsQueue.Enqueue(new Operation(currentValue * 2, currentOperation));
            }

            List<int> operationSequence = new List<int>();
            while (result != null)
            {
                operationSequence.Add(result.Value);

                result = result.PreviousOperation;
            }

            operationSequence.Reverse();

            string sequence = String.Join(" -> ", operationSequence);
            Console.WriteLine(sequence);
        }
    }
}
