using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Diagnostics;

namespace HardDriveMapping
{

    class MapHardDrive
    {
        static Folder TraverseHardDrive(string startingPoint)
        {
            string[] availableFolders = new string[0];

            try
            {
                availableFolders = Directory.GetDirectories(startingPoint);   
            }
            catch (UnauthorizedAccessException)
            {
                
            }

            Folder[] childFolders = new Folder[availableFolders.Length];

            for (int i = 0; i < availableFolders.Length; i++)
            {
                childFolders[i] = TraverseHardDrive(availableFolders[i]);
            }

            File[] files = GetFilesInFolder(startingPoint);

            Folder result = new Folder(startingPoint, childFolders, files);

            return result;
        }

        static File[] GetFilesInFolder(string folderPath)
        {
            string[] availableFiles = new string[0];

            try
            {
                availableFiles = Directory.GetFiles(folderPath);
            }
            catch (UnauthorizedAccessException)
            {

            }

            File[] files = new File[availableFiles.Length];

            for (int i = 0; i < availableFiles.Length; i++)
            {
                try
                {
                    FileInfo currentFile = new FileInfo(availableFiles[i]);
                    files[i] = new File(currentFile.Name, currentFile.Length);
                }
                catch (PathTooLongException)
                {
                    continue;
                }
            }

            return files;
        }

        static long GetCurrentFolderSize(Folder subTreeRoot)
        {
            long subTreeSize = 0;

            foreach (var file in subTreeRoot.Files)
            {
                // This try-catch block was necessary on my machine, since there are some files with names longer than 260 symbols
                try
                {
                    subTreeSize += file.FileSize;
                }
                catch (NullReferenceException)
                {
                    
                }
            }

            return subTreeSize;
        }

        static long SubTreeSize(Folder subTreeRoot)
        {
            long size = GetCurrentFolderSize(subTreeRoot);

            for (int i = 0; i < subTreeRoot.ChildFolders.Length; i++)
            {
                size += SubTreeSize(subTreeRoot.ChildFolders[i]);
            }

            return size;
        }

        static void Main()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Console.WriteLine("Mapping hard drive.");
            Folder root = TraverseHardDrive("E:\\");
            sw.Stop();

            Console.WriteLine(sw.Elapsed);

            Console.WriteLine("Getting file size.");
            Folder subTree = root.GetChildFolderByPath("E:\\");

            if (subTree != null)
            {
                long size = SubTreeSize(subTree);
                double sizeInMBytes = Math.Round((double)size / (1024 * 1024), 2);
                double sizeInGBytes = Math.Round(sizeInMBytes / 1024, 2);

                Console.WriteLine("{0} size {1} Bytes", subTree, size);
                Console.WriteLine("{0} size {1} MegaBytes", subTree, sizeInMBytes);
                Console.WriteLine("{0} size {1} GigaBytes", subTree, sizeInGBytes);
            }
        }
    }
}
