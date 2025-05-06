using EquipmentMonitoring.Domain.Types;
using EquipmentMonitoring.Domain.ValueObjects;

namespace EquipmentMonitoring.Domain.Entities
{
    /// <summary>
    /// Interfaz hombre máquina.
    /// </summary>
    public class HMI
        : AutomationDevice
    {

        #region Properties

        /// <summary>
        /// Punto de comunicación para obtener el identificador del usuario logueado.
        /// </summary>
        public CommunicationNode UserNode { get; set; }

        #endregion

        /// <summary>
        /// Requerido por EF.
        /// </summary>
        private HMI()
        {

        }

        public HMI(
            Guid id,
            NetworkAddress address,
            EquipmentState state,
            CommunicationNode userNode)
        : base(id, address, state)
        {
            UserNode = userNode;
        }
    }
}
