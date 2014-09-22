using System;
using System.Collections.Generic;
using System.IO;

namespace TraverseHardDrive
{
    public class TraverseHardDrive
    {
        public static List<Folder> Traverse()
        {
            List<string> hardDrives = GetDrives();
            List<Folder> traversedHardDrives = new List<Folder>();

            foreach (var drive in hardDrives)
            {
                Folder currentHardDrive = new Folder(drive);
                traversedHardDrives.Add(currentHardDrive);

                Stack<Folder> dfsStack = new Stack<Folder>();
                dfsStack.Push(currentHardDrive);
                
                while (dfsStack.Count > 0)
                {
                    try
                    {
                        Folder currentFolder = dfsStack.Pop();
                        string folderPath = currentFolder.Path;
                        string[] filesInFolder = Directory.GetFiles(folderPath, "*", SearchOption.TopDirectoryOnly);

                        foreach (var file in filesInFolder)
                        {
                            FileInfo currentFileInfo = new FileInfo(file);
                            File currentFile = new File(file, currentFileInfo.Length);
                            currentFolder.AddFile(currentFile);
                        }

                        string[] foldersInFolder = Directory.GetDirectories(folderPath, "*", SearchOption.TopDirectoryOnly);
                        foreach (var folder in foldersInFolder)
                        {
                            Folder currentChildFolder = new Folder(folder);
                            currentFolder.AddFolder(currentChildFolder);
                            dfsStack.Push(currentChildFolder);
                        }
                    }
                    catch (UnauthorizedAccessException)
                    {
                        
                    }
                    catch (PathTooLongException)
                    {
                        
                    }
                }
            }

            return traversedHardDrives;
        }

        public static List<string> GetDrives()
        {
            List<string> hardDrives = new List<string>();
            var allHardDrives = DriveInfo.GetDrives();
            foreach (var drive in allHardDrives)
            {
                if (drive.DriveType == DriveType.Fixed)
                {
                    hardDrives.Add(drive.Name);
                }
            }

            return hardDrives;
        }

        public static long GetFolderSize(Folder folder)
        {
            long wholeFolderSize = 0;

            Queue<Folder> bfsQueue = new Queue<Folder>();
            bfsQueue.Enqueue(folder);

            while (bfsQueue.Count > 0)
            {
                Folder currentFolder = bfsQueue.Dequeue();
                foreach (var file in currentFolder.Files)
                {
                    wholeFolderSize += file.Size;
                }

                foreach (var childFolder in currentFolder.ChildFolders)
                {
                    bfsQueue.Enqueue(childFolder);
                }
            }

            return wholeFolderSize;
        }

        public static double GetFolderSizeInMB(long size)
        {
            return size / (1024 * 1024);
        }

        public static double GetFolderSizeInGB(long size)
        {
            return size / (1024 * 1024 * 1024);
        }

        public static void Main()
        {
            var folders = Traverse();
            foreach (var drive in folders)
            {
                long folderSize = GetFolderSize(drive);
                double sizeInMB = GetFolderSizeInMB(folderSize);
                double sizeInGB = GetFolderSizeInGB(folderSize);
                Console.WriteLine("{0} size in MB: {1}", drive.Path, sizeInMB);
                Console.WriteLine("{0} size in GB: {1}", drive.Path, sizeInGB);
                Console.WriteLine();
            }
        }
    }
}
