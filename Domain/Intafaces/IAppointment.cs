using System;
using System.Collections.Generic;
using System.ServiceModel;


namespace Domain
{
    /// <summary>
    /// 
    /// </summary>
    [ServiceContract(CallbackContract = typeof(IAppointmentCallback))]
    public interface IAppointment
    {
        [OperationContract]
        List<Appointment> GetAllAppointments();

        [OperationContract(IsOneWay = true)]
        void AppointmentRequest(Domain.Appointment newAppointment);

        [OperationContract(IsOneWay = true)]
        void LeaveAppointment(string studentId, string reason);

        [OperationContract]
        void CancelAppointment(int idAppointment, string reason);

        [OperationContract]
        void MarkAppointmentAsAttended(int idAppointment);

        [OperationContract]
        void MarkAppointmentAsNotAttended(int idAppointment, string reason);

        [OperationContract]
        List<ViewStudentsQueueReport> GetStudentsQueueReport();

        [OperationContract]
        List<ViewAppointment> GetAppointmentReportByDate(DateTime date);

        [OperationContract]
        void JoinToSesion(string idStudent);

    }

    [ServiceContract]
    public interface IAppointmentCallback
    {
        [OperationContract]
        void SetAppointments(List<Appointment> appointments);

        [OperationContract]
        void UpdateTimer(TimeSpan elapsedTime);

        [OperationContract]
        void NotifyCancellation(string reason);
    }
}
