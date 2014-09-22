// Adds comments to all Student, Teacher, Class and Discipline classes

namespace SchoolClasses
{
    using System;

    public class WorldObject
    {
        public WorldObject()
        {
            this.Comment = string.Empty;
        }

        public string Comment { get; set; }
    }
}
