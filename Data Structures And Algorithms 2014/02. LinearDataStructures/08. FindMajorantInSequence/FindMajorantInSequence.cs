using System;
using System.Collections.Generic;

namespace _08.FindMajorantInSequence
{
    public class FindMajorantInSequence
    {
        public static void Main()
        {
            List<int> sequence = new List<int>()
            {
                4, 2, 4, 4, 2, 3, 4, 2, 4
            };

            int majorantSize = (sequence.Count / 2) + 1;
            sequence.Sort();

            int currentLength = 1;
            bool majorantFound = false;
            int majorant = 0;
            for (int i = 1; i < sequence.Count; i++)
            {
                int currentNumber = sequence[i];
                int previousNumber = sequence[i - 1];

                if (currentNumber == previousNumber)
                {
                    currentLength++;

                    if (currentLength >= majorantSize)
                    {
                        majorantFound = true;
                        majorant = currentNumber;
                        break;
                    }
                }
                else
                {
                    currentLength = 1;
                }

                if (i >= majorantSize && currentLength == 1)
                {
                    break;
                }
            }

            if (majorantFound)
            {
                Console.WriteLine("Majorant found: {0}", majorant);
            }
            else
            {
                Console.WriteLine("Majorant not found.");
            }
        }
    }
}
