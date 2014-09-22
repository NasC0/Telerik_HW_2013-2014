namespace ComputerBuilderClasses.Contracts
{
    public interface ISystem
    {
        IMotherboard Motherboard { get; }

        ICentralProcessingUnit Cpu { get; }

        IDiskDrive Hdd { get; }
    }
}