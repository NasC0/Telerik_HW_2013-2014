using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParticleSystem
{
    public class AdvancedParticleOperator : ParticleUpdater
    {
        private List<Particle> currentTickParticles = new List<Particle>();
        private List<ParticleAttractor> currentTickAttractors = new List<ParticleAttractor>();
        private List<ParticleRepulsor> currentTickRepulsors = new List<ParticleRepulsor>();

        public override IEnumerable<Particle> OperateOn(Particle p)
        {
            if (p is ParticleAttractor)
            {
                currentTickAttractors.Add(p as ParticleAttractor);
            }
            else if (p is ParticleRepulsor)
            {
                currentTickRepulsors.Add(p as ParticleRepulsor);
            }
            else
            {
                this.currentTickParticles.Add(p);
            }
            
            return base.OperateOn(p);
        }

        public override void TickEnded()
        {
            foreach (var attractor in this.currentTickAttractors)
            {
                foreach (var particle in this.currentTickParticles)
                {
                    var currParticleToAttractorVector = attractor.Position - particle.Position;

                    int pToAttrRow = currParticleToAttractorVector.Row;
                    pToAttrRow = DecreaseVectorCoordToPower(attractor, pToAttrRow);

                    int pToAttrCol = currParticleToAttractorVector.Col;
                    pToAttrCol = DecreaseVectorCoordToPower(attractor, pToAttrCol);

                    var currAcceleration = new MatrixCoords(pToAttrRow, pToAttrCol);

                    particle.Accelerate(currAcceleration);
                }
            }

            foreach (var repulsor in this.currentTickRepulsors)
            {
                foreach (var particle in this.currentTickParticles)
                {
                    if (GetDistanceBetweenPoints(repulsor, particle) <= repulsor.Range)
                    {
                        // Gets the vector between the particle position and the repulsors position
                        // and accelerates the particle in that direction

                        var currParticleToRepulsorVector = particle.Position - repulsor.Position;

                        particle.Accelerate(currParticleToRepulsorVector);
                    }
                }
            }

            this.currentTickParticles.Clear();
            this.currentTickAttractors.Clear();
            this.currentTickRepulsors.Clear();

            base.TickEnded();
        }

        private static int DecreaseVectorCoordToPower(ParticleAttractor attractor, int pToAttrCoord)
        {
            if (Math.Abs(pToAttrCoord) > attractor.AttractionPower)
            {
                pToAttrCoord = (pToAttrCoord / (int)Math.Abs(pToAttrCoord)) * attractor.AttractionPower;
            }
            return pToAttrCoord;
        }

        // Calculates Euclidean Distance between two points.
        private static int GetDistanceBetweenPoints(Particle firstParticle, Particle secondParticle)
        {
            return (int)Math.Sqrt(Math.Pow(firstParticle.Position.Row - secondParticle.Position.Row, 2) + Math.Pow(firstParticle.Position.Col - secondParticle.Position.Col, 2));
        }
    }
}
