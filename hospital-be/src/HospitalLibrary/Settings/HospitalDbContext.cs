
using HospitalLibrary.Core.Model;
using HospitalLibrary.Feedbacks.Model;
using HospitalLibrary.Appointments.Model;
using HospitalLibrary.BuildingManagment.Model;
using HospitalLibrary.Doctors.Model;
using HospitalLibrary.Patients.Model;
using HospitalLibrary.RoomsAndEqipment.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;
using HospitalLibrary.BuildingManagmentMap.Model;
using HospitalLibrary.Users.Model;
using HospitalLibrary.Allergies.Model;
using Microsoft.Extensions.Hosting;
using HospitalLibrary.BloodConsumptionRecords.Model;

namespace HospitalLibrary.Settings
{
    public class HospitalDbContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Allergie> Allergies { get; set; } 
        
        
        // Building managment
        public DbSet<Floor> Floors {get; set; }
        public DbSet<Building> Buildings {get; set;}
        
        // Rooms and Equipment
        public DbSet<Room> Rooms {get; set;}
        public DbSet<CafeteriaRoom> CafeteriaRooms {get; set;}
        public DbSet<DoctorRoom> DoctorRooms { get; set; }
        public DbSet<Equipment> Equipments {get; set;}

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        public DbSet<BloodConsumptionRecord> BloodConsumptionRecords { get; set; }

        public DbSet<BuildingMap> BuildingMaps { get; set; }

        public DbSet<FloorMap> FloorMaps { get; set; }

        public DbSet<RoomMap> RoomMaps { get; set; }

        public HospitalDbContext(DbContextOptions<HospitalDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

           modelBuilder
            .Entity<Patient>()
            .HasMany(p => p.Allergies)
            .WithMany(a => a.Patients)
            .UsingEntity(j => j.ToTable("PatientAllergies"));
        }
    }
}
