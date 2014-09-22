
namespace FactoryMethodExample
{
    public class SUVCar : Car
    {
        public override CarType Type
        {
            get 
            {
                return CarType.SUV;
            }
        }
    }
}
