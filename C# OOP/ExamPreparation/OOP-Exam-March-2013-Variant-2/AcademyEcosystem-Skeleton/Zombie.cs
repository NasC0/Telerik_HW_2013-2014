﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyEcosystem
{
    public class Zombie : Animal
    {
        private const int ZombieSize = 1;

        public Zombie(string name, Point location)
            :base(name, location, ZombieSize)
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

        public override int GetMeatFromKillQuantity()
        {
            return 10;
        }
    }
}
