using System.Runtime.Serialization;

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
