using FluentResults;

namespace EquipmentMonitoring.Domain.Errors
{
    public static class IStatefulEquipmentErrors
    {
        public static Error EquipmentIsAlreadyFaulted =>
            new Error("Equipment is already in faulted state.");

        public static Error EquipmentIsNotFaulted =>
            new Error("Equipment is not in faulted state.");
    }
}
