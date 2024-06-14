using System.ServiceModel;

namespace Domain
{
    /// <summary>
    /// Interfaz que define operaciones relacionadas con la información de una vista con la informacion de estudiantes.
    /// </summary>
    [ServiceContract]
    public interface IViewStudentInfo
    {
        /// <summary>
        /// Permite a un estudiante iniciar sesión en el sistema.
        /// </summary>
        /// <param name="studentId">ID del estudiante.</param>
        /// <param name="password">Contraseña del estudiante.</param>
        /// <returns>Información del estudiante si el inicio de sesión es exitoso; de lo contrario, null.</returns>
        [OperationContract]
        ViewStudentInfo LogIn(string studentId, string password);
    }
}
