using ComputerBuilderSystem.Contracts;
namespace ComputerBuilderSystem
{
    public class RandomAccessMemmory : IRandomAccessMemmory
    {
        private int value;

        internal RandomAccessMemmory(int ammount)
        {
            this.Amount = ammount;
        }

        public int Amount { get; set; }

        public void SaveValue(int newValue)
        {
            this.value = newValue;
        }

        public int LoadValue()
        {
            return this.value;
        }
    }
}