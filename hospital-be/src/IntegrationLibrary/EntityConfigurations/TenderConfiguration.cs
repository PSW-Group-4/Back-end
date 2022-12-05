using IntegrationLibrary.BloodRequests.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegrationLibrary.Tenders.Model;
using IntegrationLibrary.Common;
using System.Text.Json;

namespace IntegrationLibrary.EntityConfigurations
{
    public class TenderConfiguration : IEntityTypeConfiguration<Tender>
    {
        public void Configure(EntityTypeBuilder<Tender> builder)
        {
            builder.Property(tender => tender.Blood).HasConversion(
                bloodProducts => JsonSerializer.Serialize(bloodProducts, (JsonSerializerOptions)null),
                json => JsonSerializer.Deserialize<IEnumerable<Blood>>(json, (JsonSerializerOptions)null));
        }
    }
}
