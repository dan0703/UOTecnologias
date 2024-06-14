using System.Runtime.Serialization;

namespace Domain
{
    /// <summary>
    /// Clase que representa un estudiante.
    /// </summary>
    [DataContract]
    public class Student
    {
        /// <summary>
        /// Obtiene o establece el identificador del estudiante.
        /// </summary>
        [DataMember]
        public string idStudent { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre completo del estudiante.
        /// </summary>
        [DataMember]
        public string fullName { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador del tutor del estudiante.
        /// </summary>
        [DataMember]
        public int idTutor { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador de la carrera del estudiante.
        /// </summary>
        [DataMember]
        public int idCareer { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador del usuario asociado al estudiante.
        /// </summary>
        [DataMember]
        public int idUser { get; set; }

        /// <summary>
        /// Obtiene o establece la matrícula del estudiante.
        /// </summary>
        [DataMember]
        public string matricula { get; set; }
    }
}
