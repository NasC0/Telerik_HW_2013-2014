/* Task 1. Create a ChaoticParticle class, which is a Particle, randomly changing its movement (Speed). 
 * You are not allowed to edit any existing class. */

using System;
using System.Collections.Generic;

namespace ParticleSystem
{
    public class ChaoticParticle : Particle
    {
        protected const int MinSpeedDifference = -2;
        protected const int MaxSpeedDifference = 2;

        protected readonly Random randomGenerator;

        public ChaoticParticle(MatrixCoords position, MatrixCoords speed, Random randomGenerator)
            :base(position, speed)
        {
            this.randomGenerator = randomGenerator;
        }

        public override IEnumerable<Particle> Update()
        {
            this.Speed += GetRandomParticleSpeed();
            return base.Update();
        }

        protected MatrixCoords GetRandomParticleSpeed()
        {
            int rowSpeed = randomGenerator.Next(MinSpeedDifference, MaxSpeedDifference + 1);
            int colSpeed = randomGenerator.Next(MinSpeedDifference, MaxSpeedDifference + 1);

            return new MatrixCoords(rowSpeed, colSpeed);
        }

        public override char[,] GetImage()
        {
            return new char[,] { { '%' } };
        }
    }
}
