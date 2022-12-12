using System.Collections.Generic;
using System.Text.Json;
using IntegrationLibrary.BloodSubscriptions;
using IntegrationLibrary.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IntegrationLibrary.EntityConfigurations
{
    public class BloodSubscriptionConfiguration : IEntityTypeConfiguration<BloodSubscription>
    {
        public void Configure(EntityTypeBuilder<BloodSubscription> builder)
        {
            builder.Property(bloodSubscription => bloodSubscription.Blood).HasConversion(
                bloodProducts => JsonSerializer.Serialize(bloodProducts, null),
                json => JsonSerializer.Deserialize<List<Blood>>(json, null));
        }
    }
}