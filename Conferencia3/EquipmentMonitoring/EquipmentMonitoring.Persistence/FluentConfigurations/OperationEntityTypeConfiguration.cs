using EquipmentMonitoring.Domain.Entities;
using EquipmentMonitoring.Persistence.FluentConfigurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentMonitoring.Persistence.FluentConfigurations
{
    internal class OperationEntityTypeConfiguration
        : EntityTypeConfigurationBase<Operation>
    {
        public override void Configure(EntityTypeBuilder<Operation> builder)
        {
            base.Configure(builder);
            builder.ToTable("Operations");
        }
    }
}
