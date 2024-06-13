using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [DataContract]
    public class Procedure
    {
        [DataMember]
        public string name { get; set; }

        [DataMember]    
        public int idProcedure { get; set; }
    }
}
