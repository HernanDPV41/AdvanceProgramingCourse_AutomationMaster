using EquipmentMonitoring.Domain.Entities;

namespace EquipmentMonitoring.Contracts.Repositories
{
    /// <summary>
    /// Define las funcionalidades de un repositorio de variables.
    /// </summary>
    public interface IVariableRepository
    {
        /// <summary>
        /// Añade una variable a base de datos.
        /// </summary>
        Task AddAsync(Variable variable);
        /// <summary>
        /// Obtiene una variable a partir de su Id.
        /// </summary>
        Task<Variable?> GetByIdAsync(Guid id);
        /// <summary>
        /// Obtiene todas las Variables a partir de la unidad a la que pertenecen.
        /// </summary>
        Task<IEnumerable<Variable>> GetVariablesByUnitAsync(Guid unitId);
        /// <summary>
        /// Actualiza la información de una variable.
        /// </summary>
        void Update(Variable variable);
        /// <summary>
        /// Elimina una variable a partir de su Id.
        /// </summary>
        void DeleteById(Guid id);
    }
}
