/* 03. Create a hierarchy Dog, Frog, Cat, Kitten, Tomcat and define useful constructors and methods. 
 * Dogs, frogs and cats are Animals. All animals can produce sound (specified by the ISound interface). 
 * Kittens and tomcats are cats. All animals are described by age, name and sex. 
 * Kittens can be only female and tomcats can be only male. Each animal produces a specific sound. 
 * Create arrays of different kinds of animals and calculate the average age of 
 * each kind of animal using a static method (you may use LINQ). */

namespace _03.AnimalClassesTest
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AnimalClasses;

    public class AnimalClassesTest
    {
        public static void Main()
        {
            Kitten kat = new Kitten("Sunny", 9);
            Console.WriteLine(kat);

            Tomcat grumpyCat = new Tomcat("Grumpy Cat", 5);
            Console.WriteLine(grumpyCat);

            kat.MakeSound();

            List<Dog> dogList = new List<Dog>()
            {
                new Dog("Rex", 6, Gender.Male),
                new Dog("Roxana", 4, Gender.Female),
                new Dog("Doge", 7, Gender.Male)
            };

            Console.WriteLine("\nAverage dog age: {0}\n", (int)dogList.Average(x => x.Age));

            List<Frog> forgList = new List<Frog>()
            {
                new Frog("Joro", 3, Gender.Female),
                new Frog("Queen Victoria", 2, Gender.Male),
                new Frog("Badass", 5, Gender.Male)
            };

            Console.WriteLine("Average frog age: {0}\n", (int)forgList.Average(x => x.Age));

            List<Cat> catList = new List<Cat>()
            {
                new Cat("Felicity", 11, Gender.Female),
                new Cat("Gesha", 4, Gender.Male),
                new Cat("Lorenzo", 2, Gender.Male)
            };

            Console.WriteLine("Average cat age: {0}\n", (int)catList.Average(x => x.Age));

            List<Kitten> kittenList = new List<Kitten>()
            {
                new Kitten("Shmatio", 6),
                new Kitten("Kitten", 2),
                kat
            };

            Console.WriteLine("Average kitten age: {0}\n", (int)kittenList.Average(x => x.Age));

            List<Tomcat> tomcatList = new List<Tomcat>()
            {
                new Tomcat("Gribbo", 13),
                new Tomcat("Batalen", 7),
                grumpyCat
            };

            Console.WriteLine("Average tomcat age: {0}\n", (int)tomcatList.Average(x => x.Age));
        }
    }
}
