using System.Runtime.Serialization;

namespace Domain
{
    /// <summary>
    /// Clase que representa a un tutor.
    /// </summary>
    [DataContract]
    public class Tutor
    {
        /// <summary>
        /// Obtiene o establece el ID del tutor.
        /// </summary>
        [DataMember]
        public int idTutor { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre completo del tutor.
        /// </summary>
        [DataMember]
        public string fullName { get; set; }
    }
}
