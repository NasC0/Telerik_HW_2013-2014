/* 03. Kittens are cats. Kittens can be only female. */

namespace AnimalClasses
{
    public class Kitten : Cat, ISound
    {
        public Kitten(string kittenName, int kittenAge)
            : base(kittenName, kittenAge, Gender.Female)
        {
        }
    }
}
