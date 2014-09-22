/* Task 2. Create a ChickenParticle class. The ChickenParticle class moves like a ChaoticParticle, 
 * but randomly stops at different positions for several simulation ticks and, for each of those stops, 
 * creates (lays) a new ChickenParticle. You are not allowed to edit any existing class. */

using System;
using System.Collections.Generic;

namespace ParticleSystem
{
    public class ChickenParticle : ChaoticParticle
    {
        // Each chicken particle can wait a maximum of 5 simulation ticks
        private const int MaxWaitingTime = 5;

        // 30% chance that the ChickenParticle will stop on the next tick and lay an egg
        private const int LayEggPercentage = 30;

        private bool waiting;

        private int waitTime;

        public ChickenParticle(MatrixCoords position, MatrixCoords speed, Random randomGenerator)
            :base(position, speed, randomGenerator)
        {
            
        }

        public override IEnumerable<Particle> Update()
        {
            if (this.waiting)
            {
                // Prevents the chicken particle from moving for the current tick.
                this.Speed = new MatrixCoords(0, 0);

                if (this.waitTime == 0)
                {
                    this.waiting = false;

                    return new List<ChickenParticle>()
                    {
                        new ChickenParticle(this.Position, this.Speed, this.randomGenerator)
                    };
                }

                this.waitTime--;

                // Cannot return the base update method, since it modifies the speed of the particle
                return new List<Particle>();
            }
            else
            {
                // There's a 30% chance that on the next simulation tick, the chickenParticle will stop
                // for a random interval and lay a new chicken particle
                if (this.randomGenerator.Next(0, 101) <= LayEggPercentage)
                {
                    this.waiting = true;
                    this.waitTime = randomGenerator.Next(MaxWaitingTime + 1);
                }

                return base.Update();
            }
        }

        public override char[,] GetImage()
        {
            return new char[,] { { '@' } };
        }
    }
}
