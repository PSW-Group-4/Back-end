using HospitalLibrary.Core.Model;
using HospitalLibrary.Patients.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;
using HospitalLibrary.BuildingManagmentMap.Model;

namespace HospitalLibrary.Settings
{
    public class HospitalDbContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Patient> Patients { get; set; }

        public DbSet<BuildingMap> BuildingMaps { get; set; }

        public DbSet<FloorMap> FloorMaps { get; set; }

        public DbSet<RoomMap> RoomMaps { get; set; }

        public HospitalDbContext(DbContextOptions<HospitalDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
