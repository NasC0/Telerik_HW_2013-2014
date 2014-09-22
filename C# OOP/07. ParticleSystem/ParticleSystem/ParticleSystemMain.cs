using System;
using System.Collections.Generic;

namespace ParticleSystem
{
    class ParticleSystemMain
    {
        const int SimulationRows = 50;
        const int SimulationCols = 60;

        static readonly Random RandomGenerator = new Random();

        static void Main(string[] args)
        {
            var renderer = new ConsoleRenderer(SimulationRows, SimulationCols);
            var particleOperator = new AdvancedParticleOperator();

            // Particle Repulsor Test
            //var particles = new List<Particle>()
            //{
            //    new ChaoticParticleEmitter(new MatrixCoords(8, 15), new MatrixCoords(0, 0), RandomGenerator),
            //    new ParticleEmitter(new MatrixCoords(8, 25), new MatrixCoords(), RandomGenerator),
            //    new ParticleRepulsor(new MatrixCoords(15, 20), new MatrixCoords(), 5),
            //    new ChaoticParticleEmitter(new MatrixCoords(20, 25), new MatrixCoords(), RandomGenerator),
            //    new ParticleEmitter(new MatrixCoords(20, 15), new MatrixCoords(), RandomGenerator)
            //};

            // Chaotic Particle Test
            //var particles = new List<Particle>()
            //{
            //    new ChaoticParticle(new MatrixCoords(25, 30), new MatrixCoords(1, 1), RandomGenerator)
            //};

            // Chicken Particle Test
            // I've slowed down the simulation for this particle, beacuse if the speed was faster, the screen would soon clutter with chicken particles
            var particles = new List<Particle>()
            {
                new ChickenParticle(new MatrixCoords(25, 30), new MatrixCoords(1, 1), RandomGenerator)
            };

            var engine = new Engine(renderer, particleOperator, particles, 1000);

            engine.Run();
        }
    }
}
