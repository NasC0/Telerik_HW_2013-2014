namespace _04.PersonClass
{
    class PersonTest
    {
        static void Main()
        {
            Person person = new Person("Gary");
            System.Console.WriteLine(person);

            System.Console.WriteLine();

            person.Age = 21;

            System.Console.WriteLine(person);
        }
    }
}
