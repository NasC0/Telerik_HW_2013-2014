namespace _10.HardSequenceOperaions
{
    public class Operation
    {
        public Operation(int value, Operation previousOperation = null)
        {
            this.Value = value;
            this.PreviousOperation = previousOperation;
        }

        public int Value { get; private set; }

        public Operation PreviousOperation { get; set; }
    }
}
