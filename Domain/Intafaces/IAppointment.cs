using System;
using System.Collections.Generic;
using System.ServiceModel;


namespace Domain
{
    /// <summary>
    /// Interfaz que define operaciones relacionadas a citas.
    /// </summary>
    [ServiceContract(CallbackContract = typeof(IAppointmentCallback))]
    public interface IAppointment
    {
        /// <summary>
        /// Obtiene todas las citas programadas.
        /// </summary>
        /// <returns>Lista de citas programadas.</returns>
        [OperationContract]
        List<Appointment> GetAllAppointments();

        /// <summary>
        /// Solicita una nueva cita para un estudiante.
        /// </summary>
        /// <param name="newAppointment">Información de la nueva cita.</param>
        [OperationContract(IsOneWay = true)]
        void AppointmentRequest(Domain.Appointment newAppointment);

        /// <summary>
        /// Permite a un estudiante dejar una cita.
        /// </summary>
        /// <param name="studentId">ID del estudiante.</param>
        /// <param name="reason">Motivo por el cual el estudiante deja la cita.</param>
        [OperationContract(IsOneWay = true)]
        void LeaveAppointment(string studentId, string reason);

        /// <summary>
        /// Cancela una cita específica.
        /// </summary>
        /// <param name="idAppointment">ID de la cita a cancelar.</param>
        /// <param name="reason">Motivo de la cancelación.</param>
        [OperationContract]
        void CancelAppointment(int idAppointment, string reason);

        /// <summary>
        /// Marca una cita como atendida.
        /// </summary>
        /// <param name="idAppointment">ID de la cita.</param>
        [OperationContract]
        void MarkAppointmentAsAttended(int idAppointment);

        /// <summary>
        /// Marca una cita como no atendida y especifica el motivo.
        /// </summary>
        /// <param name="idAppointment">ID de la cita.</param>
        /// <param name="reason">Motivo por el cual la cita no fue atendida.</param>
        [OperationContract]
        void MarkAppointmentAsNotAttended(int idAppointment, string reason);

        /// <summary>
        /// Obtiene un reporte de la cola de estudiantes en espera de ser atendidos.
        /// </summary>
        /// <returns>Lista de estudiantes en cola.</returns>
        [OperationContract]
        List<ViewStudentsQueueReport> GetStudentsQueueReport();

        /// <summary>
        /// Obtiene un reporte de citas por fecha específica.
        /// </summary>
        /// <param name="date">Fecha para la cual se desea obtener el reporte.</param>
        /// <returns>Lista de citas para la fecha especificada.</returns>
        [OperationContract]
        List<ViewAppointment> GetAppointmentReportByDate(DateTime date);

        /// <summary>
        /// Permite que un estudiante se una a la sesión del servicio.
        /// </summary>
        /// <param name="idStudent">ID del estudiante que se une a la sesión.</param>
        [OperationContract]
        void JoinToSesion(string idStudent);

    }

    /// <summary>
    /// Interfaz de callback para notificar al cliente sobre cambios en las citas.
    /// </summary>
    [ServiceContract]
    public interface IAppointmentCallback
    {
        /// <summary>
        /// Notifica al cliente sobre las citas en cola.
        /// </summary>
        /// <param name="appointments">Lista de citas en cola.</param>
        [OperationContract]
        void SetAppointments(List<Appointment> appointments);

        /// <summary>
        /// Actualiza el temporizador en el cliente con el tiempo transcurrido de la cita que esta siendo atendida.
        /// </summary>
        /// <param name="elapsedTime">Tiempo transcurrido desde el inicio de la cita.</param>
        [OperationContract]
        void UpdateTimer(TimeSpan elapsedTime);

        /// <summary>
        /// Notifica al cliente sobre la cancelación de una cita con el motivo especificado.
        /// </summary>
        /// <param name="reason">Motivo de la cancelación.</param>
        [OperationContract]
        void NotifyCancellation(string reason);
    }
}
