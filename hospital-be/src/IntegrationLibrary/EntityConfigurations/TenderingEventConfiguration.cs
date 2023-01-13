using IntegrationLibrary.Tendering.DomainEvents.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IntegrationLibrary.EntityConfigurations
{
    public class TenderingEventConfiguration : IEntityTypeConfiguration<TenderingEvent>
    {
        public void Configure(EntityTypeBuilder<TenderingEvent> builder)
        {
            /*builder.Property(tender => tender.Blood).HasConversion(
                bloodProducts => JsonSerializer.Serialize(bloodProducts, (JsonSerializerOptions)null),
                json => JsonSerializer.Deserialize<IEnumerable<Blood>>(json, (JsonSerializerOptions)null));
*/
            builder.HasDiscriminator(tenderingEvent => tenderingEvent.EventType);
        }
    }
}