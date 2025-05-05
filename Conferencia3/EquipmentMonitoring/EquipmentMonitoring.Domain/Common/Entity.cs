using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentMonitoring.Domain.Common
{
    /// <summary>
    /// Clase base para el patrón entidad.
    /// </summary>
    public abstract class Entity
        : CheckableObject
    {
        #region Properties

        /// <summary>
        /// Identificador de la entidad.
        /// </summary>
        public Guid Id { get; set; }

        #endregion

        protected Entity(
            Guid id)
        {
            Id = id;
        }

    }
}
