using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [DataContract]
    public class Career
    {
        [DataMember]
        public int idCareer { get; set; }
        [DataMember]
        public string name { get; set; }
    }
}
