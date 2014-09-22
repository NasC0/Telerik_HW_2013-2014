using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParticleSystem
{
    public class ChickenParticleEmitter : ChaoticParticleEmitter
    {
        public ChickenParticleEmitter(MatrixCoords position, MatrixCoords speed, Random randomGenerator)
            :base(position, speed, randomGenerator)
        {
            
        }

        protected override Particle GetNewParticle(MatrixCoords position, MatrixCoords speed)
        {
            return new ChickenParticle(position, speed, this.randomGenerator);
        }
    }
}
