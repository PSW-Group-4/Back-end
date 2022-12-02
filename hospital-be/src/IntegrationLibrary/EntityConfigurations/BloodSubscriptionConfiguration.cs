using IntegrationLibrary.BloodSubscriptions;
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
    public class BloodSubscriptionConfiguration : IEntityTypeConfiguration<BloodSubscription>
    {
        public void Configure(EntityTypeBuilder<BloodSubscription> builder)
        {
            builder.Property(tender => tender.BloodProducts).HasConversion(
                bloodProducts => JsonSerializer.Serialize(bloodProducts, (JsonSerializerOptions)null),
                json => JsonSerializer.Deserialize<List<BloodProduct>>(json, (JsonSerializerOptions)null));
        }
    }
}
