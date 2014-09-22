/* 03. Write a program that reads a text file and inserts line numbers in front of each of its lines. The result should be written to another text file. */

using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        StreamReader sr = new StreamReader("../../input.txt");
        using (sr)
        {
            StreamWriter sw = new StreamWriter("../../result.txt");
            using (sw)
            {
                int lineCount = 1;

                string line = sr.ReadLine();

                while (line != null)
                {
                    sw.WriteLine(String.Format("{0}. {1}", lineCount, line));
                    lineCount++;
                    line = sr.ReadLine();
                }
            }
        }

        Console.WriteLine("Writing input done!");
    }
}
