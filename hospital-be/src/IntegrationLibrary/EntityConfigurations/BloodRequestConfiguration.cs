using IntegrationLibrary.BloodRequests.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.EntityConfigurations
{
    public class BloodRequestConfiguration : IEntityTypeConfiguration<BloodRequest>
    {
        public void Configure(EntityTypeBuilder<BloodRequest> builder)
        {
            builder.OwnsOne(request => request.BloodType, a =>
            {
                a.Property(prop => prop.Title).HasMaxLength(1)
                .HasColumnName("BloodTypeTitle");
                a.Property(prop => prop.RHFactor).HasMaxLength(10)
                .HasColumnName("RhFactor");
            });
        }
    }
}
