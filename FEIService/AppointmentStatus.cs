namespace FEIService
{
    /// <summary>
    /// Enumeración que define los estados de las citas.
    /// </summary>
    public enum AppointmentStatus
    {
        /// <summary>
        /// Estado pendiente.
        /// </summary>
        Pending = 0,

        /// <summary>
        /// Estado de la cita atendida.
        /// </summary>
        Attended = 1,

        /// <summary>
        /// Estado de la cita cancelada por el estudiante.
        /// </summary>
        CanceledByStudent = 2,

        /// <summary>
        /// Estado de la cita cancelada por el secretario.
        /// </summary>
        CanceledBySecretary = 3,

        /// <summary>
        /// Estado de la cita en progreso.
        /// </summary>
        InProgress = 4,

        /// <summary>
        /// Estado de la cita no atendida.
        /// </summary>
        NotAttended = 5
    }
}
