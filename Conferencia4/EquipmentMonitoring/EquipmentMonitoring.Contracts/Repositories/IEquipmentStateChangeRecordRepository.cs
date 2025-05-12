using EquipmentMonitoring.Domain.Records;

namespace EquipmentMonitoring.Contracts.Repositories
{
    /// <summary>
    /// Define las funcionalidades de un repositorio de registros de cambio de estado de equipamiento.
    /// </summary>
    public interface IEquipmentStateChangeRecordRepository
    {
        /// <summary>
        /// Añade un registro de cambio de estado a base de datos.
        /// </summary>
        Task AddAsync(EquipmentStateChangeRecord record);
        /// <summary>
        /// Obtiene todos los registros de cambio de estado en un rango de fechas específico.
        /// </summary>
        Task<IEnumerable<EquipmentStateChangeRecord>> GetEquipmentStateChangeRecords(DateTime start, DateTime end);
    }
}
