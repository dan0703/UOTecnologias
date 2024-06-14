using System.Runtime.Serialization;

namespace Domain
{
    /// <summary>
    /// Clase que representa los canales de callback para un estudiante.
    /// </summary>
    [DataContract]
    public class StudentCallbackChanels
    {
        /// <summary>
        /// Obtiene o establece el callback de cita.
        /// </summary>
        [DataMember]
        public IAppointmentCallback appointmentCallback { get; set; }
    }
}
