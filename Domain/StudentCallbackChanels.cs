using System.Runtime.Serialization;


namespace Domain
{
    [DataContract]
    public class StudentCallbackChanels
    {
        public IAppointmentCallback appointmentCallback {  get; set; }
    }
}
