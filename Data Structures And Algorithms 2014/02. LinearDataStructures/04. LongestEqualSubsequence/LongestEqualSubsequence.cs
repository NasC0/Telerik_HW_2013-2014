using System.Collections.Generic;

namespace _04.LongestEqualSubsequence
{
    public class LongestEqualSubsequence
    {
        public static void Main()
        {
            List<int> sequence = new List<int>()
            {
                1, 2, 1, 5, 4, 7, 1, 9, 9, 9, 9, 2, 1, 2, 2, 2
            };

            List<int> longestEqualSubsequence = new List<int>();

            sequence.Sort();

            int bestStartIndex = 0;
            int startIndex = 0;
            int maxLength = 1;
            int currentLength = 1;
            for (var i = 1; i < sequence.Count; i++)
            {
                int currentNumber = sequence[i];
                int lastNumber = sequence[i - 1];
                if (currentNumber == lastNumber)
                {
                    currentLength++;

                    if (currentLength > maxLength)
                    {
                        maxLength = currentLength;
                        bestStartIndex = startIndex;
                    }
                }
                else
                {
                    currentLength = 1;
                    startIndex = i;
                }
            }

            longestEqualSubsequence.AddRange(sequence.GetRange(bestStartIndex, maxLength));

            foreach (var number in longestEqualSubsequence)
            {
                System.Console.WriteLine(number);
            }
        }
    }
}
