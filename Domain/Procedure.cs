using System.Runtime.Serialization;


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
