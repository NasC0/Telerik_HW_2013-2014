using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CountStringOccurenceFromText
{
    public class CountStringOccurenceFromText
    {
        public const string TextLocation = "..\\..\\input.txt";

        public static readonly char[] TextSeparators = new char[]
        {
            ' ', '.', ',', '!', ';', '?', '\"', '–'
        };

        public static void Main()
        {
            string fullText;
            using (StreamReader textReader = new StreamReader(TextLocation))
            {
                fullText = textReader.ReadToEnd();
            }

            var splitText = fullText.Split(TextSeparators, StringSplitOptions.RemoveEmptyEntries);
            var wordDictionary = new Dictionary<string, int>();

            foreach (var word in splitText)
            {
                string currentWord = word.ToLower();

                if (!wordDictionary.ContainsKey(currentWord))
                {
                    wordDictionary[currentWord] = 0;
                }

                wordDictionary[currentWord]++;
            }

            var sortedWordOccurences = wordDictionary.OrderBy(p => p.Value);

            foreach (var pair in sortedWordOccurences)
            {
                Console.WriteLine("{0} occurs {1} times", pair.Key, pair.Value);
            }
        }
    }
}
