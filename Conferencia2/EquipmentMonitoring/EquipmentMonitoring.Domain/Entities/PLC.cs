using EquipmentMonitoring.Domain.Types;
using EquipmentMonitoring.Domain.ValueObjects;

namespace EquipmentMonitoring.Domain.Entities
{
    /// <summary>
    /// Controlador lógico programable.
    /// </summary>
    public class PLC
        : AutomationDevice
    {

        public PLC(
            Guid id,
            NetworkAddress address,
            EquipmentState state)
            : base(id,address, state)
        {

        }
    }
}
