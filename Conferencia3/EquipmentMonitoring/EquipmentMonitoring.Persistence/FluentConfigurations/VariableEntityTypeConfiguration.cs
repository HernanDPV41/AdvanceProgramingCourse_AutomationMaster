using EquipmentMonitoring.Domain.Entities;
using EquipmentMonitoring.Persistence.FluentConfigurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EquipmentMonitoring.Persistence.FluentConfigurations
{
    internal class VariableEntityTypeConfiguration
        : EntityTypeConfigurationBase<Variable>
    {

        public override void Configure(EntityTypeBuilder<Variable> builder)
        {
            base.Configure(builder);
            builder.ToTable("Variables");
            builder.OwnsOne(x => x.MeasurementUnit);
            builder.OwnsOne(x => x.ValueNode);
        }
    }
}
