using System;
using System.ServiceModel;

namespace DayOfWeekServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IDayOfWeek" in both code and config file together.
    [ServiceContract]
    public interface IDayOfWeek
    {
        [OperationContract]
        string GetDayOfWeek(DateTime date);
    }
}
