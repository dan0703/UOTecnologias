//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class Appointment
    {
        public int IdAppointment { get; set; }
        public System.DateTime AttendedDate { get; set; }
        public long Duration { get; set; }
        public short Status { get; set; }
        public string NotAttendedReason { get; set; }
        public string Student_IdStudent { get; set; }
        public int Procedure_IdProcedure { get; set; }
    
        public virtual Procedure Procedure { get; set; }
        public virtual Student Student { get; set; }
    }
}
