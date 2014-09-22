/* 03. Tomcats are cats. Tomcats can only be male. */

namespace AnimalClasses
{
    public class Tomcat : Cat, ISound
    {
        public Tomcat(string name, int age)
            : base(name, age, Gender.Male)
        {
        }
    }
}
