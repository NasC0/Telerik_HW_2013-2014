using System;
using System.Collections.Generic;

namespace CoundDoubleOccurences
{
    public class CoundDoubleOccurences
    {
        public static void Main()
        {
            List<double> values = new List<double>()
            {
                3, 4, 4, -2.5, 3, 3, 4, 3, -2.5
            };

            Dictionary<double, int> occurences = new Dictionary<double, int>();

            foreach (var value in values)
            {
                if (!occurences.ContainsKey(value))
                {
                    occurences[value] = 0;
                }

                occurences[value]++;
            }

            foreach (var pair in occurences)
            {
                Console.WriteLine("{0} occurs {1} times", pair.Key, pair.Value);
            }
        }
    }
}
