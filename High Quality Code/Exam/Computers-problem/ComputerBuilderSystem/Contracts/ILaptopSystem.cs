namespace ComputerBuilderSystem.Contracts
{
    public interface ILaptopSystem : ISystem
    {
        ILaptopBattery Battery { get; }

        void ChargeBattery(int chargeSize);
    }
}