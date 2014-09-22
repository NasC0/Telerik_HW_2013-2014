// 01. Disciplines have name, number of lectures and number of exercises.

namespace SchoolClasses
{
    public class Discipline : NamedWorldObject
    {
        public Discipline(string name, int lectures, int exercises)
            : base(name)
        {
            this.NumberOfLectures = lectures;
            this.NumberOfExercises = exercises;
        }

        public int NumberOfLectures { get; private set; }

        public int NumberOfExercises { get; private set; }

        public override string ToString()
        {
            return string.Format("Name: {0}, Lectures: {1}, Exercises: {2}", this.Name, this.NumberOfLectures, this.NumberOfExercises);
        }
    }
}
