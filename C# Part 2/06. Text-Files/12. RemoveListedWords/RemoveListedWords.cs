/* 12. Write a program that removes from a text file all words listed in given another text file. 
 * Handle all possible exceptions in your methods. */

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

class RemoveListedWords
{
    static void Main()
    {
        try
        {
            StreamReader firstReader = new StreamReader("../../words_list.txt");
            List<string> wordsToRemove = new List<string>();

            using (firstReader)
            {
                string line = firstReader.ReadLine();

                while (line != null)
                {
                    wordsToRemove.Add(line);
                    line = firstReader.ReadLine();
                }
            }

            string fullText = "";

            StreamReader secondReader = new StreamReader("../../input.txt");

            using (secondReader)
            {
                fullText = secondReader.ReadToEnd();
            }

            foreach (string word in wordsToRemove)
            {
                fullText = Regex.Replace(fullText, word, "", RegexOptions.IgnoreCase);
            }

            // Replaces left-over whitespaces
            fullText = Regex.Replace(fullText, @"\s{2,}", "");

            StreamWriter sw = new StreamWriter("../../input.txt");

            using (sw)
            {
                sw.Write(fullText);
            }

        }
        catch (FileLoadException ex)
        {
            Console.WriteLine("Could not load file: {0}", ex.Message);
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine("Could not find file: {0}", ex.Message);
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine("Caught null exception: {0}", ex.Message);
        }
    }
}
