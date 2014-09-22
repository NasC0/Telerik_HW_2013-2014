using System;
using ComputerBuilderClasses.Contracts;

namespace ComputerBuilderClasses.SystemComponents
{
    public class Motherboard : IMotherboard
    {
        private IRandomAccessMemmory ram;
        private IVideoCard videoCard;

        public Motherboard(IRandomAccessMemmory ram, IVideoCard videoCard)
        {
            this.Ram = ram;
            this.VideoCard = videoCard;
        }

        private IRandomAccessMemmory Ram
        {
            get
            {
                return this.ram;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Ram module must be initialized.");
                }

                this.ram = value;
            }
        }

        private IVideoCard VideoCard
        {
            get
            {
                return this.videoCard;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Video Card module must be initialized.");
                }

                this.videoCard = value;
            }
        }

        public int LoadRamValue()
        {
            return this.Ram.LoadValue();
        }

        public void SaveRamValue(int value)
        {
            this.Ram.SaveValue(value);
        }

        public void DrawOnVideoCard(string data)
        {
            this.VideoCard.Draw(data);
        }
    }
}
