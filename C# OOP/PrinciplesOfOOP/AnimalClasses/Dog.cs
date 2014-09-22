/* 03. Dogs are Animals */

namespace AnimalClasses
{
    public class Dog : Animal, ISound
    {
        public Dog(string dogName, int dogAge, Gender dogSex)
            : base(dogName, dogAge, dogSex)
        {
        }

        public override void MakeSound()
        {
            System.Console.WriteLine("Woof!");
        }
    }
}
