using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public partial class Implementations : IViewStudentInfo
    {
        public ViewStudentInfo LogIn(string studentId, string password)
        {
            ViewStudentInfo studentInfo = null;
            using (FEIDBEntities context = new FEIDBEntities())
            {
                var foundUser = context.GetStudentInfoes.Where(x => x.IdStudent == studentId).FirstOrDefault();
                if (foundUser != null)
                {
                    Console.WriteLine("fonduser");
                    if(foundUser.Password == password)
                    {
                        studentInfo = new ViewStudentInfo();
                        Console.WriteLine("wrong password");
                        studentInfo.fullName=foundUser.FullName;
                        studentInfo.idCareer=foundUser.Career_IdCareer;
                        studentInfo.idTutor=foundUser.Tutor_IdTutor;
                        studentInfo.idStudent=foundUser.IdStudent;
                    }
                }
                Console.WriteLine(foundUser);
            }
            return studentInfo;
        }
    }
}
