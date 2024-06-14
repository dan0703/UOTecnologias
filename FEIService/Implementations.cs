using DataAccess;
using Domain;
using FEIService;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Validation;
using System.Linq;
using System.ServiceModel;
using System.Threading;
using ViewAppointment = Domain.ViewAppointment;

namespace Service
{
    /// <summary>
    /// Clase parcial que implementa la interfaz IViewStudentInfo para proporcionar operaciones relacionadas con estudiantes.
    /// </summary>
    public partial class Implementations : IViewStudentInfo
    {
        /// <summary>
        /// Intenta autenticar a un estudiante basado en su identificación y contraseña.
        /// </summary>
        /// <param name="studentId">La matrícula del estudiante.</param>
        /// <param name="password">La contraseña del estudiante.</param>
        /// <returns>La información del estudiante si la autenticación es exitosa; de lo contrario, null.</returns>
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

    /// <summary>
    /// Clase parcial que implementa la interfaz ITutor para proporcionar operaciones relacionadas con tutores.
    /// </summary>
    public partial class Implementations : ITutor
    {
        /// <summary>
        /// Obtiene un tutor por su ID.
        /// </summary>
        /// <param name="idTutor">El ID del tutor.</param>
        /// <returns>Objeto Tutor si se encuentra; de lo contrario, null.</returns>
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

        /// <summary>
        /// Obtiene una lista de todos los tutores.
        /// </summary>
        /// <returns>Lista de objetos Tutor.</returns>
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

    /// <summary>
    /// Clase parcial que implementa la interfaz ICareer para proporcionar operaciones relacionadas con carreras.
    /// </summary>
    public partial class Implementations : ICareer
    {
        /// <summary>
        /// Obtiene una lista de todas las carreras disponibles.
        /// </summary>
        /// <returns>Lista de objetos Career que representan todas las carreras.</returns>
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

    /// <summary>
    /// Clase parcial que implementa la interfaz IStudent para proporcionar operaciones relacionadas con estudiantes.
    /// </summary>
    public partial class Implementations : IStudent
    {
        /// <summary>
        /// Obtiene información de un estudiante por su ID de estudiante.
        /// </summary>
        /// <param name="idStudent">ID del estudiante a buscar.</param>
        /// <returns>Objeto Student que representa la información del estudiante encontrado.</returns>
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

        /// <summary>
        /// Registra un nuevo estudiante en la base de datos.
        /// </summary>
        /// <param name="student">Información del estudiante a registrar.</param>
        /// <returns>True si el registro fue exitoso, False si ocurrió algún error.</returns>
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
                                throw new ArgumentNullException("Ya existe un registro con esa matricula");
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

    /// <summary>
    /// Clase parcial que implementa la interfaz IAppointment para gestionar citas y notificaciones.
    /// </summary>
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant)]
    public partial class Implementations : IAppointment
    {
        private static readonly Dictionary<string, StudentCallbackChanels> studentList = new Dictionary<string, StudentCallbackChanels>();
        private static readonly List<Domain.Appointment> appointmentList = new List<Domain.Appointment>();
        private static System.Threading.Timer timer;
        private static DateTime startTime;
        private static bool isTimerStoped = false;

        /// <summary>
        /// Constructor de la clase Implementations.
        /// Inicializa el temporizador para notificar a los clientes.
        /// </summary>
        public Implementations()
        {
            timer = new System.Threading.Timer(TimerElapsed, null, Timeout.Infinite, 1000);
        }

        /// <summary>
        /// Método para iniciar el temporizador.
        /// </summary>
        private static void StartTimer()
        {
            startTime = DateTime.Now;
            timer.Change(0, 1000); 
        }

        /// <summary>
        /// Método para detener el temporizador.
        /// </summary>
        private static void StopTimer()
        {
            timer.Change(Timeout.Infinite, 1000); 
        }

        /// <summary>
        /// Método invocado por el temporizador para notificar el tiempo transcurrido a los clientes.
        /// </summary>
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

        /// <summary>
        /// Notifica a todos los clientes con la lista actual de citas.
        /// </summary>
        private void NotifyClients()
        {
            var students = studentList.Select(x => x.Key).ToList();
            foreach (var student in students)
            {
                studentList[student].appointmentCallback.SetAppointments(appointmentList);
            }
        }

        /// <summary>
        /// Registra una nueva cita.
        /// </summary>
        /// <param name="newAppointment">Datos de la nueva cita.</param>
        public void AppointmentRequest(Domain.Appointment newAppointment)
        {
            if (appointmentList.FirstOrDefault(x => x.student_IdStudent == newAppointment.student_IdStudent) == null)
            {
                using (FEIDBEntities context = new FEIDBEntities())
                {
                    try
                    {
                        appointmentList.Add(newAppointment);
                        int status = Constants.Pending;
                        if (appointmentList.Count == 1)
                        {
                            status = Constants.InProgress;
                            appointmentList.Remove(newAppointment);
                        }
                        var newAppointmentAux = new DataAccess.Appointment()
                        {
                            
                            AttendedDate = DateTime.Now,
                            Duration = 0,
                            Status = (short)status,
                            Student_IdStudent = newAppointment.student_IdStudent,
                            Procedure_IdProcedure = newAppointment.procedure_IdProcedure,
                            NotAttendedReason = "",
                        };
                        
                        context.Appointments.Add(newAppointmentAux);
                        context.SaveChanges();
                        newAppointment.idAppointment = newAppointmentAux.IdAppointment;
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
                appointmentList.Add(newAppointment);

            }
            NotifyClients();
        }

        /// <summary>
        /// Obtiene todas las citas almacenadas.
        /// </summary>
        /// <returns>Lista de citas.</returns>
        public List<Domain.Appointment> GetAllAppointments()
        {
            return appointmentList;
        }

        /// <summary>
        /// Deja una cita específica.
        /// </summary>
        /// <param name="studentId">ID del estudiante.</param>
        /// <param name="reason">Motivo de la cancelación.</param>
        public void LeaveAppointment(string studentId, string reason)
        {
            var appointmentToRemove = appointmentList.FirstOrDefault(x => x.student_IdStudent == studentId);

            if (appointmentToRemove != null)
            {
                var wasFirstAppointment = (appointmentToRemove == appointmentList.First());
                int status = Constants.Pending;
                appointmentList.Remove(appointmentToRemove);
                if (appointmentList.Count == 0)
                {
                    status = Constants.InProgress;
                }
                using (FEIDBEntities context = new FEIDBEntities())
                {
                    try
                    {
                        var existingAppointment = context.Appointments
                                         .Where(a => a.Student_IdStudent == studentId && a.Status == status)
                                         .OrderByDescending(a => a.IdAppointment)
                                         .FirstOrDefault();

                        if (existingAppointment != null)
                        {
                            if(existingAppointment.Status== Constants.InProgress)
                            {
                                var elapsedTime = DateTime.Now - startTime;
                                existingAppointment.Duration = (int)elapsedTime.TotalSeconds;
                            }
                            existingAppointment.Status = (short)Constants.CanceledByStudent;
                            existingAppointment.NotAttendedReason = reason; 
                            context.SaveChanges();
                        }
                        else
                        {
                            Console.WriteLine($"No se encontró ninguna cita con el id de estudiante {studentId}.");
                        }
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

        /// <summary>
        /// Agrega un nuevo cliente a la sesión de citas.
        /// </summary>
        /// <param name="idStudent">ID del estudiante.</param>
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

        /// <summary>
        /// Cancela la cita de un estudiante con el motivo especificado.
        /// </summary>
        /// <param name="idAppointment">ID de la cita a cancelar.</param>
        /// <param name="reason">Motivo de la cancelación.</param>
        public void CancelAppointment(int idAppointment, string reason)
        {
            var appointmentToRemove = appointmentList.FirstOrDefault(x => x.idAppointment == idAppointment);
            
            if (appointmentToRemove != null)
            {
                if (studentList.ContainsKey(appointmentToRemove.student_IdStudent))
                {
                    studentList[appointmentToRemove.student_IdStudent].appointmentCallback.NotifyCancellation(reason);
                }
                appointmentList.Remove(appointmentToRemove);
                
            }
            using (FEIDBEntities context = new FEIDBEntities())
            {
                try
                {
                    var existingAppointment = context.Appointments
                                     .Where(x => x.IdAppointment == idAppointment).FirstOrDefault();

                    if (existingAppointment != null)
                    {
                        existingAppointment.Duration = 0;
                        existingAppointment.Status = (short)Constants.CanceledBySecretary;
                        existingAppointment.NotAttendedReason = reason;
                        context.SaveChanges();
                    }
                    else
                    {
                        Console.WriteLine($"No se encontró ninguna cita con el id de turno {idAppointment}.");
                    }
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
            NotifyClients();
        }
        /// <summary>
        /// Marca una cita como no atendida con el motivo especificado.
        /// </summary>
        /// <param name="idAppointment">ID de la cita a marcar.</param>
        /// <param name="reason">Motivo de no asistencia.</param>
        public void MarkAppointmentAsAttended(int idAppointment)
        {
            var appointmentToRemove = appointmentList.FirstOrDefault(x => x.idAppointment == idAppointment);
            if (appointmentToRemove != null)
            {
                appointmentList.Remove(appointmentToRemove);

            }
            using (FEIDBEntities context = new FEIDBEntities())
            {
                try
                {
                    var existingAppointment = context.Appointments
                                     .Where(x => x.IdAppointment == idAppointment).FirstOrDefault();

                    if (existingAppointment != null)
                    {
                        if (existingAppointment.Status == Constants.InProgress)
                        {
                            var elapsedTime = DateTime.Now - startTime;
                            existingAppointment.Duration = (int)elapsedTime.TotalSeconds;
                        }
                        existingAppointment.Status = (short)Constants.Attended;
                        context.SaveChanges();
                        Console.WriteLine($"Se ha marcado la cita como atendida {idAppointment} del estudiante con matricula: {existingAppointment.Student_IdStudent}.");

                    }
                    else
                    {
                        Console.WriteLine($"No se encontró ninguna cita con el id de turno {idAppointment}.");
                    }
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

            NotifyClients();
        }

        /// <summary>
        /// Marca una cita como no atendida con el motivo especificado.
        /// </summary>
        /// <param name="idAppointment">ID de la cita a marcar.</param>
        /// <param name="reason">Motivo de no asistencia.</param>
        public void MarkAppointmentAsNotAttended(int idAppointment, string reason)
        {
            var appointmentToRemove = appointmentList.FirstOrDefault(x => x.idAppointment == idAppointment);
            if (appointmentToRemove != null)
            {
                appointmentList.Remove(appointmentToRemove);
                
            }
            using (FEIDBEntities context = new FEIDBEntities())
            {
                try
                {
                    var existingAppointment = context.Appointments
                                     .Where(x => x.IdAppointment == idAppointment).FirstOrDefault();

                    if (existingAppointment != null)
                    {
                        existingAppointment.Duration = 0;
                        existingAppointment.Status = (short)Constants.NotAttended;
                        existingAppointment.NotAttendedReason = reason;
                        context.SaveChanges();
                        if (studentList.ContainsKey(existingAppointment.Student_IdStudent))
                        {
                            studentList[existingAppointment.Student_IdStudent].appointmentCallback.NotifyCancellation(reason);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"No se encontró ninguna cita con el id de turno {idAppointment}.");
                    }
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

            NotifyClients();
        }

        /// <summary>
        /// Obtiene un reporte de los estudiantes en cola de espera.
        /// </summary>
        /// <returns>Lista de reportes de estudiantes en cola de espera.</returns>
        public List<Domain.ViewStudentsQueueReport> GetStudentsQueueReport()
        {
            List<Domain.ViewStudentsQueueReport> studentsReport = new List<Domain.ViewStudentsQueueReport> ();
            using (FEIDBEntities context = new FEIDBEntities())
            {
                try
                {
                    
                    var studentsQueue = context.ViewStudentsQueueReports
                    .Where(x => x.Status== Constants.Pending)
                    .ToList();

                    foreach (var student in studentsQueue)
                    {
                        Domain.ViewStudentsQueueReport reportItem = new Domain.ViewStudentsQueueReport()
                        {
                            idAppointment = student.IdAppointment,
                            attendedDate = student.AttendedDate,
                            status = student.Status,
                            idStudent = student.IdStudent,
                            studentName = student.FullName,
                        };
                        studentsReport.Add(reportItem);
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            return studentsReport;
        }

        /// <summary>
        /// Obtiene un reporte de citas por fecha específica.
        /// </summary>
        /// <param name="date">Fecha para la cual se desea obtener el reporte.</param>
        /// <returns>Lista de reportes de citas.</returns>
        public List<Domain.ViewAppointment> GetAppointmentReportByDate(DateTime date)
        {
            List <Domain.ViewAppointment> report = new List<Domain.ViewAppointment> ();
            using (FEIDBEntities context = new FEIDBEntities())
            {
                try
                {
                    var appointments = context.ViewAppointments
                                    .Where(x => DbFunctions.TruncateTime(x.AttendedDate) == date.Date)
                                    .ToList();

                    foreach (var appointment in appointments)
                    {
                        ViewAppointment reportItem = new ViewAppointment()
                        {
                            idAppointment = appointment.IdAppointment,
                            attendedDate = appointment.AttendedDate,
                            duration = (int)appointment.Duration,
                            status = appointment.Status,
                            idStudent = appointment.IdStudent,
                            fullName = appointment.FullName,
                            tutorName = appointment.Name,
                            idTutor = appointment.IdTutor,
                            idProcedure = appointment.IdProcedure,
                            procedureName = appointment.Expr1,
                        };
                        report.Add(reportItem);
                    }
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            return report;
        }
    }


    /// <summary>
    /// Clase parcial que implementa la interfaz IAppointment para gestionar citas y notificaciones.
    /// </summary>
    public partial class Implementations : IProcedure
    {
        public List<Domain.Procedure> GetProcedureList()
        {

            /// <summary>
            /// Obtiene una lista de todos los tipos de tramites disponibles.
            /// </summary>
            /// <returns>Lista de objetos Domain.Procedure que representan los tramites.</returns>
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
