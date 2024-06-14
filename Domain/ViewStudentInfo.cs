using System.Runtime.Serialization;

namespace Domain
{
    /// <summary>
    /// Clase que representa la información de una vista de estudiante.
    /// </summary>
    [DataContract]
    public class ViewStudentInfo
    {
        /// <summary>
        /// Obtiene o establece el ID del estudiante.
        /// </summary>
        [DataMember]
        public string idStudent { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre completo del estudiante.
        /// </summary>
        [DataMember]
        public string fullName { get; set; }

        /// <summary>
        /// Obtiene o establece el ID del tutor del estudiante.
        /// </summary>
        [DataMember]
        public int idTutor { get; set; }

        /// <summary>
        /// Obtiene o establece el ID de la carrera del estudiante.
        /// </summary>
        [DataMember]
        public int idCareer { get; set; }

        /// <summary>
        /// Obtiene o establece el ID del usuario asociado al estudiante.
        /// </summary>
        [DataMember]
        public int idUser { get; set; }

        /// <summary>
        /// Obtiene o establece la contraseña del estudiante.
        /// </summary>
        [DataMember]
        public string password { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del tutor del estudiante.
        /// </summary>
        [DataMember]
        public string tutorName { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre de la carrera del estudiante.
        /// </summary>
        [DataMember]
        public string careerName { get; set; }
    }
}
