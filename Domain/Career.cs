using System.Runtime.Serialization;

namespace Domain
{
    /// <summary>
    /// Clase que representa una carrera.
    /// </summary>
    [DataContract]
    public class Career
    {
        /// <summary>
        /// Obtiene o establece el identificador único de la carrera.
        /// </summary>
        [DataMember]
        public int idCareer { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre de la carrera.
        /// </summary>
        [DataMember]
        public string name { get; set; }
    }
}
