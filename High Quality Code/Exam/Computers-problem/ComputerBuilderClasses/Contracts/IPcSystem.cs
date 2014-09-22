using System;

namespace ComputerBuilderClasses.Contracts
{
    public interface IPcSystem : ISystem
    {
        void Play(int guessNumber, Random randomGenerator);
    }
}