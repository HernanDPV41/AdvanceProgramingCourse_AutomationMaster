using EquipmentMonitoring.Contracts;
using EquipmentMonitoring.Persistence.Contexts;

namespace EquipmentMonitoring.Persistence
{
    public class UnitOfWork
        : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            if (!context.Database.CanConnect())
                context.Database.EnsureCreated();
        }

        public Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            return  _context.SaveChangesAsync(cancellationToken);
        }
    }
}
