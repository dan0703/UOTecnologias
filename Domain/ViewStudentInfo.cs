using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [DataContract]
    public class ViewStudentInfo
    {
        [DataMember] public string idStudent { get; set; }
        [DataMember] public string fullName { get; set; }
        [DataMember] public int idTutor { get; set; }
        [DataMember] public int idCareer { get; set; }
        [DataMember] public int idUser { get; set; }
        [DataMember] public string password { get; set; }
    }
}
