using System;

class Cat
{
    public string Name { get; private set; }

    public Cat(string name)
    {
        this.Name = name;
    }

    public void ChangeName(string newName)
    {
        this.Name = newName;
    }
}

class Test
{
    static void MessWithCat(Cat currentCat)
    {
        currentCat = new Cat("Han");
    }

    static void ChangeName(Cat currentCat)
    {
        currentCat.ChangeName("Blabla");
    }


    static void Main()
    {
        Cat firstCat = new Cat("Jabba");
        Cat secondCat = new Cat("Leia");
        Console.WriteLine(firstCat.Name);
        Console.WriteLine(secondCat.Name);
        MessWithCat(firstCat);
        ChangeName(secondCat);
        Console.WriteLine(firstCat.Name);
        Console.WriteLine(secondCat.Name);
    }
}
