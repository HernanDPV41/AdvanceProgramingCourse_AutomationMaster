namespace EquipmentMonitoring.Domain.Types
{
    /// <summary>
    /// Enumera los posibles estados del equipamiento automático.
    /// </summary>
    public enum EquipmentState
    {
        /// <summary>
        /// En espera de ejecución.
        /// </summary>
        Idle,
        /// <summary>
        /// En ejecución.
        /// </summary>
        Executing,
        /// <summary>
        /// En estado de fallo.
        /// </summary>
        Faulted
    }
}

