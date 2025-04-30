using EquipmentMonitoring.Domain.Types;

namespace EquipmentMonitoring.Domain.Records
{

    /// <summary>
    /// Registro de un cambio en el estado de un equipamiento.
    /// </summary>
    /// <param name="EquipmentId"></param>
    /// <param name="OccurringTime"></param>
    /// <param name="NewState"></param>
    public record EquipmentStateChangeRecord(
         Guid EquipmentId,
         DateTime OccurringTime,
         EquipmentState NewState);

}
