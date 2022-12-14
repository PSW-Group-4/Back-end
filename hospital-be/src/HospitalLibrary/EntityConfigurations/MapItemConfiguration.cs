using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.BuildingManagmentMap.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HospitalLibrary.EntityConfigurations
{
    public class MapItemConfiguration : IEntityTypeConfiguration<MapItem>
    {
        public void Configure(EntityTypeBuilder<MapItem> builder)
        {
            builder.OwnsOne(usage => usage.MapLocation, a =>
            {
                a.Property(prop => prop.CoordinateX)
                .HasColumnName("CoordinateX");
                a.Property(prop => prop.CoordinateY)
                .HasColumnName("CoordinateY");
                a.Property(prop => prop.Height)
                .HasColumnName("Height");
                a.Property(prop => prop.Width)
                .HasColumnName("Width");
            });
        }
    }
}