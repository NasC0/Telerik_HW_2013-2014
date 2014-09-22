using System;

public class Chef
{
    private Bowl GetBowl()
    {
        //... 
    }
    private Carrot GetCarrot()
    {
        //...
    }
    private void Cut(Vegetable potato)
    {
        //...
    }
    public void Cook()
    {
        Bowl bowl;
        bowl = GetBowl();

        Potato potato = GetPotato();
        Peel(potato);
        Cut(potato);
        bowl.Add(potato);

        Carrot carrot = GetCarrot();
        Peel(carrot);
        Cut(carrot);
        bowl.Add(carrot);
    }
    private Potato GetPotato()
    {
        //...
    }
}