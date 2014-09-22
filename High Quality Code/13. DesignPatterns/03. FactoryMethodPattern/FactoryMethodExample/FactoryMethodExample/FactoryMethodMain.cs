using System;

namespace FactoryMethodExample
{
    public class FactoryMethodMain
    {
        static void Main()
        {
            var sedanFactory = new SedanFactory();
            var suvFactory = new SUVFactory();

            Car sedanCar = sedanFactory.MakeCar();
            Car suvCar = suvFactory.MakeCar();

            Console.WriteLine(sedanCar.Type);
            Console.WriteLine(suvCar.Type);
        }
    }
}
