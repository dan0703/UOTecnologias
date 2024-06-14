using System.Runtime.Serialization;

namespace Domain
{
    /// <summary>
    /// Clase que representa una cita (appointment).
    /// </summary>
    [DataContract]
    public class Appointment
    {
        /// <summary>
        /// ID de la cita.
        /// </summary>
        [DataMember]
        public int idAppointment { get; set; }

        /// <summary>
        /// Fecha en que se atendió la cita.
        /// </summary>
        [DataMember]
        public System.DateTime attendedDate { get; set; }

        /// <summary>
        /// Duración de la cita.
        /// </summary>
        [DataMember]
        public int duration { get; set; }
       
        /// <summary>
        /// Estado de la cita, este puede ser Pendiente si es 0, Atendida si es 1, cancelada por el estudiante si es 2, cancelada por secretaria si es 3, en progreso si es 4, no atendida si es 5.
        /// </summary>
        [DataMember]
        public int status { get; set; }

        /// <summary>
        /// Razón por la cual la cita no fue atendida.
        /// </summary>
        [DataMember]
        public string notAttendedReason { get; set; }

        /// <summary>
        /// ID del estudiante asociado a la cita.
        /// </summary>
        [DataMember]
        public string student_IdStudent { get; set; }

        /// <summary>
        /// ID del tramite asociado a la cita.
        /// </summary>
        [DataMember]
        public int procedure_IdProcedure { get; set; }
    }
}
