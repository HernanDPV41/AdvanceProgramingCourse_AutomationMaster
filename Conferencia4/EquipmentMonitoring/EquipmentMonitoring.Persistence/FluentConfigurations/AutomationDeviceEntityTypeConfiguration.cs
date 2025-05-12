using EquipmentMonitoring.Domain.Entities;
using EquipmentMonitoring.Persistence.FluentConfigurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EquipmentMonitoring.Persistence.FluentConfigurations
{
    internal class AutomationDeviceEntityTypeConfiguration
        : EntityTypeConfigurationBase<AutomationDevice>
    {
        public override void Configure(EntityTypeBuilder<AutomationDevice> builder)
        {
            base.Configure(builder);
            builder.ToTable("AutomationDevices");
            builder.OwnsOne(x => x.Address);
        }
    }
}
