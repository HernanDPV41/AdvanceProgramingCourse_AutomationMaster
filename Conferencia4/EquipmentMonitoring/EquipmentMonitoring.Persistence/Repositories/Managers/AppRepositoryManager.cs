using EquipmentMonitoring.Contracts;
using EquipmentMonitoring.Contracts.Repositories;
using EquipmentMonitoring.Contracts.Repositories.Managers;
using EquipmentMonitoring.Persistence.Contexts;

namespace EquipmentMonitoring.Persistence.Repositories.Managers
{
    public class AppRepositoryManager
        : IAppRepositoryManager
    {
        private readonly AppDbContext _context;

        private IUnitRepository? _unit = null;
        public IUnitRepository Unit
        {
            get
            {
                if (_unit is null)
                    _unit = new UnitRepository(_context);
                return _unit;
            }
        }

        private IVariableRepository? _variable = null;
        public IVariableRepository Variable
        {
            get
            {
                if (_variable is null)
                    _variable = new VariableRepository(_context);
                return _variable;
            }
        }

        private IOperationRepository? _operation = null;
        public IOperationRepository Operation
        {
            get
            {
                if (_operation is null)
                    _operation = new OperationRepository(_context);
                return _operation;
            }
        }

        private IAutomationDeviceRepository? _automationDevice = null;
        public IAutomationDeviceRepository AutomationDevice
        {
            get
            {
                if (_automationDevice is null)
                    _automationDevice = new AutomationDeviceRepository(_context);
                return _automationDevice;
            }
        }

        private IEquipmentStateChangeRecordRepository? _equipmentStateChangeRecordRepository = null;
        public IEquipmentStateChangeRecordRepository EquipmentStateChangeRecord
        {
            get
            {
                if (_equipmentStateChangeRecordRepository is null)
                    _equipmentStateChangeRecordRepository = new EquipmentStateChangeRecordRepository(_context);
                return _equipmentStateChangeRecordRepository;
            }
        }

        private IUnitOfWork? _unitOfWork = null;
        public IUnitOfWork UnitOfWork
        {
            get
            {
                if (_unitOfWork is null)
                    _unitOfWork = new UnitOfWork(_context);
                return _unitOfWork;
            }
        }


        public AppRepositoryManager(AppDbContext context)
        {
            _context = context;
        }

    }
}
