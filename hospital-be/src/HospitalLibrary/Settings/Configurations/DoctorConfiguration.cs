using HospitalLibrary.Doctors.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HospitalLibrary.Settings.Configurations
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
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