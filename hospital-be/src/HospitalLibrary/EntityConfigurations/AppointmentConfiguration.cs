using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HospitalLibrary.EntityConfigurations
{
    public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.OwnsOne(usage => usage.DateRange, a =>
            {
                a.Property(prop => prop.StartTime)
                .HasColumnName("StartTime");
                a.Property(prop => prop.EndTime)
                .HasColumnName("EndTime");
            });
        }
    }
}