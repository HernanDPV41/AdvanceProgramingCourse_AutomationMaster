using EquipmentMonitoring.Domain.Common;

namespace EquipmentMonitoring.Domain.Entities
{
    /// <summary>
    /// Modela la operación de un equipo automático.
    /// </summary>
    public class Operation
        : Entity
    {

        #region Properties

        /// <summary>
        /// Identificador de la unidad a la que pertenece la operación.
        /// </summary>
        public Guid UnitId { get; }

        /// <summary>
        /// Nombre de la operación.
        /// </summary>
        public string Name { get; }

        #endregion

        /// <summary>
        /// Requerido por EF.
        /// </summary>
        private Operation()
        {
            
        }

        public Operation(
            Guid id,
            Guid unitId,
            string name)
            : base(id)
        {
            UnitId = unitId;
            Name = name;
        }
    }
}
