namespace ComputerBuilderClasses.Contracts
{
    public interface IManufacturer
    {
        IPcSystem BuildPc();

        ILaptopSystem BuildLaptop();

        IServerSystem BuildServer();
    }
}