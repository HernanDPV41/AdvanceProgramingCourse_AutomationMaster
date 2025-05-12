using EquipmentMonitoring.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EquipmentMonitoring.Persistence.FluentConfigurations
{
    internal class PLCEntityTypeConfiguration
        : IEntityTypeConfiguration<PLC>
    {
        public void Configure(EntityTypeBuilder<PLC> builder)
        {
            builder.ToTable("PLCs");
            builder.HasBaseType<AutomationDevice>();
        }
    }
}
