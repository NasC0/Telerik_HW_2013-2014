using System;
using System.Collections.Generic;

namespace TraverseHardDrive
{
    public class Folder
    {
        private string name;
        private string path;
        private List<File> files;
        private List<Folder> childFolders;

        public Folder(string path)
        {
            this.Path = path;
            this.Name = System.IO.Path.GetFileName(this.Path);
            this.files = new List<File>();
            this.childFolders = new List<Folder>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Folder name cannot be null.");
                }

                this.name = value;
            }
        }

        public string Path
        {
            get
            {
                return this.path;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Folder path cannot be null.");
                }

                this.path = value;
            }
        }

        public List<File> Files
        {
            get
            {
                return new List<File>(this.files);
            }
        }

        public List<Folder> ChildFolders
        {
            get
            {
                return new List<Folder>(this.childFolders);
            }
        }

        public void AddFile(File file)
        {
            this.files.Add(file);
        }

        public void AddFolder(Folder folder)
        {
            this.childFolders.Add(folder);
        }
    }
}
