using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text.RegularExpressions;
using FEIService;
using Service;

namespace Host
{
    /// <summary>
    /// Clase principal del programa de administración del sistema.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Punto de entrada principal del programa.
        /// </summary>
        /// <param name="args">Argumentos de línea de comandos (no utilizados).</param>
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(Implementations)))
            {
                // Iniciar el host del servicio
                host.Open();

                // Mostrar el menú principal
                MainMenu();
            }
        }

        /// <summary>
        /// Muestra el menú principal y gestiona las opciones seleccionadas por el usuario.
        /// </summary>
        private static void MainMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Menu de Administracion del Sistema:");
                Console.WriteLine("1. Registro de usuarios");
                Console.WriteLine("2. Marcar asunto como atendido");
                Console.WriteLine("3. Marcar asunto como no atendido y especificar la causa");
                Console.WriteLine("4. Reportar lista de estudiantes en cola");
                Console.WriteLine("5. Anular un turno especificando la causa");
                Console.WriteLine("6. Brindar reportes por periodo de fecha de estudiantes atendidos");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opción: ");

                var input = Console.ReadLine();
                if (int.TryParse(input, out int option))
                {
                    switch (option)
                    {
                        case 1:
                            RegisterUsers();  // Llama al método para registrar usuarios
                            break;
                        case 2:
                            MarkAsAttended(); // Llama al método para marcar como atendidoa una cita
                            break;
                        case 3:
                            MarkAsNotAttended(); // Llama al método para marcar como no atendida una cita
                            break;
                        case 4:
                            ReportQueue(); // Llama al método para reportar la lista de estudiantes en cola
                            break;
                        case 5:
                            CancelAppointment(); // Llama al método para cancelar un turno
                            break;
                        case 6:
                            GenerateReportsByDate(); // Llama al método para generar reportes por fecha
                            break;
                        case 0:
                            return; // Sale del programa
                        default:
                            Console.WriteLine("Opción inválida. Presione cualquier tecla para intentar nuevamente...");
                            Console.ReadKey();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Entrada no válida. Presione cualquier tecla para intentar nuevamente...");
                    Console.ReadKey();
                }
            }
        }

        /// <summary>
        /// Genera reportes de citas por fecha especificada por el usuario.
        /// </summary>
        private static void GenerateReportsByDate()
        {
            DateTime reportDate = DateTime.MinValue;
            bool isValidDate = false;

            // Solicitar y validar la fecha para el reporte
            while (!isValidDate)
            {
                Console.Write("Ingrese la fecha para el reporte (yyyy-MM-dd): ");
                string inputDate = Console.ReadLine();

                if (DateTime.TryParseExact(inputDate, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out reportDate))
                {
                    isValidDate = true;
                }
                else
                {
                    Console.WriteLine("Fecha inválida. Por favor, ingrese la fecha en el formato correcto (yyyy-MM-dd).");
                }
            }
            Implementations serviceInstance = new Implementations();
            List<Domain.ViewAppointment> reportData= new List<Domain.ViewAppointment>();
            try
            {
                reportData = serviceInstance.GetAppointmentReportByDate(reportDate); // Obtener el reporte de citas por fecha
            
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener el reporte: {ex.Message}");
            }
            // Mostrar los datos del reporte en la consola
            if (reportData.Count > 0)
            {
                Console.WriteLine("Reporte de citas:");
                foreach (var appointment in reportData)
                {
                    string statusName = GetStatusName(appointment.status);
                    Console.WriteLine($"ID: {appointment.idAppointment}, Fecha: {appointment.attendedDate}, Estudiante: {appointment.fullName}, Matricula: {appointment.idStudent}, Estado: {statusName}");
                }
            }
            else
            {
                Console.WriteLine("No se encontraron citas para la fecha especificada.");
            }
            PressAnyKey(); // Esperar a que el usuario presione una tecla

        }

        /// <summary>
        /// Obtiene el nombre asociado a un estado de cita según su código.
        /// </summary>
        /// <param name="status">Código del estado de la cita.</param>
        /// <returns>Nombre asociado al estado de la cita.</returns>
        private static string GetStatusName(int status)
        {
            string statusName;
            switch (status)
            {
                case 0:
                    statusName = "En espera";
                    break;
                case 1:
                    statusName = "Atendido";
                    break;
                case 2:
                    statusName = "Cancelado por el studiante";
                    break;
                case 3:
                    statusName = "Cancelado por secretaria";
                    break;
                case 4:
                    statusName = "En progreso";
                    break;
                case 5:
                    statusName = "No atendido";
                    break;
                default:
                    statusName = "desconocido";
                    break;
            }
            return statusName;
        }

        /// <summary>
        /// Cancela una cita especificada por el usuario, solicitando el ID y la razón de cancelación.
        /// </summary>
        private static void CancelAppointment()
        {
            Console.Write("Ingrese el ID de la cita a cancelar: ");
            int idAppointment;
            while (!int.TryParse(Console.ReadLine(), out idAppointment))
            {
                Console.WriteLine("Entrada no válida. Por favor, ingrese un ID de cita válido.");
                Console.Write("Ingrese el ID de la cita a cancelar: ");
            }

            Console.Write("Ingrese la razón para la cancelación: ");
            string reason = Console.ReadLine();
            while (string.IsNullOrEmpty(reason))
            {
                Console.WriteLine("El motivo no puede estar vacío. Por favor, ingrese el motivo nuevamente:");
                reason = Console.ReadLine();
            }
            Implementations serviceInstance = new Implementations();
            try
            {
                serviceInstance.CancelAppointment(idAppointment, reason); // Llamar al servicio para cancelar la cita
                Console.WriteLine("Cita cancelada con éxito.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ha ocurrido un error mientras se cancelaba la cita." + ex.Message);
            }
            PressAnyKey(); // Esperar a que el usuario presione una tecla
        }

        /// <summary>
        /// Genera un reporte de la lista de estudiantes en cola para ser atendidos.
        /// </summary>
        private static void ReportQueue()
        {
            Implementations serviceInstance = new Implementations();
            List<Domain.ViewStudentsQueueReport> reportData = new List<Domain.ViewStudentsQueueReport>();
            try
            {
                reportData = serviceInstance.GetStudentsQueueReport(); // Obtener el reporte de estudiantes en cola
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener el reporte: {ex.Message}");
            }

            // Mostrar los datos del reporte en la consola
            if (reportData.Count > 0)
            {
                Console.WriteLine("Reporte de citas:");
                foreach (var appointment in reportData)
                {
                    string statusName = GetStatusName(appointment.status);
                    Console.WriteLine($"ID: {appointment.idAppointment}, Fecha: {appointment.attendedDate}, Estudiante: {appointment.studentName}, Matricula: {appointment.idStudent}, Estado: {statusName}");
                }
            }
            else
            {
                Console.WriteLine("No se encontraron citas pendientes");
            }
            PressAnyKey(); // Esperar a que el usuario presione una tecla
        }

        /// <summary>
        /// Marca una cita como no atendida, solicitando el ID y la razón de no atención.
        /// </summary>
        private static void MarkAsNotAttended()
        {
            int idAppointment;
            while (!int.TryParse(Console.ReadLine(), out idAppointment))
            {
                Console.WriteLine("Entrada no válida. Por favor, ingrese un ID de cita válido.");
                Console.Write("Ingrese el ID de la cita a marcar como atendida: ");
            }
            Console.Write("Ingrese la el motivo del por que no la reservación no fue atendida: ");
            string reason = Console.ReadLine();
            while (string.IsNullOrEmpty(reason))
            {
                Console.WriteLine("El motivo no puede estar vacío. Por favor, ingrese el motivo nuevamente:");
                reason = Console.ReadLine();
            }
            Implementations serviceInstance = new Implementations();
            serviceInstance.MarkAppointmentAsNotAttended(idAppointment, reason); // Marcar la cita como no atendida
            PressAnyKey(); // Esperar a que el usuario presione una tecla
        }

        /// <summary>
        /// Marca una cita como atendida, solicitando el ID de la cita.
        /// </summary>
        private static void MarkAsAttended()
        {
            Console.Write("Ingrese el ID de la cita a marcar como atendida: ");
            int idAppointment;
            while (!int.TryParse(Console.ReadLine(), out idAppointment))
            {
                Console.WriteLine("Entrada no válida. Por favor, ingrese un ID de cita válido.");
                Console.Write("Ingrese el ID de la cita a marcar como atendida: ");
            }

            Implementations serviceInstance = new Implementations();
            serviceInstance.MarkAppointmentAsAttended(idAppointment);// Marcar la cita como atendida
            PressAnyKey(); // Esperar a que el usuario presione una tecla
        }

        /// <summary>
        /// Registra un nuevo estudiante en el sistema, solicitando información como nombre, matrícula, contraseña, etc.
        /// </summary>
        private static void RegisterUsers()
        {
            Console.Write("Ingrese el nombre completo del estudiante: ");
            string studentName = Console.ReadLine();
            while (string.IsNullOrEmpty(studentName))
            {
                Console.WriteLine("El nombre no puede estar vacío. Por favor, ingrese el nombre nuevamente:");
                studentName = Console.ReadLine();
            }

            Console.Write("Ingrese la matricula del estudiante: ");
            string studentId = Console.ReadLine();
            while (string.IsNullOrEmpty(studentId) || Regex.IsMatch(studentId, @"^zs\d{8}$")) // Validación de la matrícula
            {
                Console.WriteLine("Por favor, ingrese una matricula valida:");
                studentId = Console.ReadLine();
            }

            Console.Write("Ingrese la contraseña del estudiante: ");
            string password = Console.ReadLine();
            while (string.IsNullOrEmpty(password))
            {
                Console.WriteLine("La mtricula no puede estar vacía. Por favor, ingrese el nombre nuevamente:");
                password = Console.ReadLine();
            }

            Console.Write("Ingrese el id de la carrera del estudiante:");
            int idEducationalProgram;
            while (!int.TryParse(Console.ReadLine(), out idEducationalProgram))
            {
                Console.WriteLine("Entrada no válida. Por favor, ingrese un ID de carrera válido.");
                Console.Write("Ingrese el ID de la carrera: ");
            }

            Console.Write("Ingrese el id del tutor del estudiante:");
            int idTutor;
            while (!int.TryParse(Console.ReadLine(), out idTutor))
            {
                Console.WriteLine("Entrada no válida. Por favor, ingrese un ID tutor válido.");
                Console.Write("Ingrese el ID del tutor: ");
            }

            // Crear objeto con la información del estudiante
            Domain.ViewStudentInfo studentInfo = new Domain.ViewStudentInfo()
            {
                password = Complements.EncryptPassword(password),
                fullName = studentName,
                idStudent = studentId,
                idCareer = idEducationalProgram,
                idTutor = idTutor,
            };
            Implementations serviceInstance = new Implementations();
            if (serviceInstance.RegisterStudent(studentInfo))
            {
                Console.WriteLine("Estudiante registrado con exito");
            }
            else
            {
                Console.WriteLine("No se ha podido registrar al estudiante");
            }
            PressAnyKey(); // Esperar a que el usuario presione una tecla

        }

        /// <summary>
        /// Muestra un mensaje para presionar cualquier tecla para continuar.
        /// </summary>
        private static void PressAnyKey()
        {
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}
