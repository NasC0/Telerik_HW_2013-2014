// Trie implementation taken from https://github.com/rmandvikar/csharp-trie
// Don't worry if Trie building takes a bit long. It took 13 seconds to build it from a 131mb file on my machine

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

using rm.Trie;

namespace ProcessTextFile
{
    public class ProcessTextFile
    {
        private const string FileLocation = "..\\..\\test.txt";
        private static readonly char[] Separators = new char[]
        {
            ' ', ',', '.', '!', '?', '-', ';', '"'
        };

        private static readonly string[] SearchWords = new string[]
        {
            "Vestibulum", "magna", "nascetur", "Curabitur", "Nulla", "feugiat", "aptent", "bibendum", "risus", "sem"
        };

        public static ITrie BuildTree()
        {
            var wordTrie = TrieFactory.GetTrie();

            using (StreamReader textReader = new StreamReader(FileLocation))
            {
                string line = textReader.ReadLine();

                while (line != null)
                {
                    var words = line.Split(Separators, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var word in words)
                    {
                        wordTrie.AddWord(word);
                    }

                    line = textReader.ReadLine();
                }
            }

            return wordTrie;
        }

        public static IDictionary<string, int> GetWordOccurences(ITrie wordTrie)
        {
            var wordDictionary = new Dictionary<string, int>();

            foreach (var word in SearchWords)
            {
                int wordCount = wordTrie.WordCount(word);
                wordDictionary.Add(word, wordCount);
            }

            return wordDictionary;
        }

        public static void FindWords(ITrie wordTrie)
        {
            for (int i = 0; i < 100; i++)
            {
                foreach (var word in SearchWords)
                {
                    wordTrie.HasWord(word);
                }
            }
        }

        public static void Main()
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();

            var wordTrie = BuildTree();

            timer.Stop();

            Console.WriteLine("Trie building took: {0}", timer.Elapsed);

            timer.Reset();
            timer.Start();

            FindWords(wordTrie);

            timer.Stop();
            Console.WriteLine("Trie search took: {0}", timer.Elapsed);

            var wordCountDictionary = GetWordOccurences(wordTrie);

            foreach (var pair in wordCountDictionary)
            {
                Console.WriteLine("{0} occurs {1} times.", pair.Key, pair.Value);
            }
        }
    }
}
