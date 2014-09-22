using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Diagnostics;

class test
{
    static char[] splitConditions = { ',', '.', '?', '!', ' ', ';', '(', ')', '"', '\'', '-', '\0', '\b', '\t', '\n', '\v', '\r' };

    static void Main(string[] args)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        List<string> allWords = new List<string>();
        string fullText = "";

        StreamReader sr = new StreamReader("../../input.txt");

        using (sr)
        {
            fullText = sr.ReadToEnd();
        }

        stopwatch.Stop();
        Console.WriteLine("Initial text fill: {0}", stopwatch.Elapsed);

        stopwatch.Reset();
        stopwatch.Start();

        string[] textSplit = Regex.Split(fullText, @"\W", RegexOptions.IgnoreCase);

        stopwatch.Stop();
        Console.WriteLine("Regex split: {0}", stopwatch.Elapsed);

        stopwatch.Reset();
        stopwatch.Start();

        foreach (string word in textSplit)
        {
            if (!allWords.Contains(word.ToLower()))
            {
                allWords.Add(word.ToLower());
            }
        }

        stopwatch.Stop();
        Console.WriteLine("Eliminate doubling words: {0}", stopwatch.Elapsed);

        stopwatch.Reset();
        stopwatch.Start();


        Dictionary<string, int> wordOccurences = new Dictionary<string, int>();

        foreach (string word in allWords)
        {
            string pattern = String.Format(@"\b{0}\b", word);

            MatchCollection matches = Regex.Matches(fullText, pattern, RegexOptions.IgnoreCase);

            wordOccurences.Add(word, matches.Count);
        }

        stopwatch.Stop();
        Console.WriteLine("Count word occurences: {0}", stopwatch.Elapsed);

        stopwatch.Reset();
        stopwatch.Start();

        var sortedDictionary = from entry in wordOccurences
                               orderby entry.Value descending
                               select entry;

        stopwatch.Stop();
        Console.WriteLine("Sorting word occurences: {0}", stopwatch.Elapsed);

        stopwatch.Reset();
        stopwatch.Start();

        StreamWriter sw = new StreamWriter("../../result.txt");

        using (sw)
        {
            foreach (var entry in sortedDictionary)
            {
                sw.WriteLine(String.Format("{0}: {1}", entry.Key, entry.Value));
            }
        }
        stopwatch.Stop();
        Console.WriteLine("Writing results to file: {0}", stopwatch.Elapsed);
    }
}
