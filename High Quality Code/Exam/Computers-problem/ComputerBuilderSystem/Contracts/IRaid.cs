using System.Collections.Generic;
namespace ComputerBuilderSystem.Contracts
{
    public interface IRaid : IDiskDrive
    {
        IEnumerable<IDiskDrive> Hdds { get; }
    }
}