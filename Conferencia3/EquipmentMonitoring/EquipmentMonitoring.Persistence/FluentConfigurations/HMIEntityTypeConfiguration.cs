using EquipmentMonitoring.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EquipmentMonitoring.Persistence.FluentConfigurations
{
    internal class HMIEntityTypeConfiguration
        : IEntityTypeConfiguration<HMI>
    {
        public void Configure(EntityTypeBuilder<HMI> builder)
        {
            builder.ToTable("HMIs");
            builder.HasBaseType<AutomationDevice>();
            builder.OwnsOne(x => x.UserNode);
        }
    }
}
