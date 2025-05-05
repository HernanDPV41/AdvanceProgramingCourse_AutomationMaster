using EquipmentMonitoring.Domain.Common;
using EquipmentMonitoring.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// Nombre de la variable.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Unidad de medida física de la variable.
        /// </summary>
        public string MeasurementUnit { get; }

        /// <summary>
        /// Punto de comunicación para obtener el valor de la variable.
        /// </summary>
        public CommunicationNode ValueNode { get; set; }

        #endregion

        public Variable(
            Guid id,
            string name, 
            string measurementUnit, 
            CommunicationNode valueNode)
            : base(id)
        {
            Name = name;
            MeasurementUnit = measurementUnit;
            ValueNode = valueNode;
        }
    }
}
