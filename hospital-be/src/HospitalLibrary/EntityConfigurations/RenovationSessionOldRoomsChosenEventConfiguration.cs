using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ChangeTracking; 
using System.Text.Json;
using HospitalLibrary.RenovationSessionAggregate.Infrastructure;
using HospitalLibrary.RenovationSessionAggregate.DomainEvents;
using HospitalLibrary.Renovation.Model;

namespace HospitalLibrary.EntityConfigurations
{
    public class RenovationSessionOldRoomsChosenEventConfiguration : IEntityTypeConfiguration<OldRoomsChosen>
    {
        public void Configure(EntityTypeBuilder<OldRoomsChosen> builder)
        {
            var valueComparer = new ValueComparer<IEnumerable<RoomRenovationPlan>>(
                (c1, c2) => c1.SequenceEqual(c2),
                c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                c => c);

            builder.Property(obj => obj.RoomRenovationPlans)
                .HasConversion(
                plan => JsonSerializer.Serialize(plan, (JsonSerializerOptions)null),
                json => JsonSerializer.Deserialize<IEnumerable<RoomRenovationPlan>>(json, (JsonSerializerOptions)null))
                .Metadata
                .SetValueComparer(valueComparer);
        }
    }
}