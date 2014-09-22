/* 03. Cats are Animals. */

namespace AnimalClasses
{
    public class Cat : Animal, ISound
    {
        public Cat(string catName, int catAge, Gender catSex)
            : base(catName, catAge, catSex)
        {
        }

        public override void MakeSound()
        {
            System.Console.WriteLine("Meow :)");
        }
    }
}
