using System.Collections.Generic;

namespace ComputerBuilderClasses.Contracts
{
    public interface IRaid : IDiskDrive
    {
        IEnumerable<IDiskDrive> Hdds { get; }
    }
}