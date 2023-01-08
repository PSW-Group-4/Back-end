using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.Renovation.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ChangeTracking; 
using System.Text.Json;
using HospitalLibrary.RenovationSessionAggregate.Infrastructure;
using HospitalLibrary.RenovationSessionAggregate.DomainEvents;

namespace HospitalLibrary.EntityConfigurations
{
    public class RenovationSessionEventsConfiguration : IEntityTypeConfiguration<RenovationSessionEvent>
    {
        public void Configure(EntityTypeBuilder<RenovationSessionEvent> builder)
        {
            builder
                .ToTable("RenovationSessionEvents")
                .HasDiscriminator<string>("Type")
                .HasValue<NewRoomsCreated>("NewRoomsCreated")
                .HasValue<OldRoomsChosen>("OldRoomsChosen")
                .HasValue<ReturnedToNewRoomCreation>("ReturnedToNewRoomCreation")
                .HasValue<ReturnedToOldRoomsSelection>("ReturnedToOldRoomsSelection")
                .HasValue<ReturnedToSpecificTimeSelection>("ReturnedToSpecificTimeSelection")
                .HasValue<ReturnedToTimeframeCreation>("ReturnedToTimeframeCreation")
                .HasValue<ReturnedToTypeSelection>("ReturnedToTypeSelection")
                .HasValue<SessionEnded>("SessionEnded")
                .HasValue<SessionStarted>("SessionStarted")
                .HasValue<SpecificTimeChosen>("SpecificTimeChosen")
                .HasValue<TimeframeCreated>("TimeframeCreated")
                .HasValue<TypeChosen>("TypeChosen");
        }
    }
}