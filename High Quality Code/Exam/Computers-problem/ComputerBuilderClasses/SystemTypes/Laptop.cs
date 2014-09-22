using System;
using ComputerBuilderClasses.Contracts;

namespace ComputerBuilderClasses.SystemTypes
{
    public class Laptop : BaseSystem, ILaptopSystem
    {
        private ILaptopBattery battery;

        public Laptop(ILaptopBattery battery, IMotherboard motherboard, ICentralProcessingUnit cpu, IDiskDrive diskDrive)
            : base(motherboard, cpu, diskDrive)
        {
            this.Battery = battery;
        }

        public ILaptopBattery Battery
        {
            get
            {
                return this.battery;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Laptop battery must be initialized.");
                }

                this.battery = value;
            }
        }

        public void ChargeBattery(int chargeSize)
        {
            this.Battery.Charge(chargeSize);

            this.Motherboard.DrawOnVideoCard(string.Format("Battery status: {0}", this.Battery.Percentage));
        }
    }
}
