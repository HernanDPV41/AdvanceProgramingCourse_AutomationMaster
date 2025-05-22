using EquipmentMonitoring.Application.Common;

namespace EquipmentMonitoring.Application.Queries
{
    public sealed record GetAllUnitsQuery()
        : IQuery<IEnumerable<Domain.Entities.Unit>>;
}
