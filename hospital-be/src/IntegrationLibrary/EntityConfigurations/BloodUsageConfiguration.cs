using IntegrationLibrary.BloodBanks.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.EntityConfigurations
{
    public class BloodUsageConfiguration : IEntityTypeConfiguration<BloodUsage>
    {
        public void Configure(EntityTypeBuilder<BloodUsage> builder)
        {
            builder.OwnsOne(usage => usage.Type, a =>
            {
                a.Property(prop => prop.BloodGroup).HasMaxLength(1)
                .HasColumnName("BloodTypeTitle");
                a.Property(prop => prop.RhFactor).HasMaxLength(10)
                .HasColumnName("RhFactor");
            });
        }
    }
}
