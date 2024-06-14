using System;
using System.Runtime.Serialization;

namespace Domain
{
    /// <summary>
    /// Clase que representa una vista de una cita.
    /// </summary>
    [DataContract]
    public class ViewAppointment
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
        /// Obtiene o establece la duración de la cita.
        /// </summary>
        [DataMember]
        public int duration { get; set; }

        /// <summary>
        /// Obtiene o establece el estado de la cita, este puede ser Pendiente si es 0, Atendida si es 1, cancelada por el estudiante si es 2, cancelada por secretaria si es 3, en progreso si es 4, no atendida si es 5.
        /// </summary>
        [DataMember]
        public int status { get; set; }

        /// <summary>
        /// Obtiene o establece el ID del estudiante asociado a la cita.
        /// </summary>
        [DataMember]
        public string idStudent { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre completo del estudiante asociado a la cita.
        /// </summary>
        [DataMember]
        public string fullName { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del tutor asociado a la cita.
        /// </summary>
        [DataMember]
        public string tutorName { get; set; }

        /// <summary>
        /// Obtiene o establece el ID del tutor asociado a la cita.
        /// </summary>
        [DataMember]
        public int idTutor { get; set; }

        /// <summary>
        /// Obtiene o establece el ID del tramite asociado a la cita.
        /// </summary>
        [DataMember]
        public int idProcedure { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del tramite asociado a la cita.
        /// </summary>
        [DataMember]
        public string procedureName { get; set; }
    }
}
