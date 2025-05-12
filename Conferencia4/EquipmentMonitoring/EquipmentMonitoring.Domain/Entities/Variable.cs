using EquipmentMonitoring.Domain.Common;
using EquipmentMonitoring.Domain.ValueObjects;

namespace EquipmentMonitoring.Domain.Entities
{
    /// <summary>
    /// Modela una variable de proceso.
    /// </summary>
    public class Variable
        : Entity
    {
        #region Properties

        /// <summary>
        /// Identificador de la unidad a la que pertenece la variable.
        /// </summary>
        public Guid UnitId { get; }

        /// <summary>
        /// Nombre de la variable.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Unidad de medida física de la variable.
        /// </summary>
        public MeasurementUnit MeasurementUnit { get; }

        /// <summary>
        /// Punto de comunicación para obtener el valor de la variable.
        /// </summary>
        public CommunicationNode ValueNode { get; set; }

        #endregion

        /// <summary>
        /// Requerido por EF.
        /// </summary>
        private Variable() { }

        public Variable(
            Guid id,
            Guid unitId,
            string name,
            MeasurementUnit measurementUnit,
            CommunicationNode valueNode)
            : base(id)
        {
            UnitId = unitId;
            Name = name;
            MeasurementUnit = measurementUnit;
            ValueNode = valueNode;
        }
    }
}
