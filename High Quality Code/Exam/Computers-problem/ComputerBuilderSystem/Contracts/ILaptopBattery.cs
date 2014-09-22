namespace ComputerBuilderSystem.Contracts
{
    public interface ILaptopBattery
    {
        void Charge(int chargeAmmount);

        int Percentage { get; }
    }
}