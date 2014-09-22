/* 10. * We are given numbers N and M and the following operations:
N = N+1
N = N+2
N = N*2
Write a program that finds the shortest sequence of operations from the list above that starts from N and finishes in M. Hint: use a queue.
Example: N = 5, M = 16
Sequence: 5  7  8  16 */

using System;
using System.Collections.Generic;
using System.Linq;

class ShortestOperationsSequence
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int m = int.Parse(Console.ReadLine());

        List<int> operationResults = new List<int>();
        operationResults.Add(n);

        while (n <= m)
        {
            if (n + 1 == m)
            {
                operationResults.Add(n + 1);
                break;
            }
            else if (n + 2 == m)
            {
                operationResults.Add(n + 1);
                break;
            }
            else if (n * 2 == m)
            {
                operationResults.Add(n * 2);
                break;
            }

            if (n * 2 < m)
            {
                operationResults.Add(n * 2);
                n *= 2;
            }
            else if (n + 2 < m)
            {
                operationResults.Add(n + 2);
                n += 2;
            }
            else if (n + 1 < m)
            {
                operationResults.Add(n + 1);
                n++;
            }
        }
    }
}
