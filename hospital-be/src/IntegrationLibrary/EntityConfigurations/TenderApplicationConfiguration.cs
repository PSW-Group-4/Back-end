using IntegrationLibrary.TenderApplications.Model;
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
    class TenderApplicationConfiguration : IEntityTypeConfiguration<TenderApplication>
    {
        public void Configure(EntityTypeBuilder<TenderApplication> builder)
        {
            
                builder.Property(tenderApplication => tenderApplication.Price).HasConversion(
                    price => JsonSerializer.Serialize(price, (JsonSerializerOptions)null),
                    json => JsonSerializer.Deserialize<Price>(json, (JsonSerializerOptions)null));
            
        }
    }
}
