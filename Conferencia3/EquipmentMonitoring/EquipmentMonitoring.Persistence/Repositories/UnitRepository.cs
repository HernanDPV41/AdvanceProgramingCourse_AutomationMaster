using EquipmentMonitoring.Contracts.Repositories;
using EquipmentMonitoring.Domain.Entities;
using EquipmentMonitoring.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentMonitoring.Persistence.Repositories
{
    public class UnitRepository
        : IUnitRepository
    {
        private readonly AppDbContext _context;

        public UnitRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Unit unit)
        {
            await _context.Units.AddAsync(unit);
        }

        public async void DeleteById(Guid id)
        {
            var unit = await _context.Units.FindAsync(id);
            if (unit is null)
                return;
            _context.Units.Remove(unit);
        }

        public async Task<Unit> GetByIdAsync(Guid id)
        {
            return await _context.Units.FindAsync(id);
        }

        public Task<IEnumerable<Unit>> GetUnitsAsync()
        {
            return Task.FromResult<IEnumerable<Unit>>(_context.Units.ToList());
        }

        public void Update(Unit unit)
        {
            _context.Units.Update(unit);
        }

    }
}
