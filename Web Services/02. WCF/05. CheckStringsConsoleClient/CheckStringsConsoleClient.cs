using System;

namespace CheckStringsConsoleClient
{
    public class CheckStringsConsoleClient
    {
        private const string Substring = "test";
        private const string FullText = "test test test test test";

        public static void Main()
        {
            var serviceClient = new CheckStringsClient();
            int stringCount = serviceClient.GetContainingCount(Substring, FullText);
            Console.WriteLine(stringCount);
        }
    }
}
