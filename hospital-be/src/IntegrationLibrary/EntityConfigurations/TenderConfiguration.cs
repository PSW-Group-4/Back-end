using IntegrationLibrary.BloodRequests.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegrationLibrary.Tenders.Model;

namespace IntegrationLibrary.EntityConfigurations
{
    public class TenderConfiguration : IEntityTypeConfiguration<Tender>
    {
        public void Configure(EntityTypeBuilder<Tender> builder)
        {
            builder.OwnsOne(tender => tender.BloodType, a =>
            {
                a.Property(prop => prop.BloodGroup).HasMaxLength(1)
                .HasColumnName("BloodGroup");
                a.Property(prop => prop.RHFactor).HasMaxLength(10)
                .HasColumnName("RhFactor");
            });
        }
    }
}
