using IntegrationLibrary.BloodRequests.Model;
using IntegrationLibrary.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace IntegrationLibrary.EntityConfigurations
{
    public class BloodRequestConfiguration : IEntityTypeConfiguration<BloodRequest>
    {
        public void Configure(EntityTypeBuilder<BloodRequest> builder)
        {
            builder.OwnsOne(request => request.Blood, a =>
            {
                a.Property(blood => blood.BloodType).HasConversion(
                bloodType => JsonSerializer.Serialize(bloodType, (JsonSerializerOptions)null),
                json => JsonSerializer.Deserialize<BloodType>(json, (JsonSerializerOptions)null));
            });

        }
    }
}
