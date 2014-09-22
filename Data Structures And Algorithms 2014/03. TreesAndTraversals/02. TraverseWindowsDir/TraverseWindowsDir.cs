using System;
using System.Collections.Generic;
using System.IO;

namespace TraverseWindowsDir
{
    public class TraverseWindowsDir
    {
        public static List<string> TraverseWindows()
        {
            string windowsDirPath = Environment.GetEnvironmentVariable("SystemRoot");
            var windowsDirectory = new DirectoryInfo(windowsDirPath);

            List<string> directories = new List<string>();
            List<string> files = new List<string>();
            Stack<string> dfsStack = new Stack<string>();
            dfsStack.Push(windowsDirectory.FullName);

            while (dfsStack.Count > 0)
            {
                try
                {
                    string currentDirectory = dfsStack.Pop();
                    string[] executableFiles = Directory.GetFiles(currentDirectory, "*.exe", SearchOption.TopDirectoryOnly);
                    files.AddRange(executableFiles);

                    string[] childDirectories = Directory.GetDirectories(currentDirectory, "*", SearchOption.TopDirectoryOnly);
                    foreach (var directoryPath in childDirectories)
                    {
                        dfsStack.Push(directoryPath);
                    }
                }
                catch (UnauthorizedAccessException ex)
                {

                }
            }

            return files;
        }

        public static void Main()
        {
            var files = TraverseWindows();
            foreach (var file in files)
            {
                Console.WriteLine(file);
            }
        }
    }
}
