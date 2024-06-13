using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [ServiceContract]
    public interface IProcedure
    {
        [OperationContract]
        List<Procedure> GetProcedureList();
    }
}
