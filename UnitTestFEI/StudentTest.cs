using DataAccess;
using FEIService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service;
using Moq;

using System.Transactions;
using System.Collections.Generic;
using System.Linq;


namespace UnitTestFEI
{
    [TestClass()]
    public class StudentTest
    {
        private Implementations service;


        [TestInitialize]
        public void UnitTestFEIInitialize()
        {
            service = new Implementations();
        }

        [TestMethod()]
        public void Test01_LogIn_SuccessfullTest()
        {
            var studentId = "zs20015706";
            var password = Complements.EncryptPassword("Dan08BSE07@");
            var result = service.LogIn(studentId, password);

            Assert.IsNotNull(result);
            Assert.AreEqual("Dan Joshua Segura Domínguez", result.fullName);
            Assert.AreEqual(1, result.idCareer);
            Assert.AreEqual(1, result.idTutor);
            Assert.AreEqual("zs20015706", result.idStudent);
            Assert.AreEqual("Ingenieria De Software", result.careerName);
            Assert.AreEqual("Murrieta", result.tutorName);
        }

        [TestMethod()]
        public void Test02_LogIn_InvalidCredentials_NotValidTest()
        {
            var studentId = "testStudentId";
            var password = "wrongPassword";


            var result = service.LogIn(studentId, password);

            Assert.IsNull(result);
        }


        [TestMethod()]
        public void Test03_RegisterStudent_SuccessfullTest()
        {
            Domain.ViewStudentInfo newStudent = new Domain.ViewStudentInfo
            {
                password = Complements.EncryptPassword("Dan08BSE07@"),
                idStudent = "zs90015712",
                fullName = "Prueba_RegisterStudent",
                idCareer = 1,
                idTutor = 1,
            };
            var result = service.RegisterStudent(newStudent);
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void Test04_RegisterStudent_NotValidTest_IdStudentAllreadyInDB()
        {
            Domain.ViewStudentInfo newStudent = new Domain.ViewStudentInfo
            {
                password = Complements.EncryptPassword("Dan08BSE07@"),
                idStudent = "zs90015708",
                fullName = "Prueba_RegisterStudent_IdStudentAllreadyInDB",
                idCareer = 1,
                idTutor = 1,
            };
            var result = service.RegisterStudent(newStudent);
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void Test05_RegisterStudent_NotValidTest_WrongIdCareer()
        {
            Domain.ViewStudentInfo newStudent = new Domain.ViewStudentInfo
            {
                password = Complements.EncryptPassword("Dan08BSE07@"),
                idStudent = "zs90015706",
                fullName = "Prueba_RegisterStudent_IdStudentAllreadyInDB",
                idCareer = 0,
                idTutor = 1,
            };
            var result = service.RegisterStudent(newStudent);
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void Test06_RegisterStudent_NotValidTest_WrongIdTutor()
        {
            Domain.ViewStudentInfo newStudent = new Domain.ViewStudentInfo
            {
                password = Complements.EncryptPassword("Dan08BSE07@"),
                idStudent = "zs90015706",
                fullName = "Prueba_RegisterStudent_IdStudentAllreadyInDB",
                idCareer = 1,
                idTutor = 0,
            };
            var result = service.RegisterStudent(newStudent);
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void Test07_GetStudentById_SuccessfullTest()
        {
            var result = service.GetStudentNameById("zs90015706");
            Assert.AreEqual("Prueba_RegisterStudent_IdStudentAllreadyInDB", result.fullName);
        }

        [TestMethod()]
        public void Test08_GetStudentById_NotValidTest()
        {
            var result = service.GetStudentNameById("wrongId");
            Assert.IsNull(result);
        }
    }
}
