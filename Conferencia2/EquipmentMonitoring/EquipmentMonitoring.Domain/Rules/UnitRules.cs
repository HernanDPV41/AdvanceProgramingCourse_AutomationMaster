using EquipmentMonitoring.Domain.Common;
using EquipmentMonitoring.Domain.Entities;
using EquipmentMonitoring.Domain.Errors;
using EquipmentMonitoring.Domain.Types;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentMonitoring.Domain.Rules
{

    public record UnitCannotExecuteExternalOperation(
       Operation TargetOperation,
       IEnumerable<Operation> InternalOperations)
       : IBusinessRule
    {
        public Result CheckRule()
        {
            if (!InternalOperations.Contains(TargetOperation))
                return Result.Fail(UnitErrors.CannotExecuteExternalOperation);
            return Result.Ok();
        }
    }

    public record UnitCannotExecuteOperationIfNotInIdleState(
        EquipmentState CurrentState)
       : IBusinessRule
    {
        public Result CheckRule()
        {
            if (CurrentState != EquipmentState.Idle)
                return Result.Fail(UnitErrors.CannotExecuteOperationIfNotIdle);
            return Result.Ok();
        }
    }

    public record UnitCannotStopOperationIfItsNotExecutingAny(
        EquipmentState CurrentState)
       : IBusinessRule
    {
        public Result CheckRule()
        {
            if (CurrentState != EquipmentState.Executing)
                return Result.Fail(UnitErrors.CannotStopIfNotExecuting);
            return Result.Ok();
        }
    }
}
