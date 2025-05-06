namespace EquipmentMonitoring.Contracts.Repositories.Managers
{

    public interface IAppRepositoryManager
    {
        IUnitRepository Unit { get; }
        IVariableRepository Variable { get; }
        IOperationRepository Operation { get; }
        IAutomationDeviceRepository AutomationDevice { get; }
        IEquipmentStateChangeRecordRepository EquipmentStateChangeRecord { get;}
        IUnitOfWork UnitOfWork { get; }
    }
}
