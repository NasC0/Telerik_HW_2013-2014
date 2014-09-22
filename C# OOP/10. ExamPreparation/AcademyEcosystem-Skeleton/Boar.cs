using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyEcosystem
{
    public class Boar : Animal, ICarnivore, IHerbivore
    {
        private const int BoarSize = 4;
        private const int BoarBiteSize = 2;


        private readonly int biteSize;

        public Boar(string name, Point position)
            :base(name, position, BoarSize)
        {
            this.biteSize = BoarBiteSize;
        }

        public override void Update(int timeElapsed)
        {
            if (timeElapsed >= this.sleepRemaining)
            {
                this.Awake();
            }
            else
            {
                this.sleepRemaining -= timeElapsed;
            }

            base.Update(timeElapsed);
        }

        public int TryEatAnimal(Animal animal)
        {
            if (animal != null)
            {
                if (animal.Size <= this.Size)
                {
                    return animal.GetMeatFromKillQuantity();
                }
            }

            return 0;
        }

        public int EatPlant(Plant plant)
        {
            if (plant != null)
            {
                this.Size++;
                return plant.GetEatenQuantity(this.biteSize);
            }

            return 0;
        }
    }
}
