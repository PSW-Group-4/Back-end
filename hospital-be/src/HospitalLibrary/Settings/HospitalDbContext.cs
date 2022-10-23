using HospitalLibrary.Core.Model;
using HospitalLibrary.Patients.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace HospitalLibrary.Settings
{
    public class HospitalDbContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public HospitalDbContext(DbContextOptions<HospitalDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Guid id1 = Guid.NewGuid();

            modelBuilder.Entity<Address>().HasData(
                new Address() { Id = id1, City = "Kkinda", Country = "Serbia", Street = "Ulica", StreetNumber = "11" }
            );

            modelBuilder.Entity<Patient>().HasData(
                new Patient() { Id = Guid.NewGuid(), Name = "Strahinja", Surname = "Erakovic", 
                    AddressId = id1, Birthdate = DateTime.Now, Blocked = false, Gender = Gender.Male, Email = "mail@gmail.com",
                    Jmbg = "123456789", Lbo = "343434", PhoneNumber = "061-333-44-77"}
            );
            base.OnModelCreating(modelBuilder);
        }
    }
}
