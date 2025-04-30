using FluentResults;

namespace EquipmentMonitoring.Domain.Errors
{
    public static class UnitErrors
    {
        public static Error CannotExecuteExternalOperation =>
            new Error("Cannot execute external operation to this unit.");

        public static Error CannotExecuteOperationIfNotIdle =>
            new Error("Cannot execute operation if unit is not idle.");

        public static Error CannotStopIfNotExecuting =>
            new Error("Cannot stop operation if unit is not executing any.");

    }
}
