using System.Runtime.Serialization;

namespace Domain
{
    [DataContract]
    public class Appointment
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
        public string notAttendedReason { get; set; }

        [DataMember]
        public string student_IdStudent { get; set; }

        [DataMember]
        public int procedure_IdProcedure { get; set; }
    }
}
