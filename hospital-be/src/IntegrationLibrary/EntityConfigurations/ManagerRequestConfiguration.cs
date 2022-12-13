using IntegrationLibrary.Common;
using IntegrationLibrary.ManagerBloodRequests.Model;
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
    public class ManagerRequestConfiguration : IEntityTypeConfiguration<ManagerRequest>
    {
        public void Configure(EntityTypeBuilder<ManagerRequest> builder)
        {
            builder.Property(req => req.Blood).HasConversion(
                bloodProducts => JsonSerializer.Serialize(bloodProducts, (JsonSerializerOptions)null),
                json => JsonSerializer.Deserialize<Blood>(json, (JsonSerializerOptions)null));
        }
    }
}
