
namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class ViewStudentsQueueReport
    {
        public int IdAppointment { get; set; }
        public System.DateTime AttendedDate { get; set; }
        public short Status { get; set; }
        public string IdStudent { get; set; }
        public string FullName { get; set; }
    }
}
