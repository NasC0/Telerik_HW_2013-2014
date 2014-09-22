using System;

namespace HardDriveMapping
{
    public class File
    {
        private string name;

        public File(string name, long fileSize)
        {
            this.Name = name;
            this.FileSize = fileSize;
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
                    throw new ArgumentNullException("File name cannot be null or empty.");
                }

                this.name = value;
            }
        }

        public long FileSize { get; private set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
