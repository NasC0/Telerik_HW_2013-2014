using System;

namespace TraverseHardDrive
{
    public class File
    {
        private string name;
        private string path;

        public File(string fullPath, long size)
        {
            this.path = fullPath;
            this.Size = size;
            this.Name = System.IO.Path.GetFileName(this.Path);
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
                    throw new ArgumentNullException("File name cannot be null.");
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
                    throw new ArgumentNullException("File path cannot be null.");
                }

                this.path = value;
            }
        }

        public long Size { get; private set; }
    }
}
