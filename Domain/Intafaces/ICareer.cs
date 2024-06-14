
using System.Collections.Generic;
using System.ServiceModel;

namespace Domain
{
    /// <summary>
    /// Interfaz que define operaciones relacionadas con carreras académicas.
    /// </summary>
    [ServiceContract]
    public interface ICareer
    {
        /// <summary>
        /// Obtiene una lista de carreras académicas disponibles.
        /// </summary>
        /// <returns>Lista de objetos de tipo Career que representan las carreras disponibles.</returns>
        [OperationContract]
        List<Career> GetCareerList();
    }
}
