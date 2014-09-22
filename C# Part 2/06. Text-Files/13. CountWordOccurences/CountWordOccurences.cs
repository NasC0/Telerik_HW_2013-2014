/* 13. Write a program that reads a list of words from a file words.txt and finds how many times each of the words is contained in another file test.txt. 
 * The result should be written in the file result.txt and the words should be sorted by the number of their occurrences in descending order. 
 * Handle all possible exceptions in your methods. */

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;

class CountWordOccurences
{
    static void Main()
    {
        try
        {
            StreamReader firstReader = new StreamReader("../../word_list.txt");

            // Initialize a list which holds the specified words we have to count for
            List<string> wordsList = new List<string>();

            using (firstReader)
            {
                string line = firstReader.ReadLine();
                while (line != null)
                {
                    wordsList.Add(line);
                    line = firstReader.ReadLine();
                }
            }

            // Initialize a dictionary which holds every word found and the number of it's occurences.
            // Easily sortable
            Dictionary<string, int> wordsCount = new Dictionary<string, int>();

            // Read the whole text in a string
            string fullText = "";

            StreamReader secondReader = new StreamReader("../../input.txt");

            using (secondReader)
            {
                fullText = secondReader.ReadToEnd();
            }

            // Iterate over every word in the word list
            // Count matches by making a MatchCollection for every word in the list and then get its count
            foreach (string word in wordsList)
            {
                string pattern = String.Format(@"\b{0}\b", word);

                MatchCollection matches = Regex.Matches(fullText, pattern, RegexOptions.IgnoreCase);

                wordsCount.Add(word, matches.Count);
            }

            // Sort the dictionary using LINQ
            var sortedDictionary = from entry in wordsCount
                                   orderby entry.Value descending
                                   select entry;

            StreamWriter sw = new StreamWriter("../../result.txt");

            // Write each dictionary entry to the result file
            using (sw)
            {
                foreach (var entry in sortedDictionary)
                {
                    sw.WriteLine(String.Format("{0}: {1}", entry.Key, entry.Value));
                }
            }
        }
        catch (FileLoadException ex)
        {
            Console.WriteLine("Could not load file: {0}", ex.Message);
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine("File does not exist: {0}", ex.Message);
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine("Caught null exception: {0}", ex.Message);
        }
    }
}
