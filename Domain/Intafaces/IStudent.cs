using System.ServiceModel;

namespace Domain
{
    [ServiceContract]
    public interface IStudent
    {
        [OperationContract]
        bool RegisterStudent(ViewStudentInfo student);

        [OperationContract]
        Student GetStudentNameById(string idStudent);
    }
}
