namespace BankModel
{
    
    public abstract class Customer
    {
        public Customer(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }
    }
}
