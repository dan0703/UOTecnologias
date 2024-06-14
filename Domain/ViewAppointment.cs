using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [DataContract]
    public class ViewAppointment
    {
        [DataMember]
        public int idAppointment { get; set; }

        [DataMember]
        public System.DateTime attendedDate { get; set; }

        [DataMember]
        public int duration { get; set; }

        [DataMember]
        public int status { get; set; }

        [DataMember]
        public string idStudent { get; set; }

        [DataMember]
        public string fullName { get; set; }

        [DataMember]
        public string tutorName { get; set; }

        [DataMember]
        public int idTutor {  get; set; }

        [DataMember]
        public int idProcedure { get; set; }

        [DataMember]
        public string procedureName { get; set; }

    }
}
