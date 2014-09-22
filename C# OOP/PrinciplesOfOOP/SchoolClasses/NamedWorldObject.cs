// Adds Name property to all Student, Teacher and Discipline classes

namespace SchoolClasses
{
    public class NamedWorldObject : WorldObject
    {
        public NamedWorldObject(string name)
        {
            this.Name = name;
        }

        public string Name { get; protected set; }
    }
}
