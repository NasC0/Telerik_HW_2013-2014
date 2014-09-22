using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyEcosystem
{
    public class Lion : Animal, ICarnivore
    {
        private const int LionSize = 6;

        public Lion(string name, Point location)
            :base(name, location, LionSize)
        {
            
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
                if (animal.Size <= this.Size * 2)
                {
                    this.Size++;
                    return animal.GetMeatFromKillQuantity();
                }
            }

            return 0;
        }
    }
}
