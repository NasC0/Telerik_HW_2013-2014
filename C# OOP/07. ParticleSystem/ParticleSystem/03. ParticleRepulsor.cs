/* Task 3. Implement a ParticleRepeller class. A ParticleRepeller is a Particle, which pushes other particles away from it 
 * (i.e. accelerates them in a direction, opposite of the direction in which the repeller is). 
 * The repeller has an effect only on particles within a certain radius (see Euclidean distance)
 * The euclidean distance is calculated inside the AdvancedParticleOperator class */

using System;

namespace ParticleSystem
{
    public class ParticleRepulsor : Particle
    {
        private int range;

        public ParticleRepulsor(MatrixCoords position, MatrixCoords speed, int range)
            :base(position, speed)
        {
            this.Range = range;
        }

        public int Range
        {
            get
            {
                return this.range;
            }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid range argument passed: must be equal to or bigger than 0.");
                }

                this.range = value;
            }
        }
    }
}
