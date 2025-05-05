using FluentResults;

namespace EquipmentMonitoring.Domain.Common
{
    /// <summary>
    /// Define una regla de negocio del dominio.
    /// </summary>
    public interface IBusinessRule
    {
        /// <summary>
        /// Valida la regla de negocio y retorna su resultado.
        /// </summary>
        /// <returns></returns>
        Result CheckRule();
    }
}
