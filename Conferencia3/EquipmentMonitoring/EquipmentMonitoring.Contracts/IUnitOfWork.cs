using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentMonitoring.Contracts
{
    /// <summary>
    /// Define las funcionalidades necesarias para el patrón Unit of Work.
    /// </summary>
    public interface IUnitOfWork
    {
        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
