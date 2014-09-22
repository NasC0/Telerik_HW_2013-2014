// 100/100 in BGCoder
// LINK - http://bgcoder.com/Contests/Practice/Index/132#0
// You can find the task in the solution folder.

using System;

namespace BinaryPasswords
{
    public class BinaryPasswords
    {
        private const int BinaryPower = 2;

        public static int CountStars(string template)
        {
            int variations = 0;
            for (int i = 0; i < template.Length; i++)
            {
                if (template[i] == '*')
                {
                    variations++;
                }
            }

            return variations;
        }

        public static long GetVariations(int stars)
        {
            long variationsCount = 1;

            for (int i = 0; i < stars; i++)
            {
                variationsCount *= BinaryPower;
            }

            return variationsCount;
        }

        public static void Main()
        {
            string inputTemplate = Console.ReadLine();
            int variationsCount = CountStars(inputTemplate);

            if (variationsCount == 0)
            {
                Console.WriteLine(1);
            }
            else
            {
                Console.WriteLine(GetVariations(variationsCount));
            }
        }
    }
}
