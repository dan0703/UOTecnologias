using System.Collections.Generic;
using System.ServiceModel;


namespace Domain
{
    /// <summary>
    /// Interfaz que define operaciones relacionadas con tutores.
    /// </summary>
    [ServiceContract]
    public interface ITutor
    {
        /// <summary>
        /// Obtiene la lista de todos los tutores registrados en el sistema.
        /// </summary>
        /// <returns>Lista de objetos de tipo Tutor.</returns>
        [OperationContract]
        List<Tutor> GetTutorsList();

        /// <summary>
        /// Obtiene un tutor específico por su ID.
        /// </summary>
        /// <param name="idTutor">ID del tutor a buscar.</param>
        /// <returns>Objeto de tipo Tutor correspondiente al ID proporcionado.</returns>
        [OperationContract]
        Tutor GetTutorById(int idTutor);
    }
}
