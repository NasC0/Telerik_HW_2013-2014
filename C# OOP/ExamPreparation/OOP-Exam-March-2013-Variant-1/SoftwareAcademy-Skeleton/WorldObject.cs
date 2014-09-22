using System;

namespace SoftwareAcademy
{
    public abstract class WorldObject
    {
        private string name;

        public WorldObject(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Name value cannot be null!");
                }

                this.name = value;
            }
        }
    }
}
