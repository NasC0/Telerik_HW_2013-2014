using System;
using System.Collections.Generic;
using System.Linq;

namespace HardDriveMapping
{
    public class Folder
    {
        private string name;

        public Folder(string name, Folder[] childFolders, File[] files)
        {
            this.Name = name;
            this.ChildFolders = childFolders;
            this.Files = files;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Folder name cannot be null or empty.");
                }

                this.name = value;
            }
        }

        public Folder[] ChildFolders { get; private set; }

        public File[] Files { get; private set; }

        public Folder GetChildFolderByPath(string folderPath)
        {
            Queue<Folder> bfsQueue = new Queue<Folder>();
            bfsQueue.Enqueue(this);

            while (bfsQueue.Count > 0)
            {
                var currentFolder = bfsQueue.Dequeue();
                if (folderPath == currentFolder.name)
                {
                    return currentFolder;
                }
                else
                {
                    foreach (var folder in currentFolder.ChildFolders)
                    {
                        bfsQueue.Enqueue(folder);
                    }
                }
            }

            return null;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
