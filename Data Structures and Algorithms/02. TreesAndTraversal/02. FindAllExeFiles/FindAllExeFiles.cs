/* 02. Write a program to traverse the directory C:\WINDOWS and all its subdirectories recursively 
 * and to display all files matching the mask *.exe. Use the class System.IO.Directory. */

using System;
using System.Collections.Generic;
using System.IO;

class FindAllExeFiles
{
    static void Main()
    {

        string originalPath = "C:\\Windows";
        List<string> allExeFiles = new List<string>();

        Stack<string> allSubDirectories = new Stack<string>();
        allSubDirectories.Push(originalPath);


        while (allSubDirectories.Count > 0)
        {
            var currentDir = allSubDirectories.Pop();
            IEnumerable<string> subDirectories = new List<string>();

            try
            {
                allExeFiles.AddRange(Directory.EnumerateFiles(currentDir, "*.exe", SearchOption.TopDirectoryOnly));
                subDirectories = Directory.EnumerateDirectories(currentDir);
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine(ex.Message);
            }

            foreach (var dir in subDirectories)
            {
                allSubDirectories.Push(dir);
            }
        }
    }
}
