using ComputerBuilderSystem.Contracts;
namespace ComputerBuilderSystem
{
    class LaptopBattery : ILaptopBattery
    {
        private const int InitialCharge = 50;

        private int percentage;

        public LaptopBattery()
        {
            this.Percentage = InitialCharge;
        }

        public int Percentage
        {
            get
            {
                return this.percentage;
            }

            private set
            {
                this.percentage = value;

                if (this.percentage > 100)
                {
                    this.percentage = 100;
                }
                else if (this.percentage < 0)
                {
                    this.percentage = 0;
                }
            }
        }

        public void Charge(int charge)
        {
            this.Percentage += charge;
        }
    }
}