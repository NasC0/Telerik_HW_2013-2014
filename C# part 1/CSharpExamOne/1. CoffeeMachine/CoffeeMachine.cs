using System;

class CoffeeMachine
{
    static void Main()
    {
        int fives, tens, twenties, fifties, ones;
        int.TryParse(Console.ReadLine(), out fives);
        int.TryParse(Console.ReadLine(), out tens);
        int.TryParse(Console.ReadLine(), out twenties);
        int.TryParse(Console.ReadLine(), out fifties);
        int.TryParse(Console.ReadLine(), out ones);
        decimal machineTotalSum = (decimal)(fives * 0.05) + (decimal)(tens * 0.10) + (decimal)(twenties * 0.20) + (decimal)(fifties * 0.50) + ones;
        decimal devMoney, drinkPrice;
        decimal.TryParse(Console.ReadLine(), out devMoney);
        decimal.TryParse(Console.ReadLine(), out drinkPrice);

        if (devMoney >= drinkPrice && machineTotalSum >= devMoney - drinkPrice)
        {
            decimal leftOver = machineTotalSum - (devMoney - drinkPrice);
            Console.WriteLine("Yes {0:F2}", leftOver);
        }
        else if (drinkPrice > devMoney)
        {
            decimal leftOver = drinkPrice - devMoney;
            Console.WriteLine("More {0:F2}", leftOver);
        }
        else if (machineTotalSum < (devMoney - drinkPrice))
        {
            decimal neededMoney = (devMoney - drinkPrice) - machineTotalSum;
            Console.WriteLine("No {0:F2}", neededMoney);
        }
    }
}
