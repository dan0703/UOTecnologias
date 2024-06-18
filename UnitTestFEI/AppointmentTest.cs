using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service;
using System;
using System.Globalization;


namespace UnitTestFEI
{
    /// <summary>
    /// Descripción resumida de AppointmentTest
    /// </summary>
    [TestClass]
    public class AppointmentTest
    {
        private Implementations serviceImplementation { get; set; }
        private int idAppointment;
        [TestInitialize]
        public void TestInitialize()
        {
            serviceImplementation = new Implementations();
            Domain.Appointment appointment = new Domain.Appointment()
            {
                student_IdStudent = "zs20015706",
                status = 0,
                procedure_IdProcedure = 1,
            };
            idAppointment = serviceImplementation.AddAppointmentToAppointmentList(appointment);
        }

        [TestMethod()]
        public void Test01_GetAllAppointments_Successfull()
        {
            var result = serviceImplementation.GetAllAppointments();
            Assert.IsNotNull(result);
            Console.WriteLine(result.Count);
            Assert.IsTrue(result.Count == 1);
        }


        [TestMethod()]
        public void Test02_GetStudentsQueueReport_Successfull()
        {
            var result = serviceImplementation.GetStudentsQueueReport();
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod()]
        public void Test03_GetAppointmentReportByDate_Successfull()
        {
            DateTime.TryParseExact("2024-06-13", "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime reportDate);

            var result = serviceImplementation.GetAppointmentReportByDate(reportDate);
            Assert.IsTrue(result.Count == 2);

        }
        [TestMethod()]
        public void Test03_GetAppointmentReportByDate__NotValidTest_WrongDate()
        {
            DateTime.TryParseExact("2024-01-13", "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime reportDate);

            var result = serviceImplementation.GetAppointmentReportByDate(reportDate);
            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod()]
        public void Test03_GetAppointmentReportByDate__NotValidTest_InvalidDate()
        {
            bool isValidDate = false;
            if(DateTime.TryParseExact("2024-01-1333", "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime reportDate))
            {
                isValidDate = true;
            }
            Assert.IsFalse(isValidDate);
            var result = serviceImplementation.GetAppointmentReportByDate(reportDate);
            Assert.IsTrue(result.Count == 0);
        }
    }
}
