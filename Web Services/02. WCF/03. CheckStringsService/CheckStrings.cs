using System;

namespace CheckStringsService
{
    public class CheckStrings : ICheckStrings
    {
        public int GetContainingCount(string substring, string fulltext)
        {
            if (string.IsNullOrWhiteSpace(substring) || string.IsNullOrWhiteSpace(fulltext))
            {
                throw new ArgumentNullException();    
            }

            int occurences = 0;
            while (true)
            {
                int currentIndex = fulltext.IndexOf(substring);
                if (currentIndex != -1)
                {
                    occurences++;
                    fulltext = fulltext.Substring(currentIndex + (substring.Length - 1));
                }
                else
                {
                    break;
                }
            }

            return occurences;
        }
    }
}
