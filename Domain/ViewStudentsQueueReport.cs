using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [DataContract]
    public class ViewStudentsQueueReport
    {
        [DataMember]
        public int idAppointment {  get; set; }

        [DataMember]
        public System.DateTime attendedDate { get; set; }

        [DataMember]
        public int status { get; set; }

        [DataMember]
        public string idStudent { get; set; }

        [DataMember]
        public string studentName { get; set; }
    }
}
