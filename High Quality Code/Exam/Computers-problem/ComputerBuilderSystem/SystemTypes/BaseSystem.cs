using System;
using ComputerBuilderSystem.Contracts;

namespace ComputerBuilderSystem.SystemTypes
{
    public class BaseSystem : ISystem
    {
        private IMotherboard motherboard;

        private ICentralProcessingUnit cpu;

        private IDiskDrive hdd;

        public BaseSystem(IMotherboard motherboard, ICentralProcessingUnit cpu,
                IDiskDrive diskDrive)
        {
            this.Motherboard = motherboard;
            this.Cpu = cpu;
            this.Hdd = diskDrive;
        }

        public IMotherboard Motherboard
        {
            get
            {
                return this.motherboard;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("System motherboard must be initialized.");
                }

                this.motherboard = value;
            }
        }

        public ICentralProcessingUnit Cpu
        {
            get
            {
                return this.cpu;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("System CPU must be initialized.");
                }

                this.cpu = value;
            }
        }

        public IDiskDrive Hdd
        {
            get
            {
                return this.hdd;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("System disk drive must be initialized.");
                }

                this.hdd = value;
            }
        }
    }
}