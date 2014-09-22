using System.Collections.Generic;

namespace CountStringOccurences
{
    public class CountStringOccurences
    {
        public static void Main()
        {
            List<string> strings = new List<string>()
            {
                "C#", "SQL", "PHP", "PHP", "SQL", "SQL"
            };

            Dictionary<string, int> stringOccurences = new Dictionary<string, int>();

            foreach (var value in strings)
            {
                if (!stringOccurences.ContainsKey(value))
                {
                    stringOccurences[value] = 0;
                }

                stringOccurences[value]++;
            }

            List<string> oddOccurences = new List<string>();

            foreach (var pair in stringOccurences)
            {
                if (pair.Value % 2 != 0)
                {
                    oddOccurences.Add(pair.Key);
                }
            }

            foreach (var occurence in oddOccurences)
            {
                System.Console.WriteLine(occurence);
            }
        }
    }
}
