/* 03. All animals can produce sound (specified by the ISound interface). 
 * All animals are described by age, name and sex. */

namespace AnimalClasses
{
    public abstract class Animal : ISound
    {
        public Animal(string animalName, int animalAge, Gender animalSex)
        {
            this.Name = animalName;
            this.Age = animalAge;
            this.Sex = animalSex;
        }

        public int Age { get; protected set; }

        public Gender Sex { get; protected set; }

        public string Name { get; protected set; }

        public abstract void MakeSound();

        public override string ToString()
        {
            return string.Format("{0} - Age {1}, Gender: {2}", this.Name, this.Age, this.Sex);
        }
    }
}
