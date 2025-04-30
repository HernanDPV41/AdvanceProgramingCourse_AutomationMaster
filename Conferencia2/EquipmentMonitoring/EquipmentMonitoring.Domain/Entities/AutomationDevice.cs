using EquipmentMonitoring.Domain.Common;
using EquipmentMonitoring.Domain.Entities.Abstract;
using EquipmentMonitoring.Domain.Errors;
using EquipmentMonitoring.Domain.Rules;
using EquipmentMonitoring.Domain.Types;
using EquipmentMonitoring.Domain.ValueObjects;
using FluentResults;

namespace EquipmentMonitoring.Domain.Entities
{
    /// <summary>
    /// Clase base para los dispositivos de automatización industrial.
    /// </summary>
    public abstract class AutomationDevice
        : Entity, IStatefulEquipment
    {

        #region Properties

        /// <summary>
        /// Dirección IP del dispositivo en la red.
        /// </summary>
        public NetworkAddress Address { get; set; }

        /// <summary>
        /// Estado actual del dispositivo.
        /// </summary>
        public EquipmentState State { get; private set; }

        #endregion

        public AutomationDevice(
            Guid id,
            NetworkAddress address,
            EquipmentState state)
            : base(id)
        {
            Address = address;
            State = state;
        }

        /// <summary>
        /// Lleva al dispositivo a un estado de falla.
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        public Result GetIntoFaultState()
        {
            var result = CheckRules(
                new EquipmentCannotGoIntoFaultStateIfIsAlreadyOnIt(State));
            if (result.IsFailed)
                return result;

            State = EquipmentState.Faulted;
            return Result.Ok();
        }

        /// <summary>
        /// Saca el dispositivo del estado de falla.
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        public Result GetOutOfFaultState()
        {
            var result = CheckRules(
                new EquipmentCannotGetOutOfFaultedStateIfItsNotInIt(State));
            if (result.IsFailed)
                return result;

            State = EquipmentState.Idle;
            return Result.Ok();
        }


    }
}
