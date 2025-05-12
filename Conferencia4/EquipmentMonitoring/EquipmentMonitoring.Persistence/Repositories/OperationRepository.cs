using EquipmentMonitoring.Contracts.Repositories;
using EquipmentMonitoring.Domain.Entities;
using EquipmentMonitoring.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EquipmentMonitoring.Persistence.Repositories
{
    public class OperationRepository
        : IOperationRepository
    {
        private readonly AppDbContext _context;

        public OperationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Operation operation)
        {
            await _context.Operations.AddAsync(operation);
        }

        public async void DeleteById(Guid id)
        {
            var operation = await _context.Operations.FindAsync(id);
            if (operation is null)
                return;
            _context.Operations.Remove(operation);
        }

        public async Task<Operation> GetByIdAsync(Guid id)
        {
            return await _context.Operations.FindAsync(id);
        }

        public async Task<IEnumerable<Operation>> GetOperationsByUnitAsync(Guid unitId)
        {
            var unit = await _context.Units.Include(u => u.Operations).FirstAsync(u => u.Id == unitId);
            return unit.Operations;
        }

        public void Update(Operation operation)
        {
            _context.Operations.Update(operation);
        }
    }
}
