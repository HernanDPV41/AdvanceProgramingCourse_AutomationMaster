using EquipmentMonitoring.Domain.Common;
using EquipmentMonitoring.Domain.Entities.Abstract;
using EquipmentMonitoring.Domain.Rules;
using EquipmentMonitoring.Domain.Types;
using EquipmentMonitoring.Domain.ValueObjects;
using FluentResults;

namespace EquipmentMonitoring.Domain.Entities
{
    /// <summary>
    /// Modela un equipo automático.
    /// </summary>
    public class Unit
        : Entity, IStatefulEquipment
    {

        #region Properties

        /// <summary>
        /// Nombre del equipo.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Código del equipo.
        /// </summary>
        public UnitIdentificationCode Code { get; set; }
        /// <summary>
        /// Estado actual del equipo.
        /// </summary>
        public EquipmentState State { get; private set; } = EquipmentState.Idle;
        /// <summary>
        /// Operaciones que puede ejecutar.
        /// </summary>
        public List<Operation> Operations { get; } = new();
        /// <summary>
        /// Variables asociadas al proceso.
        /// </summary>
        public List<Variable> Variables { get; } = new();
        /// <summary>
        /// Operación activa, <see langword="null"/> si no hay ninguna activa.
        /// </summary>
        public Operation? ActiveOperation { get; private set; } = null;
        /// <summary>
        /// Identificador de la operación activa.
        /// </summary>
        public Guid? ActiveOperationId { get; private set; } = null;
        /// <summary>
        /// Dispositivos de automatización asociados a la unidad.
        /// </summary>
        public List<AutomationDevice> AutomationDevices { get; private set; } = new();

        #endregion

        /// <summary>
        /// Requerido por EF.
        /// </summary>
        private Unit() { }

        public Unit(
            Guid id,
            string name,
            UnitIdentificationCode code)
            : base(id)
        {
            Name = name;
            Code = code;
        }

        /// <summary>
        /// Inicia la ejecución de una operación en la unidad.
        /// </summary>
        /// <param name="operation"></param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public Result StartOperation(Operation operation)
        {
            var result = CheckRules(
                new UnitCannotExecuteExternalOperation(operation, Operations),
                new UnitCannotExecuteOperationIfNotInIdleState(State));
            if (result.IsFailed)
                return result;

            ActiveOperation = operation;
            State = EquipmentState.Executing;
            return Result.Ok();
        }

        /// <summary>
        /// Detiene la ejecución de una operación.
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        public Result StopOperation()
        {
            var result = CheckRules(
              new UnitCannotStopOperationIfItsNotExecutingAny(State));
            if (result.IsFailed)
                return result;

            State = EquipmentState.Idle;
            ActiveOperation = null;
            return Result.Ok();
        }

        /// <summary>
        /// Lleva al equipo a un estado de falla.
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        public Result GetIntoFaultState()
        {
            var result = CheckRules(
               new EquipmentCannotGoIntoFaultStateIfIsAlreadyOnIt(State));
            if (result.IsFailed)
                return result;

            if (State == EquipmentState.Executing)
                StopOperation();

            State = EquipmentState.Faulted;
            return Result.Ok();
        }

        /// <summary>
        /// Saca el equipo de estado de falla.
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
