namespace ComputerBuilderClasses.Contracts
{
    public interface ILaptopBattery
    {
        int Percentage { get; }

        void Charge(int chargeAmmount);
    }
}