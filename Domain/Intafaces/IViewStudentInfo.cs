using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [ServiceContract]
    public interface IViewStudentInfo
    {
        [OperationContract]
        ViewStudentInfo LogIn(string studentId, string password);
    }
}
