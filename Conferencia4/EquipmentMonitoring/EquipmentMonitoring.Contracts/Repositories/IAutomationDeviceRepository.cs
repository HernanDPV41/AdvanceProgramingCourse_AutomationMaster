using EquipmentMonitoring.Domain.Entities;

namespace EquipmentMonitoring.Contracts.Repositories
{
    /// <summary>
    /// Define las funcionalidades de un repositorio de operación.
    /// </summary>
    public interface IAutomationDeviceRepository
    {
        /// <summary>
        /// Añade un dispositivo de automatización a base de datos.
        /// </summary>
        Task AddAsync(AutomationDevice automationDevice);
        /// <summary>
        /// Obtiene un dispositivo de automatización a partir de su Id.
        /// </summary>
        Task<AutomationDevice> GetByIdAsync(Guid id);
        /// <summary>
        /// Obtiene todos los dispositivos de automatización a partir de la unidad a la que se relacionan.
        /// </summary>
        Task<IEnumerable<AutomationDevice>> GetAutomationDeviceByUnitAsync(Guid unitId);
        /// <summary>
        /// Actualiza la información de un dispositivo de automatización.
        /// </summary>
        void Update(AutomationDevice automationDevice);
        /// <summary>
        /// Elimina un dispositivo de automatización a partir de su Id.
        /// </summary>
        void DeleteById(Guid id);
    }
}
