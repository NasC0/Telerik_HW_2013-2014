using System;

namespace ComputerBuilderClasses.Contracts
{
    public interface ICentralProcessingUnit
    {
        int BitSize { get; }

        byte NumberOfCores { get; }

        int SquareNumber(int data);
        
        int Rand(Random randomGenerator, int minValue, int maxValue);
    }
}