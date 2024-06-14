using System.Runtime.Serialization;

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
