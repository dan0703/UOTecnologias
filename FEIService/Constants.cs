namespace FEIService
{
    /// <summary>
    /// Clase que define constantes relacionadas con el estado de las citas.
    /// </summary>
    public class Constants
    {
        /// <summary>
        /// Estado pendiente.
        /// </summary>
        public static int Pending = 0;

        /// <summary>
        /// Estado de la cita atendida.
        /// </summary>
        public static int Attended = 1;

        /// <summary>
        /// Estado de la cita cancelada por el estudiante.
        /// </summary>
        public static int CanceledByStudent = 2;

        /// <summary>
        /// Estado de la cita cancelada por el secretario.
        /// </summary>
        public static int CanceledBySecretary = 3;

        /// <summary>
        /// Estado de la cita en progreso.
        /// </summary>
        public static int InProgress = 4;

        /// <summary>
        /// Estado de la cita no atendida.
        /// </summary>
        public static int NotAttended = 5;
    }
}
