using System.Collections.Generic;
using System.ServiceModel;


namespace Domain
{
    [ServiceContract]
    public interface ITutor
    {
        [OperationContract]
        List<Tutor> GetTutorsList();

        [OperationContract]
        Tutor GetTutorById(int idTutor);
    }
}
