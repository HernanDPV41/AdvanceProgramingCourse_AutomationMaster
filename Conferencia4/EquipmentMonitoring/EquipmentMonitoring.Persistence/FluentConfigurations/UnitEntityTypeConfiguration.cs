using EquipmentMonitoring.Domain.Entities;
using EquipmentMonitoring.Persistence.FluentConfigurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EquipmentMonitoring.Persistence.FluentConfigurations
{
    internal class UnitEntityTypeConfiguration
        : EntityTypeConfigurationBase<Unit>
    {

        public override void Configure(EntityTypeBuilder<Unit> builder)
        {
            base.Configure(builder);
            builder.ToTable("Units");
            builder.OwnsOne(unit => unit.Code);
            builder.HasMany(u => u.Variables).WithOne().HasForeignKey(x => x.UnitId);
            builder.HasMany(u => u.Operations).WithOne().HasForeignKey(x => x.UnitId);
            builder.Navigation(u => u.ActiveOperation);
            builder.HasMany(u => u.AutomationDevices).WithMany(a => a.Units);
        }
    }
}
