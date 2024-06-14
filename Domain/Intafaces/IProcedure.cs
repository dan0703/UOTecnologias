using System.Collections.Generic;
using System.ServiceModel;

namespace Domain
{
    [ServiceContract]
    public interface IProcedure
    {
        [OperationContract]
        List<Procedure> GetProcedureList();
    }
}
