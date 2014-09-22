// 01. Each teacher teaches a set of disciplines and a name. Both teachers and students are people.

namespace SchoolClasses
{
    using System;
    using System.Collections.Generic;

    public class Teacher : People
    {
        public Teacher(string name)
            : base(name)
        {
            this.DisciplinesTaught = new List<Discipline>();
        }

        public Teacher(string name, List<Discipline> discipline)
            : base(name)
        {
            this.DisciplinesTaught = discipline;
        }

        public List<Discipline> DisciplinesTaught { get; private set; }

        public void AddDiscipline(Discipline toAdd)
        {
            this.DisciplinesTaught.Add(toAdd);
        }
    }
}
