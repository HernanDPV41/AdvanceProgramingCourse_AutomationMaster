using EquipmentMonitoring.Application.Common;

namespace EquipmentMonitoring.Application.Commands.Units.CreateUnit
{
    public sealed record CreateUnitCommand(
        string Name,
        string Code)
        : ICommand;

}
