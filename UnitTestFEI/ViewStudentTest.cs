using DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Service;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace UnitTestFEI
{
    [TestClass]
    public class ViewStudentTest
    {
        [TestMethod]
        public void LogIn_ValidCredentials_ReturnsStudentInfo()
        {
            // Arrange
            var studentId = "zs20015706";
            var password = "Dan08BSE07@";

            var mockContext = new Mock<FEIDBEntities>();
            var mockStudents = new Mock<DbSet<ViewStudent>>();
            var mockUsers = new Mock<DbSet<User>>();

            var studentData = new List<ViewStudent>
            {
                new ViewStudent { IdStudent = studentId, IdUser = 1, FullName = "Test Student", IdCareer = 1, IdTutor = 1, CareerName = "Test Career", Name = "Test Tutor" }
            }.AsQueryable();

            var userData = new List<User>
            {
                new User { IdUser = 1, Password = password }
            }.AsQueryable();

            mockStudents.As<IQueryable<ViewStudent>>().Setup(m => m.Provider).Returns(studentData.Provider);
            mockStudents.As<IQueryable<ViewStudent>>().Setup(m => m.Expression).Returns(studentData.Expression);
            mockStudents.As<IQueryable<ViewStudent>>().Setup(m => m.ElementType).Returns(studentData.ElementType);
            mockStudents.As<IQueryable<ViewStudent>>().Setup(m => m.GetEnumerator()).Returns(studentData.GetEnumerator());

            mockUsers.As<IQueryable<User>>().Setup(m => m.Provider).Returns(userData.Provider);
            mockUsers.As<IQueryable<User>>().Setup(m => m.Expression).Returns(userData.Expression);
            mockUsers.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(userData.ElementType);
            mockUsers.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(userData.GetEnumerator());

            mockContext.Setup(c => c.ViewStudents).Returns(mockStudents.Object);
            mockContext.Setup(c => c.Users).Returns(mockUsers.Object);

            var service = new Implementations();

            // Act
            var result = service.LogIn(studentId, password);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Test Student", result.fullName);
        }

        [TestMethod]
        public void LogIn_InvalidCredentials_ReturnsNull()
        {
            // Arrange
            var studentId = "testStudentId";
            var password = "wrongPassword";

            var mockContext = new Mock<FEIDBEntities>();
            var mockStudents = new Mock<DbSet<ViewStudent>>();
            var mockUsers = new Mock<DbSet<User>>();

            var studentData = new List<ViewStudent>
            {
                new ViewStudent { IdStudent = studentId, IdUser = 1, FullName = "Test Student", IdCareer = 1, IdTutor = 1, CareerName = "Test Career", Name = "Test Tutor" }
            }.AsQueryable();

            var userData = new List<User>
            {
                new User { IdUser = 1, Password = "testPassword" }
            }.AsQueryable();

            mockStudents.As<IQueryable<ViewStudent>>().Setup(m => m.Provider).Returns(studentData.Provider);
            mockStudents.As<IQueryable<ViewStudent>>().Setup(m => m.Expression).Returns(studentData.Expression);
            mockStudents.As<IQueryable<ViewStudent>>().Setup(m => m.ElementType).Returns(studentData.ElementType);
            mockStudents.As<IQueryable<ViewStudent>>().Setup(m => m.GetEnumerator()).Returns(studentData.GetEnumerator());

            mockUsers.As<IQueryable<User>>().Setup(m => m.Provider).Returns(userData.Provider);
            mockUsers.As<IQueryable<User>>().Setup(m => m.Expression).Returns(userData.Expression);
            mockUsers.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(userData.ElementType);
            mockUsers.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(userData.GetEnumerator());

            mockContext.Setup(c => c.ViewStudents).Returns(mockStudents.Object);
            mockContext.Setup(c => c.Users).Returns(mockUsers.Object);

            var service = new Implementations();

            // Act
            var result = service.LogIn(studentId, password);

            // Assert
            Assert.IsNull(result);
        }
    }
}
