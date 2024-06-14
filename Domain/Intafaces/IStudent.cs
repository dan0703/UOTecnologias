using System.ServiceModel;

namespace Domain
{
    /// <summary>
    /// Interfaz que define operaciones relacionadas con estudiantes.
    /// </summary>
    [ServiceContract]
    public interface IStudent
    {
        /// <summary>
        /// Registra un estudiante en el sistema.
        /// </summary>
        /// <param name="student">Información del estudiante a registrar.</param>
        /// <returns>True si el registro fue exitoso, false si falló.</returns>
        [OperationContract]
        bool RegisterStudent(ViewStudentInfo student);

        /// <summary>
        /// Obtiene el nombre completo de un estudiante dado su ID.
        /// </summary>
        /// <param name="idStudent">ID del estudiante.</param>
        /// <returns>Objeto de tipo Student que contiene el nombre completo del estudiante.</returns>
        [OperationContract]
        Student GetStudentNameById(string idStudent);
    }
}
