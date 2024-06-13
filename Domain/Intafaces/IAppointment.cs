using System;
using System.Collections.Generic;
using System.ServiceModel;


namespace Domain
{
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
        void JoinToSesion(string idStudent);

    }

    [ServiceContract]
    public interface IAppointmentCallback
    {
        [OperationContract]
        void SetAppointments(List<Appointment> appointments);
    }
}
