using DataAccess;
using Domain;
using FEIService;
using log4net;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Validation;
using System.Diagnostics;
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
        private static string errorEntityExceptionMessage = "Error al acceder a la base de datos(EntityException)";
        private static readonly ILog log = LogManager.GetLogger(typeof(Implementations));
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
                       
                        if (foundUser!=null && foundUser.Password == password)
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
                catch (EntityException ex)
                {
                    log.Error(errorEntityExceptionMessage, ex);
                    Console.WriteLine(ex);
                }
                catch (Exception ex)
                {
                    log.Error("Error inesperado en LogIn", ex);
                    Console.WriteLine(ex);

                }
            }
            Console.WriteLine(studentInfo.fullName);

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
                    if (foundTutor!=null)
                    {
                        tutor = new Domain.Tutor()
                        {
                            idTutor = foundTutor.IdTutor,
                            fullName = foundTutor.Name,
                        };
                    }
                }
                catch (EntityException ex)
                {
                    log.Error(errorEntityExceptionMessage, ex);
                }
                catch (Exception ex)
                {
                    log.Error("Error inesperado en GetTutorById", ex);
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
                    log.Error(errorEntityExceptionMessage, ex);
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    log.Error("Error inesperado en GetTutorsList", ex);
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
                    log.Error(errorEntityExceptionMessage, ex);
                }
                catch (Exception ex)
                {
                    log.Error("Error inesperado en GetCareerList", ex);
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
                    if(foundStudent!= null)
                    {
                        student = new Domain.Student()
                        {
                            idStudent = idStudent,
                            matricula = foundStudent.Matricula,
                            fullName = foundStudent.FullName
                        };
                    }
                }
                catch (EntityException ex)
                {
                    log.Error(errorEntityExceptionMessage, ex);
                }
                catch (Exception ex)
                {
                    log.Error("Error inesperado en GetStudentNameById", ex);
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
                                Console.WriteLine("Ya existe un registro con esa matricula");
                                return isSuccessful;
                            }

                            context.Students.Add(newStudent);
                            context.SaveChanges();

                            dbContextTransaction.Commit();
                            isSuccessful = true;
                        }
                        catch (DbEntityValidationException ex)
                        {
                            dbContextTransaction.Rollback();
                            log.Error(errorEntityExceptionMessage, ex);
                        }
                        catch (Exception ex)
                        {
                            log.Error("Error inesperado en RegisterStudent", ex);
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
        private static readonly System.Threading.Timer timer = new System.Threading.Timer(TimerElapsed, null, Timeout.Infinite, 1000);
        private static bool isTimerStopped = false;
        private static readonly Stopwatch stopwatch = Stopwatch.StartNew();

        /// <summary>
        /// Constructor publico de la clase Implementations.
        /// </summary>
        public Implementations()
        {
            
        }

        /// <summary>
        /// Método para iniciar el temporizador.
        /// </summary>
        private static void StartTimer()
        {
            isTimerStopped = false;
            stopwatch.Restart();
            timer.Change(0, 1000); 
        }

        /// <summary>
        /// Método para detener el temporizador.
        /// </summary>
        private static void StopTimer()
        {
            stopwatch.Stop();
            timer.Change(Timeout.Infinite, Timeout.Infinite);
        }

        /// <summary>
        /// Método invocado por el temporizador para notificar el tiempo transcurrido a los clientes.
        /// </summary>
        private static void TimerElapsed(object state)
        {
            if (!isTimerStopped)
            {
                var elapsedTime = stopwatch.Elapsed;
                try
                {
                    foreach (var student in studentList.Values)
                    {
                        student.appointmentCallback.UpdateTimer(elapsedTime);
                    }
                }
                catch (Exception ex)
                {
                    log.Error("Error inesperado en TimerElapsed", ex);
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
                try
                {
                    studentList[student].appointmentCallback.SetAppointments(appointmentList);
                }
                catch (Exception ex)
                {
                    studentList.Remove(student);
                    log.Error("Error inesperado, canal de callback de cliente no disponible", ex);

                }
            }
        }
        /// <summary>
        /// Metodo realizado unicamente para razones de pruebas unitaras.
        /// Registra un nuevo objeto tipo Appointment en la lista AppointmentList y registrarlo en base de datos
        /// </summary>
        /// <param name="newAppointment">Datos de la nueva cita.</param>
        /// 
        public int AddAppointmentToAppointmentList(Domain.Appointment newAppointment)
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
                        Status = (short)newAppointment.status,
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
                    log.Error(errorEntityExceptionMessage, ex);
                }
                catch (Exception ex)
                {
                    log.Error("Error inesperado en AppointmentRequest", ex);
                }
                return newAppointment.idAppointment;
            }
        }
        /// <summary>
        /// Registra una nueva cita.
        /// </summary>
        /// <param name="newAppointment">Datos de la nueva cita.</param>
        /// 
        public void AppointmentRequest(Domain.Appointment newAppointment)
        {
            if (appointmentList.Find(x => x.student_IdStudent == newAppointment.student_IdStudent) == null)
            {
                using (FEIDBEntities context = new FEIDBEntities())
                {
                    try
                    {
                        appointmentList.Add(newAppointment);
                        AppointmentStatus status = AppointmentStatus.Pending;
                        if (appointmentList.Count == 1)
                        {
                            status = AppointmentStatus.InProgress;
                            
                        }
                        appointmentList.Remove(newAppointment);
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
                        log.Error(errorEntityExceptionMessage, ex);
                    }
                    catch (Exception ex)
                    {
                        log.Error("Error inesperado en AppointmentRequest", ex);
                    }
                }
                appointmentList.Add(newAppointment);

                if (appointmentList.Count == 1) 
                {
                    StartTimer();
                }

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
        /// Determina el estado de la cita que se desea abandonar.
        /// </summary>
        private AppointmentStatus SetStatus()
        {
            AppointmentStatus status = AppointmentStatus.Pending;
            if (appointmentList.Count == 0)
            {
                status = AppointmentStatus.InProgress;
            }
            return status;
        }

        /// <summary>
        /// Abandona una cita específica.
        /// </summary>
        /// <param name="studentId">ID del estudiante.</param>
        /// <param name="reason">Motivo de la cancelación.</param>
        public void LeaveAppointment(string studentId, string reason)
        {
            var appointmentToRemove = appointmentList.Find(x => x.student_IdStudent == studentId);
            appointmentList.Remove(appointmentToRemove);

            AppointmentStatus status = SetStatus();

            if (appointmentToRemove != null)
            {
                var wasFirstAppointment = (appointmentToRemove == appointmentList.FirstOrDefault());

                using (FEIDBEntities context = new FEIDBEntities())
                {
                    try
                    {
                        var existingAppointment = context.Appointments
                                         .Where(a => a.Student_IdStudent == studentId && a.Status == (int)status)
                                         .OrderByDescending(a => a.IdAppointment)
                                         .FirstOrDefault();

                        if (existingAppointment != null)
                        {
                            if(existingAppointment.Status == (int)AppointmentStatus.InProgress)
                            {
                                var elapsedTime = stopwatch.Elapsed;
                                existingAppointment.Duration = (int)elapsedTime.TotalSeconds;
                            }
                            existingAppointment.Status = (short)AppointmentStatus.CanceledByStudent;
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
                        log.Error("Error al acceder a la base de datos ", ex);
                    }
                    catch (Exception ex)
                    {
                        log.Error("Error inesperado en LeaveAppointment", ex);
                    }
                }
                StopStartTimer(wasFirstAppointment);
                
            }
            NotifyClients();
        }

        /// <summary>
        /// Inicia o detiene el timer con el tiempo transcurrido de la cita en progreso
        /// </summary>
        /// <param name="wasFirstAppointment">ID del estudiante.</param>
        private static void StopStartTimer(bool wasFirstAppointment)
        {
            if (appointmentList.Count == 0)
            {
                Console.WriteLine("stop");
                isTimerStopped = true;
                StopTimer();

            }
            else if (wasFirstAppointment)
            {
                StartTimer();
            }
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
            
            var appointmentToRemove = appointmentList.Find(x => x.idAppointment == idAppointment);
            
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
                        existingAppointment.Status = (short)AppointmentStatus.CanceledBySecretary;
                        existingAppointment.NotAttendedReason = reason;
                        context.SaveChanges();
                        Console.WriteLine("Cita cancelada con éxito.");
                    }
                    else
                    {
                        Console.WriteLine($"No se encontró ninguna cita con el id de turno {idAppointment}.");
                    }
                }
                catch (DbEntityValidationException ex)
                {
                    log.Error(errorEntityExceptionMessage, ex);
                }
                catch (Exception ex)
                {
                    log.Error("Error inesperado en CancelAppointment", ex);
                }
            }
            NotifyClients();
        }
        /// <summary>
        /// Marca una cita como no atendida con el motivo especificado.
        /// </summary>
        /// <param name="idAppointment">ID de la cita a marcar.</param>
        public void MarkAppointmentAsAttended(int idAppointment)
        {
            var appointmentToRemove = appointmentList.Find(x => x.idAppointment == idAppointment);
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
                        if (existingAppointment.Status == (int)AppointmentStatus.InProgress)
                        {
                            var elapsedTime = stopwatch.Elapsed;
                            existingAppointment.Duration = (int)elapsedTime.TotalSeconds;
                        }
                        existingAppointment.Status = (short)AppointmentStatus.Attended;
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
                    log.Error(errorEntityExceptionMessage, ex);
                }
                catch (Exception ex)
                {
                    log.Error("Error inesperado en MarkAppointmentAsAttended", ex);
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
            var appointmentToRemove = appointmentList.Find(x => x.idAppointment == idAppointment);
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
                        existingAppointment.Status = (short)AppointmentStatus.NotAttended;
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
                    log.Error(errorEntityExceptionMessage, ex);
                }
                catch (Exception ex)
                {
                    log.Error("Error inesperado en MarkAppointmentAsNotAttended", ex);
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
                    .Where(x => x.Status== (int)AppointmentStatus.Pending)
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
                catch (DbEntityValidationException ex)
                {
                    log.Error(errorEntityExceptionMessage, ex);
                }
                catch (Exception ex)
                {
                    log.Error("Error inesperado en GetStudentsQueueReport", ex);
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
                        .Where(x => DbFunctions.TruncateTime(x.AttendedDate) == date.Date && x.Status == 1)
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
                catch (DbEntityValidationException ex)
                {
                    log.Error(errorEntityExceptionMessage, ex);
                }
                catch (Exception ex)
                {
                    log.Error("Error inesperado en GetAppointmentReportByDate", ex);
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
        /// <summary>
        /// Obtiene una lista de todos los tipos de tramites disponibles.
        /// </summary>
        /// <returns>Lista de objetos Domain.Procedure que representan los tramites.</returns>
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
                catch (DbEntityValidationException ex)
                {
                    log.Error(errorEntityExceptionMessage, ex);
                }
                catch (Exception ex)
                {
                    log.Error("Error inesperado en GetProcedureList", ex);
                }
            }
            return procedureList;
        }
    }
}
