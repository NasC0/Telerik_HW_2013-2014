/* Frogs are Animals */

namespace AnimalClasses
{
    public class Frog : Animal, ISound
    {
        public Frog(string frogName, int frogAge, Gender frogSex)
            : base(frogName, frogAge, frogSex)
        {
        }

        public override void MakeSound()
        {
            System.Console.WriteLine("Wibbit...");
        }
    }
}
