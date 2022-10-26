using HospitalLibrary.Core.Model;
using HospitalLibrary.Patients.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;

namespace HospitalLibrary.Settings
{
    public class HospitalDbContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Patient> Patients { get; set; }
        
        public DbSet<Floor> Floors {get; set; }
        public DbSet<Building> Buildings {get; set;}
        
        public DbSet<CafeteriaRoom> CafeteriaRooms {get; set;}
        public HospitalDbContext(DbContextOptions<HospitalDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
