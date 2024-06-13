using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [DataContract]
    public class Tutor
    {
        [DataMember]
        public int idTutor { get; set; }
        [DataMember]
        public string fullName { get; set; }
    }
}
