namespace ComputerBuilderSystem.Contracts
{
    public interface ICentralProcessingUnit
    {
        int BitSize { get; }

        byte NumberOfCores { get; }

        int SquareNumber(int data);
        
        int Rand(int minValue, int maxValue);
    }
}