using EquipmentMonitoring.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// Nombre de la operación.
        /// </summary>
        public string Name { get; }

        #endregion

        public Operation(
            Guid id, 
            string name)
            : base(id)
        {
            Name = name;
        }
    }
}
