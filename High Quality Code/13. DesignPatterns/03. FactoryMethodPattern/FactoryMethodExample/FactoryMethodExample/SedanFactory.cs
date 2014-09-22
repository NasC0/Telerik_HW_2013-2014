
namespace FactoryMethodExample
{
    public class SedanFactory : CarFactory
    {
        public override Car MakeCar()
        {
            return new SedanCar();
        }
    }
}
