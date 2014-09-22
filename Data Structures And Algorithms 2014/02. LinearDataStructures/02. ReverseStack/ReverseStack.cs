using System;
using System.Collections.Generic;

namespace _02.ReverseStack
{
    public class ReverseStack
    {
        public static void Main()
        {
            Console.WriteLine("Enter N");
            int n;
            int.TryParse(Console.ReadLine(), out n);

            Stack<int> inputNumbers = new Stack<int>();

            for (var i = 0; i < n; i++) 
            {
                int currentNumber;
                int.TryParse(Console.ReadLine(), out currentNumber);
                inputNumbers.Push(currentNumber);
            }

            List<int> reversedInputNumbers = new List<int>();

            while (inputNumbers.Count > 0)
            {
                int outputNumbers = inputNumbers.Pop();
                reversedInputNumbers.Add(outputNumbers);
            }

            foreach (var number in reversedInputNumbers)
            {
                Console.WriteLine(number);
            }
        }
    }
}
