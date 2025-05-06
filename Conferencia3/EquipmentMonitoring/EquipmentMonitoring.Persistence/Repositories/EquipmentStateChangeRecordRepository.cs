using EquipmentMonitoring.Contracts.Repositories;
using EquipmentMonitoring.Domain.Records;
using EquipmentMonitoring.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EquipmentMonitoring.Persistence.Repositories
{
    public class EquipmentStateChangeRecordRepository
        : IEquipmentStateChangeRecordRepository
    {

        private readonly AppDbContext _context;

        public EquipmentStateChangeRecordRepository(
            AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(EquipmentStateChangeRecord record)
        {
            await _context.EquipmentStateChangeRecords.AddAsync(record);
        }

        public async Task<IEnumerable<EquipmentStateChangeRecord>> GetEquipmentStateChangeRecords(DateTime start, DateTime end)
        {
            return await _context.EquipmentStateChangeRecords
                .Where(x => x.OccurringTime >= start && x.OccurringTime <= end)
                .ToListAsync();
        }
    }
}
