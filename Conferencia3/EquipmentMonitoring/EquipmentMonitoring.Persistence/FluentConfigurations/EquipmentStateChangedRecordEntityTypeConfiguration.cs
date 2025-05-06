using EquipmentMonitoring.Domain.Records;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EquipmentMonitoring.Persistence.FluentConfigurations
{
    internal class EquipmentStateChangedRecordEntityTypeConfiguration
        : IEntityTypeConfiguration<EquipmentStateChangeRecord>
    {
        public void Configure(EntityTypeBuilder<EquipmentStateChangeRecord> builder)
        {
            builder.ToTable("StateChangeRecords");
            builder.HasKey(x => new { x.EquipmentId, x.OccurringTime });
        }
    }
}
