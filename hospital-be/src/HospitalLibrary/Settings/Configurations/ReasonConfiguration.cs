using HospitalLibrary.Admissions.Model;
using HospitalLibrary.BloodConsumptionRecords.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Settings.Configurations
{
    public class ReasonConfiguration : IEntityTypeConfiguration<Admission>
    {
        public void Configure(EntityTypeBuilder<Admission> builder)
        {
            builder
            .OwnsOne(b => b.ReasonText, amount =>
            {
                amount.Property(prop => prop.Text)
                    .HasColumnName("ReasonText");
            });
        }
    }
}
