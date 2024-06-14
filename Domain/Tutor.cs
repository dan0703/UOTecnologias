using System.Runtime.Serialization;

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
