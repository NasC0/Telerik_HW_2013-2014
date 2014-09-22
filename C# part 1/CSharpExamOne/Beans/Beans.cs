using System;

class Beans
{
    static void Main()
    {
        decimal tomatoes, cucumbers, potatoes, carrots, cabbage, beans;
        int tomatoesArea, cucumbersArea, potatoesArea, carrotsArea, cabbageArea;
        decimal.TryParse(Console.ReadLine(), out tomatoes);
        int.TryParse(Console.ReadLine(), out tomatoesArea);
        decimal.TryParse(Console.ReadLine(), out cucumbers);
        int.TryParse(Console.ReadLine(), out cucumbersArea);
        decimal.TryParse(Console.ReadLine(), out potatoes);
        int.TryParse(Console.ReadLine(), out potatoesArea);
        decimal.TryParse(Console.ReadLine(), out carrots);
        int.TryParse(Console.ReadLine(), out carrotsArea);
        decimal.TryParse(Console.ReadLine(), out cabbage);
        int.TryParse(Console.ReadLine(), out cabbageArea);
        decimal.TryParse(Console.ReadLine(), out beans);

        decimal totalPrice = (tomatoes * 0.5m) + (cucumbers * 0.4m) + (potatoes * 0.25m) + (carrots * 0.6m) + (cabbage * 0.3m) + (beans * 0.4m);
        int remainingArea = 250 - (tomatoesArea + cucumbersArea + carrotsArea + cabbageArea + potatoesArea);

        if (remainingArea > 0)
        {
            Console.WriteLine("Total cost: {0:F2}", totalPrice);
            Console.WriteLine("Beans area: {0}", remainingArea);
        }
        else if (remainingArea == 0)
        {
            Console.WriteLine("Total cost: {0:F2}", totalPrice);
            Console.WriteLine("No area for beans");
        }
        else
        {
            Console.WriteLine("Total cost: {0:F2}", totalPrice);
            Console.WriteLine("Insufficient area");
        }
    }
}
