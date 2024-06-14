﻿using DataAccess;
using Domain;
using FEIService;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Validation;
using System.Linq;
using System.Security.Principal;
using System.ServiceModel;
using System.Threading;
using System.Timers;

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
                    var foundStudent = context.ViewStudents.Where(x => x.IdStudent == studentId).FirstOrDefault();
                    if (foundStudent != null)
                    {
                        var foundUser = context.Users.Where(x => x.IdUser == foundStudent.IdUser).FirstOrDefault();
                        if (foundUser.Password != null)
                        {
                            if (foundUser.Password == password)
                            {
                                studentInfo = new Domain.ViewStudentInfo();
                                studentInfo.fullName = foundStudent.FullName;
                                studentInfo.idCareer = foundStudent.IdCareer;
                                studentInfo.idTutor = foundStudent.IdTutor;
                                studentInfo.idStudent = foundStudent.IdStudent;
                                studentInfo.careerName = foundStudent.CareerName;
                                studentInfo.tutorName = foundStudent.Name;
                            }
                        }
                    }
                }
                catch (EntityException ex)
                {
                    Console.WriteLine(ex.Message);
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
        public Domain.Tutor GetTutorById(int idTutor)
        {
            Domain.Tutor tutor = null;
            using (FEIDBEntities context = new FEIDBEntities())
            {
                try
                {
                    var foundTutor = context.Tutors.Where(x => x.IdTutor == idTutor).FirstOrDefault();
                    tutor = new Domain.Tutor()
                    {
                        idTutor = foundTutor.IdTutor,
                        fullName = foundTutor.Name,
                    };

                }
                catch (EntityException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            return tutor;
        }

        public List<Domain.Tutor> GetTutorsList()
        {
            List<Domain.Tutor> tutorList = new List<Domain.Tutor>();

            using (FEIDBEntities context = new FEIDBEntities())
            {
                try
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
                catch (EntityException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
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
                try
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
                catch (EntityException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return careerList;
        }
    }

    public partial class Implementations : IStudent
    {
        public Domain.Student GetStudentNameById(string idStudent)
        {
            Domain.Student student = null;
            using (FEIDBEntities context = new FEIDBEntities())
            {
                try
                {
                    var foundStudent = context.Students.Where(x => x.IdStudent == idStudent).FirstOrDefault();
                    student = new Domain.Student()
                    {
                        idStudent = idStudent,
                        matricula = foundStudent.Matricula,
                        fullName = foundStudent.FullName,

                    };

                }
                catch (EntityException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            return student;
        }

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

    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant)]
    public partial class Implementations : IAppointment
    {
        private static readonly Dictionary<string, StudentCallbackChanels> studentList = new Dictionary<string, StudentCallbackChanels>();
        private static readonly List<Domain.Appointment> appointmentList = new List<Domain.Appointment>();
        private static System.Threading.Timer timer;
        private static DateTime startTime;
        private static bool isTimerStoped = false; 

        public Implementations()
        {
            timer = new System.Threading.Timer(TimerElapsed, null, Timeout.Infinite, 1000);
        }
        private static void StartTimer()
        {
            startTime = DateTime.Now;
            timer.Change(0, 1000); 
        }

        private static void StopTimer()
        {
            timer.Change(Timeout.Infinite, 1000); 
        }

        private static void TimerElapsed(object state)
        {
            if (!isTimerStoped)
            {
                var elapsedTime = DateTime.Now - startTime;
                try
                {
                    foreach (var student in studentList.Values)
                    {
                        student.appointmentCallback.UpdateTimer(elapsedTime);
                    }
                }catch(Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                
            }
        }

        private void NotifyClients()
        {
            var students = studentList.Select(x => x.Key).ToList();
            foreach (var student in students)
            {
                studentList[student].appointmentCallback.SetAppointments(appointmentList);
            }
        }

        public void AppointmentRequest(Domain.Appointment newAppointment)
        {
            if (appointmentList.FirstOrDefault(x => x.student_IdStudent == newAppointment.student_IdStudent) == null)
            {
                appointmentList.Add(newAppointment);
                using (FEIDBEntities context = new FEIDBEntities())
                {
                    try
                    {
                        var newAppointmentAux = new DataAccess.Appointment()
                        {
                            AttendedDate = DateTime.Now,
                            Duration = 0,
                            Status = Constants.Pending,
                            Student_IdStudent = newAppointment.student_IdStudent,
                            Procedure_IdProcedure = newAppointment.procedure_IdProcedure,
                            NotAttendedReason = "",
                        };
                        context.Appointments.Add(newAppointmentAux);
                        context.SaveChanges();
                    }
                    catch (DbEntityValidationException ex)
                    {
                        foreach (var entityValidationErrors in ex.EntityValidationErrors)
                        {
                            foreach (var validationError in entityValidationErrors.ValidationErrors)
                            {
                                Console.WriteLine($"Property: {validationError.PropertyName}, Error: {validationError.ErrorMessage}");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error al guardar en la base de datos: {ex.Message}");
                    }
                }

                if (appointmentList.Count == 1) 
                {
                    isTimerStoped = false;
                    StartTimer();
                }
            }
            NotifyClients();
        }


        public List<Domain.Appointment> GetAllAppointments()
        {
            return appointmentList;
        }



        public void LeaveAppointment(string studentId, string reason)
        {
            var appointmentToRemove = appointmentList.FirstOrDefault(x => x.student_IdStudent == studentId);

            if (appointmentToRemove != null)
            {
                var wasFirstAppointment = (appointmentToRemove == appointmentList.First());

                appointmentList.Remove(appointmentToRemove);

                if (appointmentList.Count == 0)
                {
                    Console.WriteLine("stop");
                    isTimerStoped = true;
                    StopTimer();

                }
                else if (wasFirstAppointment)
                {
                    StartTimer();
                }
            }
            NotifyClients();
        }

        void IAppointment.JoinToSesion(string idStudent)
        {
            StudentCallbackChanels studentCallbackChanels = new StudentCallbackChanels()
            {
                appointmentCallback = OperationContext.Current.GetCallbackChannel<IAppointmentCallback>()
            };
            if (!studentList.ContainsKey(idStudent))
            {
                studentList.Add(idStudent, studentCallbackChanels);
            }
            else
            {
                studentList[idStudent] = studentCallbackChanels;
            }
        }

    }



    public partial class Implementations : IProcedure
    {
        public List<Domain.Procedure> GetProcedureList()
        {
            List<Domain.Procedure> procedureList = new List<Domain.Procedure>();
            using (FEIDBEntities context = new FEIDBEntities())
            {
                try
                {
                    var foundProcedureList = context.Procedures.ToList();
                    foreach (var procedure in foundProcedureList)
                    {
                        Domain.Procedure procedureInfo = new Domain.Procedure()
                        {
                            idProcedure = procedure.IdProcedure,
                            name = procedure.Name

                        };

                        procedureList.Add(procedureInfo);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }
            }
            return procedureList;
        }
    }
}
