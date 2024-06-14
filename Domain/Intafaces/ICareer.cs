
using System.Collections.Generic;
using System.ServiceModel;

namespace Domain
{
    [ServiceContract]
    public interface ICareer
    {
        [OperationContract]
        List<Career> GetCareerList();
    }
}
