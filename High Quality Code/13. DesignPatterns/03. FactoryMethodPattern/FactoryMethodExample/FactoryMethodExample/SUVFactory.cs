
namespace FactoryMethodExample
{
    public class SUVFactory : CarFactory
    {
        public override Car MakeCar()
        {
            return new SUVCar();
        }
    }
}
