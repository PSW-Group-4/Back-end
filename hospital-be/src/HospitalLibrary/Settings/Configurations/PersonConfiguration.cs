using HospitalLibrary.Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HospitalLibrary.Settings.Configurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.OwnsOne(person => person.Email, email =>
            {
                email.Property(prop => prop.Address)
                    .HasColumnName("EmailAddress");
            });
        }
    }
}