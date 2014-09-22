namespace ComputerBuilderClasses.Contracts
{
    public interface IDiskDrive
    {
        int Capacity { get; }

        void SaveData(int memmoryAddress, string textData);

        string LoadData(int memmoryAddress);
    }
}