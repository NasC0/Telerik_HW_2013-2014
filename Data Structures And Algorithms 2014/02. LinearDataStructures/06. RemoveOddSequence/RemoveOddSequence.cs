using System;
using System.Collections.Generic;

namespace _06.RemoveOddSequence
{
    public class RemoveOddSequence
    {
        public static void Main()
        {
            List<int> fullSequence = new List<int>()
            {
                1, 2, 1, 5, 4, 7, 1, 9, 9, 9, 9, 2, 1, 2, 2, 2
            };

            List<int> evenSequenceOccurences = new List<int>();

            fullSequence.Sort();

            int currentStartIndex = 0;
            int currentLength = 1;

            for (var i = 1; i < fullSequence.Count; i++)
            {
                int currentNumber = fullSequence[i];
                int lastNumber = fullSequence[i - 1];

                if (currentNumber == lastNumber)
                {
                    currentLength++;
                }
                else
                {
                    if (currentLength % 2 == 0)
                    {
                        evenSequenceOccurences.AddRange(fullSequence.GetRange(currentStartIndex, currentLength));
                    }

                    currentStartIndex = i;
                    currentLength = 1;
                }
            }

            if (currentLength % 2 == 0)
            {
                evenSequenceOccurences.AddRange(fullSequence.GetRange(currentStartIndex, currentLength));
            }

            foreach (var number in evenSequenceOccurences)
            {
                Console.WriteLine(number);
            }
        }
    }
}
