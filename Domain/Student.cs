using System.Runtime.Serialization;


namespace Domain
{
    [DataContract]
    public class Student
    {
        [DataMember]public string idStudent {  get; set; }
        [DataMember]public string fullName { get; set; }
        [DataMember]public int idTutor { get; set; }
        [DataMember]public int idCareer { get; set; }
        [DataMember]public int idUser {  get; set; }
        [DataMember]public string matricula { get; set; }
    }
}
