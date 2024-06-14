using System.Collections.Generic;
using System.ServiceModel;

namespace Domain
{
    /// <summary>
    /// Interfaz que define operaciones relacionadas con tramites.
    /// </summary>
    [ServiceContract]
    public interface IProcedure
    {
        /// <summary>
        /// Obtiene una lista de tramites disponibles.
        /// </summary>
        /// <returns>Lista de objetos de tipo Procedure que representan los tipos de tramites disponibles.</returns>
        [OperationContract]
        List<Procedure> GetProcedureList();
    }
}
