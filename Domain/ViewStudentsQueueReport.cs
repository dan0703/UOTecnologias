using System;
using System.Runtime.Serialization;

namespace Domain
{
    /// <summary>
    /// Clase que representa un reporte de estudiantes en cola.
    /// </summary>
    [DataContract]
    public class ViewStudentsQueueReport
    {
        /// <summary>
        /// Obtiene o establece el ID de la cita.
        /// </summary>
        [DataMember]
        public int idAppointment { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha en que se atendió la cita.
        /// </summary>
        [DataMember]
        public DateTime attendedDate { get; set; }

        /// <summary>
        /// Obtiene o establece el estado de la cita.
        /// </summary>
        [DataMember]
        public int status { get; set; }

        /// <summary>
        /// Obtiene o establece el ID del estudiante asociado a la cita.
        /// </summary>
        [DataMember]
        public string idStudent { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del estudiante asociado a la cita.
        /// </summary>
        [DataMember]
        public string studentName { get; set; }
    }
}
