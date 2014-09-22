namespace ComputerBuilderClasses.Contracts
{
    public interface IRandomAccessMemmory
    {
        int Amount { get; }

        void SaveValue(int newValue);

        int LoadValue();
    }
}