using EquipmentMonitoring.Domain.Common;
using EquipmentMonitoring.Domain.Types;

namespace EquipmentMonitoring.Domain.ValueObjects
{
    /// <summary>
    /// Unidad de medida física.
    /// </summary>
    public class MeasurementUnit
        : ValueObject
    {

        #region Properties
        /// <summary>
        /// Magnitud física que representa.
        /// </summary>
        public PhysicalMagnitude PhysicalMagnitude { get; }
        /// <summary>
        /// Símbolo utilizado para la magnitud.
        /// </summary>
        public string Symbol { get; }
        #endregion

        public MeasurementUnit(
            PhysicalMagnitude physicalMagnitude,
            string symbol)
        {
            PhysicalMagnitude = physicalMagnitude;
            Symbol = symbol;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            return new object[] { PhysicalMagnitude, Symbol };
        }
    }
}
