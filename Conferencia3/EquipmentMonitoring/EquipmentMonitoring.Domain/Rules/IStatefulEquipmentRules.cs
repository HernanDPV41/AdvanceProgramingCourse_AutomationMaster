using EquipmentMonitoring.Domain.Common;
using EquipmentMonitoring.Domain.Errors;
using EquipmentMonitoring.Domain.Types;
using FluentResults;

namespace EquipmentMonitoring.Domain.Rules
{
    public record EquipmentCannotGoIntoFaultStateIfIsAlreadyOnIt(
        EquipmentState CurrentState)
        : IBusinessRule
    {
        public Result CheckRule()
        {
            if (CurrentState == EquipmentState.Faulted)
                return Result.Fail(IStatefulEquipmentErrors.EquipmentIsAlreadyFaulted);
            return Result.Ok();
        }
    }

    public record EquipmentCannotGetOutOfFaultedStateIfItsNotInIt(
        EquipmentState CurrentState)
        : IBusinessRule
    {
        public Result CheckRule()
        {
            if (CurrentState != EquipmentState.Faulted)
                return Result.Fail(IStatefulEquipmentErrors.EquipmentIsNotFaulted);
            return Result.Ok();
        }
    }


}
