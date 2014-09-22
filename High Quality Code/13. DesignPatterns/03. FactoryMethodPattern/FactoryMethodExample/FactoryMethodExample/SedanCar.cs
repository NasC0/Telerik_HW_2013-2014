
namespace FactoryMethodExample
{
    public class SedanCar : Car
    {
        public override CarType Type
        {
            get
            {
                return CarType.Sedan;
            }
        }
    }
}
