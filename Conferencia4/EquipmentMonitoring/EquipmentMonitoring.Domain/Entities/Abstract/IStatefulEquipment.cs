using EquipmentMonitoring.Domain.Types;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentMonitoring.Domain.Entities.Abstract
{
    /// <summary>
    /// Describe las propiedades y métodos de un equipamiento con estados de ejecución.
    /// </summary>
    public interface IStatefulEquipment
    {
        /// <summary>
        /// Estado de ejecución.
        /// </summary>
        EquipmentState State { get; }

        /// <summary>
        /// Entra al equipamiento en estado de fallo.
        /// </summary>
        Result GetIntoFaultState();

        /// <summary>
        /// Saca al equipamiento del estado de fallo.
        /// </summary>
        Result GetOutOfFaultState();
    }
}
