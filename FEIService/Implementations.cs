using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public partial class Implementations : IViewStudentInfo
    {
        public Domain.ViewStudentInfo LogIn(string studentId, string password)
        {
            Domain.ViewStudentInfo studentInfo = null;

            using (FEIDBEntities context = new FEIDBEntities())
            {
                try
                {
                    var foundStudent = context.Students.Where(x => x.Matricula == studentId).FirstOrDefault();
                    if (foundStudent != null)
                    {
                        var foundUser = context.Users.Where(x => x.IdUser == foundStudent.User_IdUser).FirstOrDefault();
                        if (foundUser.Password!= null)
                        {
                            if(foundUser.Password == password)
                            {
                                studentInfo = new Domain.ViewStudentInfo();
                                studentInfo.fullName = foundStudent.FullName;
                                studentInfo.idCareer = foundStudent.Career_IdCareer;
                                studentInfo.idTutor = foundStudent.Tutor_IdTutor;
                                studentInfo.idStudent = foundStudent.Matricula;
                            }                            
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return studentInfo;
        }
    }
    public partial class Implementations : ITutor
    {
        public List<Domain.Tutor> GetTutorsList()
        {
            List<Domain.Tutor> tutorList = new List<Domain.Tutor>();
            using (FEIDBEntities context = new FEIDBEntities())
            {
                var foundTutorList = context.Tutors.ToList();
                foreach (var tutor in foundTutorList)
                {
                    Domain.Tutor tutorInfo = new Domain.Tutor()
                    {
                        idTutor = tutor.IdTutor,
                        fullName = tutor.Name
                        
                    };

                    tutorList.Add(tutorInfo);
                }
            }

            return tutorList;
        }
    }
    public partial class Implementations : ICareer
    {
        public List<Domain.Career> GetCareerList()
        {
            List<Domain.Career> careerList = new List<Domain.Career>();
            using (FEIDBEntities context = new FEIDBEntities())
            {
                var foundCareerList = context.Careers.ToList();
                foreach (var career in foundCareerList)
                {
                    Domain.Career careerInfo = new Domain.Career()
                    {
                        idCareer = career.IdCareer,
                        name = career.CareerName

                    };

                    careerList.Add(careerInfo);
                }
            }

            return careerList;
        }

    }

    public partial class Implementations : IStudent
    {

        public bool RegisterStudent(Domain.ViewStudentInfo student)
        {
            bool isSuccessful = false;

            if (student != null)
            {
                using (FEIDBEntities context = new FEIDBEntities())
                {
                    using (var dbContextTransaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            var newUser = new DataAccess.User()
                            {
                                Password = student.password
                            };

                            context.Users.Add(newUser);
                            context.SaveChanges();
                            var newStudent = new DataAccess.Student()
                            {
                                Matricula = student.idStudent,
                                FullName = student.fullName,
                                Tutor_IdTutor = student.idTutor,
                                Career_IdCareer = student.idCareer,
                                User_IdUser = newUser.IdUser,
                                IdStudent = student.idStudent,
                            };

                            var existingStudent = context.Students.FirstOrDefault(s => s.IdStudent == newStudent.IdStudent);
                            if (existingStudent != null)
                            {
                                throw new Exception("Student already exists with the same IdStudent.");
                            }

                            context.Students.Add(newStudent);
                            context.SaveChanges();

                            dbContextTransaction.Commit();
                            isSuccessful = true;
                        }
                        catch (DbEntityValidationException ex)
                        {
                            dbContextTransaction.Rollback();
                            foreach (var validationErrors in ex.EntityValidationErrors)
                            {
                                foreach (var validationError in validationErrors.ValidationErrors)
                                {
                                    Console.WriteLine($"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage}");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            dbContextTransaction.Rollback();
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
            }

            return isSuccessful;
        }


    }
}
