using System.ServiceModel;

namespace Domain
{
    [ServiceContract]
    public interface IViewStudentInfo
    {
        [OperationContract]
        ViewStudentInfo LogIn(string studentId, string password);
    }
}
