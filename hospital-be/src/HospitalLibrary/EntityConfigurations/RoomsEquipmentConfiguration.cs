using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.RoomsAndEqipment.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HospitalLibrary.EntityConfigurations
{
    public class RoomsEquipmentConfiguration : IEntityTypeConfiguration<RoomsEquipment>
    {
        public void Configure(EntityTypeBuilder<RoomsEquipment> builder)
        {
            builder
                .HasKey(re => new {re.RoomId, re.EquipmentId});
            
            builder
                .HasOne<Equipment>(re => re.Equipment)
                .WithMany(e => e.RoomsEquipment)
                .HasForeignKey(re => re.EquipmentId);

            builder
                .HasOne<Room>(dc => dc.Room)
                .WithMany(dr => dr.RoomsEquipment)
                .HasForeignKey(re => re.RoomId);
        }
        
    }
}