using System.ServiceModel;

namespace CheckStringsService
{
    [ServiceContract]
    public interface ICheckStrings
    {
        [OperationContract]
        int GetContainingCount(string substring, string fulltext);
    }
}
