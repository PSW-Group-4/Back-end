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
using HospitalLibrary.Symptoms.Model;
using HospitalLibrary.Reports.Model;
using HospitalLibrary.Consiliums.Model;
using HospitalLibrary.EntityConfigurations;
using HospitalLibrary.Infrastructure.EventSourcing;
using HospitalLibrary.MedicalAppointmentSchedulingSession.Events;
using HospitalLibrary.Renovation.Model;
using HospitalLibrary.MedicalAppointmentReportSession.Model.Events;
using HospitalLibrary.RenovationSessionAggregate.Infrastructure;
using HospitalLibrary.RenovationSessionAggregate.DomainEvents;


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
        public DbSet<MedicalAppointment> MedicalAppointments { get; set; }

        public DbSet<BloodConsumptionRecord> BloodConsumptionRecords { get; set; }

        public DbSet<BuildingMap> BuildingMaps { get; set; }

        public DbSet<FloorMap> FloorMaps { get; set; }

        public DbSet<RoomMap> RoomMaps { get; set; }

        public DbSet<RoomsEquipment> RoomsEquipment { get; set; }

        public DbSet<Bed> Beds { get; set; }


        // Doctor vacations
        public DbSet<Vacation> Vacations { get; set; }

        public DbSet<BloodSupply> BloodSupply { get; set; }

        public DbSet<Appointment> Appointments {get; set;}
        public DbSet<MoveEquipmentAppointment> MoveEquipmentTasks {get; set;}
        public DbSet<EquipmentToMove> EquipmentToMoves {get; set;}

        // Medicine
        public DbSet<Medicine> Medicines { get; set; }

        // Symptoms
        public DbSet<Symptom> Symptoms { get; set; }

        // Reports
        public DbSet<Report> Reports { get; set; }

        //public DbSet<EquipmentRelocationDTO> EquipmentRelocations { get; set; }

        public DbSet<Treatment> Treatments { get; set; }
        public DbSet<RenovationAppointment> RenovationAppointments {get; set;}

        // Consilium
        public DbSet<Consilium> Consiliums { get; set; }
        
        // Medical appointment scheduling session
        public DbSet<MedicalAppointmentSchedulingSessionEvent> MedicalAppointmentSchedulingSessionEvents { get; set; }
        
        // Medical appointment report session
        public DbSet<MedicalAppointmentReportSessionEvent> MedicalAppointmentReportSessionEvents { get; set; }

        // Aggregates
        public DbSet<RenovationSessionAggregateRoot> RenovationSessionAggregateRoots {get; set;}
        public DbSet<RenovationSessionEvent> RenovationSessionEvents {get; set;}
        


        public HospitalDbContext(DbContextOptions<HospitalDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Ignore<DomainEvent>();

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