using EquipmentMonitoring.Contracts.Repositories;
using EquipmentMonitoring.Domain.Entities;
using EquipmentMonitoring.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EquipmentMonitoring.Persistence.Repositories
{
    public class AutomationDeviceRepository
        : IAutomationDeviceRepository
    {
        private readonly AppDbContext _context;

        public AutomationDeviceRepository(
            AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(AutomationDevice automationDevice)
        {
            await _context.AutomationDevices.AddAsync(automationDevice);
        }

        public async void DeleteById(Guid id)
        {
            var automationDevice = await _context.AutomationDevices.FindAsync(id);
            if (automationDevice is null)
                return;
            _context.AutomationDevices.Remove(automationDevice);
        }

        public async Task<IEnumerable<AutomationDevice>> GetAutomationDeviceByUnitAsync(Guid unitId)
        {
            var unit = await _context.Units.Include(u => u.AutomationDevices).FirstAsync(u => u.Id == unitId);
            return unit.AutomationDevices;
        }

        public async Task<AutomationDevice> GetByIdAsync(Guid id)
        {
            return await _context.AutomationDevices.FindAsync(id);
        }

        public void Update(AutomationDevice automationDevice)
        {
            _context.Update(automationDevice);
        }
    }
}
