using HospitalLibrary.Allergies.Model;
using HospitalLibrary.Appointments.Model;
using HospitalLibrary.BuildingManagment.Model;
using HospitalLibrary.BuildingManagmentMap.Model;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Doctors.Model;
using HospitalLibrary.Feedbacks.Model;
using HospitalLibrary.Patients.Model;
using HospitalLibrary.RoomsAndEqipment.Model;
using HospitalLibrary.Users.Model;
using Microsoft.Extensions.Hosting;
using HospitalLibrary.BloodConsumptionRecords.Model;
using HospitalLibrary.BloodSupplies.Model;
using HospitalLibrary.Vacations.Model;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using HospitalLibrary.Admissions.Model;
using HospitalLibrary.AcountActivation.Model;
using HospitalLibrary.MoveEquipment.Model;
using HospitalLibrary.AdmissionHistories.Model;
using HospitalLibrary.Medicines.Model;
using HospitalLibrary.EquipmentRelocation.DTO;
using HospitalLibrary.Treatments.Model;
using HospitalLibrary.Utility;
using IntegrationLibrary.Common;


namespace HospitalLibrary.Settings
{
    public class HospitalDbContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Patient> Patients { get; set; }

        public DbSet<Admission> Admissions { get; set; }
        public DbSet<AdmissionHistory> AdmissionHistories { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<AcountActivationInfo> AcountActivationInfos { get; set; }
        public DbSet<Allergie> Allergies { get; set; }
        public DbSet<AgeGroup> AgeGroups { get; set; }


        // Building managment
        public DbSet<Floor> Floors { get; set; }
        public DbSet<Building> Buildings { get; set; }

        // Rooms and Equipment
        public DbSet<Room> Rooms { get; set; }
        public DbSet<CafeteriaRoom> CafeteriaRooms { get; set; }
        public DbSet<DoctorRoom> DoctorRooms { get; set; }
        public DbSet<Equipment> Equipments { get; set; }

        public DbSet<PatientRoom> PatientRooms { get; set; }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        public DbSet<BloodConsumptionRecord> BloodConsumptionRecords { get; set; }

        public DbSet<BuildingMap> BuildingMaps { get; set; }

        public DbSet<FloorMap> FloorMaps { get; set; }

        public DbSet<RoomMap> RoomMaps { get; set; }

        public DbSet<RoomsEquipment> RoomsEquipment { get; set; }

        public DbSet<Bed> Beds { get; set; }


        // Doctor vacations
        public DbSet<Vacation> Vacations { get; set; }

        public DbSet<BloodSupply> BloodSupply { get; set; }

        public DbSet<RoomSchedule> RoomSchedules { get; set; }
        public DbSet<MoveEquipmentTask> MoveEquipmentTasks { get; set; }
        public DbSet<EquipmentToMove> EquipmentToMoves { get; set; }

        // Medicine
        public DbSet<Medicine> Medicines { get; set; }


        //public DbSet<EquipmentRelocationDTO> EquipmentRelocations { get; set; }

        public DbSet<Treatment> Treatments { get; set; }


        public HospitalDbContext(DbContextOptions<HospitalDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder
                .Entity<RoomsEquipment>()
                .HasKey(re => new { re.DoctorRoomId, re.EquipmentId });

            modelBuilder.Entity<RoomsEquipment>()
                .HasOne<Equipment>(re => re.Equipment)
                .WithMany(e => e.RoomsEquipment)
                .HasForeignKey(re => re.EquipmentId);

            modelBuilder.Entity<RoomsEquipment>()
                .HasOne<DoctorRoom>(dc => dc.DoctorRoom)
                .WithMany(dr => dr.RoomsEquipment)
                .HasForeignKey(re => re.DoctorRoomId);

            modelBuilder
                .Entity<Patient>()
                .HasMany(p => p.Allergies)
                .WithMany(a => a.Patients)
                .UsingEntity(j => j.ToTable("PatientAllergies"));

            modelBuilder
                .Entity<Patient>()
                .OwnsOne(p => p.BloodType, bloodType =>
                {
                    bloodType.Property(prop => prop.BloodGroup).HasMaxLength(1)
                        .HasColumnName("BloodGroup");
                    bloodType.Property(prop => prop.RhFactor).HasMaxLength(10)
                        .HasColumnName("RhFactor");
                });

            modelBuilder.Entity<User>()
                .Ignore(u => u.SuspiciousActivities)  
                .Property("suspicious_activities");

            modelBuilder.Entity<BloodSupply>()
                .OwnsOne(bloodSupply => bloodSupply.BloodType, bloodType =>
                {
                    bloodType.Property(prop => prop.BloodGroup).HasMaxLength(1)
                        .HasColumnName("BloodGroup");
                    bloodType.Property(prop => prop.RhFactor).HasMaxLength(10)
                        .HasColumnName("RhFactor");
                });
        }
    }
}