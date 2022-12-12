using HospitalLibrary.Patients.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HospitalLibrary.Settings.Configurations
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
                builder
                .OwnsOne(p => p.Email, email =>
                {
                    email.Property(prop => prop.Address)
                        .HasColumnName("EmailAddress");
                });
        }
    }
}