using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParticleSystem
{
    public class ChaoticParticleEmitter : ParticleEmitter
    {
        public ChaoticParticleEmitter(MatrixCoords position, MatrixCoords speed, Random randomGenerator)
            :base(position, speed, randomGenerator)
        {
            
        }

        protected override Particle GetNewParticle(MatrixCoords position, MatrixCoords speed)
        {
            if (randomGenerator.Next() % 2 == 0)
            {
                return new ChaoticParticle(position, speed, this.randomGenerator);
            }

            return base.GetNewParticle(position, speed);
        }
    }
}
