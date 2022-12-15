using HospitalLibrary.BloodConsumptionRecords.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HospitalLibrary.Settings.Configurations
{
    public class BloodConsumptionRecordConfiguration : IEntityTypeConfiguration<BloodConsumptionRecord>
    {
        public void Configure(EntityTypeBuilder<BloodConsumptionRecord> builder)
        {
            builder
            .OwnsOne(b => b.Amount, amount =>
            {
                amount.Property(prop => prop.Value)
                    .HasColumnName("AmountValue");
            });
        }
    }
}