// 100/100 in BGCoder
// LINK - http://bgcoder.com/Contests/Practice/Index/132#2
// You can find the task in the solution folder

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wintellect.PowerCollections;

namespace Divisors
{
    public class Divisors
    {
        private static string numbersInput;
        private static List<int> numbersVariations;
        private static bool[] elementsUsed;
        private static char[] variations;
        private static MultiDictionary<int, int> numberDivisorsDictionary = new MultiDictionary<int, int>(true);

        public static void GetNumberVariations(string numbers)
        {
            elementsUsed = new bool[numbers.Length];
            numbersVariations = new List<int>();
            variations = new char[numbers.Length];
            GenerateVariations(0);
        }

        public static void GenerateVariations(int index)
        {
            if (index >= elementsUsed.Length)
            {
                string wholeNumber = string.Join("", variations);
                numbersVariations.Add(int.Parse(wholeNumber));
            }
            else
            {
                for (int i = 0; i < elementsUsed.Length; i++)
                {
                    if (!elementsUsed[i])
                    {
                        elementsUsed[i] = true;
                        variations[index] = numbersInput[i];
                        GenerateVariations(index + 1);
                        elementsUsed[i] = false;
                    }
                }
            }
        }

        public static int GetLowestDivisorCount()
        {
            foreach (var number in numbersVariations)
            {
                numberDivisorsDictionary.Add(GetNumberOfDivisors(number), number);
            }

            var minKey = numberDivisorsDictionary.Min(x => x.Key);
            return numberDivisorsDictionary[minKey].Min(x => x);
        }

        private static int GetNumberOfDivisors(int number)
        {
            int factorCount = 0;
            int sqrt = (int)Math.Ceiling(Math.Sqrt(number));

            for (int i = 1; i < sqrt; i++)
            {
                if (number % i == 0)
                {
                    factorCount += 2;
                }
            }

            if (sqrt * sqrt == number)
            {
                factorCount++;
            }

            return factorCount;
        }

        static void Main()
        {
            int numbersCount = int.Parse(Console.ReadLine());
            StringBuilder numberBuilder = new StringBuilder();

            for (int i = 0; i < numbersCount; i++)
            {
                numberBuilder.Append(Console.ReadLine());
            }

            numbersInput = numberBuilder.ToString();
            GetNumberVariations(numberBuilder.ToString());
            int lowestDivisorCount = GetLowestDivisorCount();
            Console.WriteLine(lowestDivisorCount);
        }
    }
}
