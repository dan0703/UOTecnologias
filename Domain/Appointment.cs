using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [DataContract]
    public class Appointment
    {
        [DataMember]
        public int idApoointment { get; set; }

        [DataMember]
        public System.DateTime attendedDate { get; set; }

        [DataMember]
        public int duration { get; set; }

        [DataMember]
        public int status { get; set; }

        [DataMember]
        public string notAttendedReason { get; set; }

        [DataMember]
        public string student_IdStudent { get; set; }

        [DataMember]
        public int procedure_IdProcedure { get; set; }
    }
}
