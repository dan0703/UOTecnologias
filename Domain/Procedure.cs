using System.Runtime.Serialization;

namespace Domain
{
    /// <summary>
    /// Clase que representa un tramite.
    /// </summary>
    [DataContract]
    public class Procedure
    {
        /// <summary>
        /// Obtiene o establece el nombre del tramite.
        /// </summary>
        [DataMember]
        public string name { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador único del tramite.
        /// </summary>
        [DataMember]
        public int idProcedure { get; set; }
    }
}
