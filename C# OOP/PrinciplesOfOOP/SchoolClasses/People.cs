// 01. Both teachers and students are people.

namespace SchoolClasses
{
    public class People : NamedWorldObject
    {
        public People(string name)
            : base(name)
        {
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
