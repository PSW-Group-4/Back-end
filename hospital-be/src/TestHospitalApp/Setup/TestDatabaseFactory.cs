using HospitalAPI;
using HospitalLibrary.AdmissionHistories.Model;
using HospitalLibrary.Admissions.Model;
using HospitalLibrary.Appointments.Model;
using HospitalLibrary.BloodSupplies.Model;
using HospitalLibrary.BuildingManagment.Model;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Doctors.Model;
using HospitalLibrary.Medicines.Model;
using HospitalLibrary.Patients.Model;
using HospitalLibrary.Reports.Model;
using HospitalLibrary.Renovation.Model;
using HospitalLibrary.RoomsAndEqipment.Model;
using HospitalLibrary.Settings;
using HospitalLibrary.Symptoms.Model;
using HospitalLibrary.Treatments.Model;
using HospitalLibrary.Users.Model;
using HospitalLibrary.Vacations.Model;
using IntegrationLibrary.Common;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using HospitalLibrary.MedicalAppointmentSchedulingSession.Events;
using DateTime = System.DateTime;
using HospitalLibrary.MedicalAppointmentReportSession.Model.Events;
using HospitalLibrary.RenovationSessionAggregate.DomainEvents;
using HospitalLibrary.RenovationSessionAggregate.Infrastructure;

namespace TestHospitalApp.Setup
{
    public class TestDatabaseFactory<TStartup> : WebApplicationFactory<Startup>
    {
        private static bool isDbCreated = false;
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseSolutionRelativeContentRoot("");

            builder.ConfigureServices(services =>
            {
                using var scope = BuildServiceProvider(services).CreateScope();
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<HospitalDbContext>();

                InitializeDatabase(db);
                while (isDbCreated) { }
            });
        }

        private static ServiceProvider BuildServiceProvider(IServiceCollection services)
        {
            var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<HospitalDbContext>));
            services.Remove(descriptor);

            services.AddDbContext<HospitalDbContext>(opt => opt.UseNpgsql(CreateConnectionStringForTest()));
            return services.BuildServiceProvider();
        }

        private static string CreateConnectionStringForTest()
        {
            return "Host=localhost;Database=HospitalTestDb;Username=postgres;Password=password;";
        }

        private static void InitializeDatabase(HospitalDbContext context)
        {
            if (isDbCreated) return;
            isDbCreated = true;

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            context.Database.ExecuteSqlRaw("TRUNCATE TABLE \"BloodSupply\";");
            context.Database.ExecuteSqlRaw("TRUNCATE TABLE \"Doctors\" RESTART IDENTITY CASCADE;");
            context.Database.ExecuteSqlRaw("TRUNCATE TABLE \"Equipments\" RESTART IDENTITY CASCADE;");
            context.Database.ExecuteSqlRaw("TRUNCATE TABLE \"Beds\" RESTART IDENTITY CASCADE;");
            context.Database.ExecuteSqlRaw("TRUNCATE TABLE \"Rooms\" RESTART IDENTITY CASCADE;");
            context.Database.ExecuteSqlRaw("TRUNCATE TABLE \"Buildings\" RESTART IDENTITY CASCADE;");
            context.Database.ExecuteSqlRaw("TRUNCATE TABLE \"Addresses\" RESTART IDENTITY CASCADE;");
            context.Database.ExecuteSqlRaw("TRUNCATE TABLE \"Patients\" RESTART IDENTITY CASCADE;");
            context.Database.ExecuteSqlRaw("TRUNCATE TABLE \"Vacations\" RESTART IDENTITY CASCADE;");
            context.Database.ExecuteSqlRaw("TRUNCATE TABLE \"Appointments\" RESTART IDENTITY CASCADE;");
            context.Database.ExecuteSqlRaw("TRUNCATE TABLE \"Users\" RESTART IDENTITY CASCADE;");
            context.Database.ExecuteSqlRaw("TRUNCATE TABLE \"Reports\" RESTART IDENTITY CASCADE;");
            context.Database.ExecuteSqlRaw("TRUNCATE TABLE \"Symptoms\" RESTART IDENTITY CASCADE;");
            context.Database.ExecuteSqlRaw("TRUNCATE TABLE \"Medicines\" RESTART IDENTITY CASCADE;");
            context.Database.ExecuteSqlRaw("TRUNCATE TABLE \"RoomsEquipment\" RESTART IDENTITY CASCADE;");
            context.Database.ExecuteSqlRaw("TRUNCATE TABLE \"Admissions\" RESTART IDENTITY CASCADE;");

            Address address = new Address { Id = new Guid("f6927bfe-0246-4e2b-94e1-4b8123ef3ea2"), Street = "Ulica", StreetNumber = "10", City = "Grad", Country = "Država" };
            context.Addresses.Add(address);

            Building building = new Building { Id = new Guid("f6923bfe-0246-4e2b-94e1-4b8023ef3ea2"), Name = "Zgrada" };
            context.Buildings.Add(building);

            Room room = new Room { Id = new Guid("f6927bfe-0246-4e2b-94e1-4b8023ef3ea2"), Name = "Soba", Number = 10, Description = "Opis sobe" };
            context.Rooms.Add(room);

            String WorkingTimeStart1 = "9:00";
            String WorkingTimeEnd1 = "12:00";
            String Speciality1 = "Surgeon";
            String LicenceNum1 = "12345";


            Doctor doctor = new Doctor(new Guid("5c036fba-1118-4f4b-b153-90d75e60625e"), "Test Doctor", "Test Doctor",
                new DateTime(1973, 9, 28, 0, 0, 0), Gender.Female, address, new Jmbg("1807000730038"),
                new Email("doctor@test.com"), "066/123-456", LicenceNum1, Speciality1, WorkingTimeStart1,
                WorkingTimeEnd1, room.Id, room);

            String WorkingTimeStart = "9:00";
            String WorkingTimeEnd = "12:00";
            String Speciality = "Surgeon";
            String LicenceNum = "12345";

            Doctor doctor1 = new Doctor(new Guid("5c036fba-1318-4f4b-b153-90d75e60625e"), "Test Doctor", "Test Doctor",
                new DateTime(1973, 9, 28, 0, 0, 0), Gender.Female, address, new Jmbg("1807000730038"),
                new Email("doctor@test.com"), "066/123-456", LicenceNum, Speciality, WorkingTimeStart,
                WorkingTimeEnd, room.Id, room);

            Doctor doctorConsilium = new Doctor(new Guid("5c125fba-1318-4f4b-b153-90d75e60625e"), "Test Doctor Sastanak", "Test Doctor Sastanak",
                new DateTime(1973, 9, 28, 0, 0, 0), Gender.Female, address, new Jmbg("1807000730038"),
                new Email("doctor@test.com"), "066/123-456", "12345", "Surgeon", "1:00",
                "21:00", room.Id, room);
         
            context.Doctors.Add(doctor);
            context.Doctors.Add(doctor1);
            context.Doctors.Add(doctorConsilium);
            

            BloodSupply bloodSupply1 = new BloodSupply { BloodType = BloodType.FromString("A+"), Amount = 200.00 };
            context.BloodSupply.Add(bloodSupply1);

            BloodSupply bloodSupply2 = new BloodSupply { BloodType = BloodType.FromString("B+"), Amount = 0.00 };
            context.BloodSupply.Add(bloodSupply2);

            //Symptoms
            Symptom symptom1 = new Symptom (new Guid(), "Povišena temperatura");
            Symptom symptom2 = new Symptom (new Guid(), "Suv kašalj");

            context.Symptoms.Add(symptom1);
            context.Symptoms.Add(symptom2);

            //Medicines
            Medicine medicine1 = new Medicine(new Guid(), "Aspirin");
            Medicine medicine2 = new Medicine (new Guid(), "Brufen");

            context.Medicines.Add(medicine1);
            context.Medicines.Add(medicine2);

            List<Prescription> prescriptions = new List<Prescription>();
            List<Medicine> medicines = new List<Medicine>();
            medicines.Add(medicine1);
            medicines.Add(medicine2);

            Patient patient = new Patient(new Guid("f6927bfe-0246-4e2b-94e1-4b8023ef3ea1"), "Petar", "Popovic", DateTime.Now, Gender.Male, address, new Jmbg("1807000730038"),
                new Email("mail@gmail.pir"), "066413242", BloodType.FromString("A+"));
            patient.AppointTheChosenDoctor(doctor1);

            Patient patient2 = new Patient(new Guid("1d9aae17-fc67-4a7c-b05e-815fb94c4639"), "Petar", "Popovic", DateTime.Now, Gender.Male, address, new Jmbg("1807000730038"),
                new Email("mail@gmail.pir"), "066413242", BloodType.FromString("A+"));
            patient2.AppointTheChosenDoctor(doctor1);


            context.Patients.Add(patient);
            context.Patients.Add(patient2);



            MedicalAppointment medicalAppointment = new MedicalAppointment(
                new Guid("9d01e700-70a4-4b1c-958c-2c587ec94b4b"),
                new DateRange(DateTime.Now, DateTime.Now.AddMinutes(30)),
                room.Id, null, new Guid("5c036fba-1118-4f4b-b153-90d75e60625e"), null, patient.Id, null, false);
            // {
            //     RoomId = room.Id,
            //     Id = new Guid("9d01e700-70a4-4b1c-958c-2c587ec94b4b"),
            //     DoctorId = new Guid("5c036fba-1118-4f4b-b153-90d75e60625e"),
            //     PatientId = patient.Id
            // };

            Prescription prescription = new Prescription(medicines);
            prescriptions.Add(prescription);
            List<Symptom> symptoms = new List<Symptom>();
            symptoms.Add(symptom1);
            symptoms.Add(symptom2);

            Report report = new Report(new Guid("058eb841-3975-4c7a-83ad-8b81dd6744d9"), new Guid("9d01e700-70a4-4b1c-958c-2c587ec94b4b"),
                "Opaka bolest", symptoms,prescriptions, new DateTime(2022, 9, 28, 0, 0, 0));
            
            /*Report report = new Report
            {
                Id = new Guid("058eb841-3975-4c7a-83ad-8b81dd6744d9"),
                MedicalAppointmentId = new Guid("9d01e700-70a4-4b1c-958c-2c587ec94b4b"),
                Text = "Opaka bolest",
                Symptoms = symptoms,
                Prescriptions = prescriptions,
                DateTime = new DateTime()
            };*/
            Guid Id = new Guid("9b75b261-e305-4f6f-9990-97cb2d13d174");
            Guid PatientId = patient.Id;
            Reason Reason = new Reason("Glavobolja");            
            DateTime arrivalDate = DateTime.Now;
            Admission admission = new Admission(Id, patient.Id, patient, Reason, room.Id, room, arrivalDate, new Guid(), new Treatment())
            {
                
            };
            context.Admissions.Add(admission);

            AdmissionHistory admissionHistory = new AdmissionHistory
            {
                Id = new Guid("11942a9c-100e-489a-8434-98704889d8ed"),
                AdmissionId = admission.Id,
                Admission = admission,
                DischargeReason = "Resen problem",
                DischargeDate = DateTime.Now
            };
            context.AdmissionHistories.Add(admissionHistory);

            Vacation vacationWFA = new Vacation
            {
                Id = new Guid("5c036fba-1128-4f4b-b153-90d75e60625e"),
                DoctorId = new Guid("5c036fba-1118-4f4b-b153-90d75e60625e"),
                DateStart = DateTime.Now,
                DateEnd = DateTime.Now.AddDays(30),
                Reason = "Zato sto mi je dodijalo",
                Urgent = false,
                VacationStatus = VacationStatus.Waiting_For_Approval,
                DeniedRequestReason = ""
            };
            Vacation vacationA = new Vacation
            {
                Id = new Guid("5c036fba-1138-4f4b-b153-90d75e60625e"),
                DoctorId = new Guid("5c036fba-1118-4f4b-b153-90d75e60625e"),
                DateStart = DateTime.Now,
                DateEnd = DateTime.Now.AddDays(30),
                Reason = "Zato sto mi je dodijalo",
                Urgent = false,
                VacationStatus = VacationStatus.Approved,
                DeniedRequestReason = ""
            };

            Vacation vacation1 = new Vacation
            {
                Id = new Guid("5c036fba-1118-4f4b-b153-90d75e60625e"),
                DoctorId = new Guid("5c036fba-1118-4f4b-b153-90d75e60625e"),
                DateStart = new DateTime(2022, 10, 10),
                DateEnd = new DateTime(2022,10,17),
                Reason = "Zato sto mi je dodijalo",
                Urgent = true,
                VacationStatus = VacationStatus.Approved,
                DeniedRequestReason = "Nesto"
            };
            Vacation vacation2 = new Vacation
            {
                Id = new Guid("5c036fba-1108-4f4b-b153-90d75e60625e"),
                DoctorId = new Guid("5c036fba-1118-4f4b-b153-90d75e60625e"),
                DateStart = new DateTime(2022, 5, 10),
                DateEnd = new DateTime(2022, 5, 17),
                Reason = "Zato sto mi je dodijalo",
                Urgent = false,
                VacationStatus = VacationStatus.Approved,
                DeniedRequestReason = ""
            };

            context.Vacations.Add(vacationA);
            context.Vacations.Add(vacationWFA);
            context.Vacations.Add(vacation1);
            context.Vacations.Add(vacation2);

            // BEDS


            Equipment eq = new Equipment
            {
                Id = new Guid("5c036fba-1118-4f4b-b153-90d75e606299"),
                Name = "Krevet",
            };
            Equipment eq2 = new Equipment
            {
                Id = new Guid("497f7913-2139-4091-9a4c-0091d3b76216"),
                Name = "Stalak za infuziju",
            };
            Equipment eq3 = new Equipment
            {
                Id = new Guid("a8402f72-7a2f-47a0-8bd0-fc0bf6b698d0"),
                Name = "Racunar",
            };

            context.Equipments.Add(eq);
            context.Equipments.Add(eq2);
            context.Equipments.Add(eq3);

            Bed bed1 = new Bed
            {
                Id = new Guid("5c036fba-1118-4f4b-b153-90d75e606251"),
                IsFree = true,
                equipmentId = new Guid("5c036fba-1118-4f4b-b153-90d75e606299"),

            };
            Bed bed2 = new Bed
            {
                Id = new Guid("5c036fba-1118-4f4b-b153-90d75e606252"),
                IsFree = true,
                equipmentId = new Guid("5c036fba-1118-4f4b-b153-90d75e606299"),
                equipment = null,
            };
            Bed bed3 = new Bed
            {
                Id = new Guid("5c036fba-1118-4f4b-b153-90d75e606253"),
                IsFree = false,
                equipmentId = new Guid("5c036fba-1118-4f4b-b153-90d75e606299"),
                equipment = null,
            };
            context.Beds.Add(bed1);
            context.Beds.Add(bed2);
            context.Beds.Add(bed3);

            context.MedicalAppointments.Add(medicalAppointment);

            // PATIENT ROOMS

            PatientRoom patientRoom = new PatientRoom
            {
                Id = new Guid("5c036fba-1318-4f4b-b153-90d75e606000"),
                Name = "Ime sobee",
                Number = 10,
                Description = "Opis",
                BedIds = new List<Guid>(),
            };

            patientRoom.BedIds.Add(bed1.Id);

            context.Rooms.Add(patientRoom);

            Appointment schedule = new Appointment(new Guid("95a7ac4d-4f11-4530-995b-436f484599e7"),
                new DateRange(DateTime.Now, DateTime.Now.AddMinutes(30)), room.Id, null);
            // {
            //     Id = new Guid("95a7ac4d-4f11-4530-995b-436f484599e7"),
            //     IsDone = false,
            //     RoomId = room.Id
            // };
            Appointment schedule2 = new Appointment(new Guid("890e4ba4-e968-4cb6-ab86-aac1b525d224"),
                new DateRange(DateTime.Now, DateTime.Now.AddMinutes(30)), room.Id, null);
            schedule2.FinishAppointment();
            // {
            //     Id = new Guid("890e4ba4-e968-4cb6-ab86-aac1b525d224"),
            //     IsDone = true,
            //     RoomId = room.Id
            // };

            context.Appointments.Add(schedule);
            context.Appointments.Add(schedule2);

            //Users
            initUsers(context);

            //Consiliums
            initConsiliums(context, doctorConsilium);

            // Rooms
            initRooms(context);
            // Relocation Appointments
            initRenovation(context);
            
            //Medical appointments
            initMedicalAppointments(context);
            initMedicalAppointmentSchedulingSessions(context);
            initMedicalAppointmentReportSessions(context);
            InitAgeGroups(context);
            initRenovationSessions(context);

            context.SaveChanges();

            isDbCreated = false;
        }

        private static void initUsers(HospitalDbContext context)
        {

            User user1 = new User("user", new Password("pass123"), UserRole.Patient);
            user1.ActivateAccount();
            user1.ConnectPersonToUser(new Guid("f6927bfe-0246-4e2b-94e1-4b8023ef3ea1"));


            User managerUser = new User("manager", new Password("manager123"), UserRole.Manager);
            managerUser.ActivateAccount();
            managerUser.ConnectPersonToUser(null);

            User userInactive = new User("notactive", new Password("notactive123"), UserRole.Patient);
            userInactive.ConnectPersonToUser(new Guid("1d9aae17-fc67-4a7c-b05e-815fb94c4639"));

            User doctorUser = new User("doc", new Password("doc123"), UserRole.Doctor);
            doctorUser.ActivateAccount();
            doctorUser.ConnectPersonToUser(new Guid("5c036fba-1118-4f4b-b153-90d75e60625e"));

            context.Add(user1);
            context.Add(userInactive);
            context.Add(managerUser);
            context.Add(doctorUser);
        }

        private static void initConsiliums(HospitalDbContext context, Doctor doctor)
        {
            Room room = new Room { Id = new Guid("5c036fba-1318-4f4b-b153-90d75e606111"), Name = "Soba", Number = 10, Description = "ConsiliumRoom" };
            context.Rooms.Add(room);
            List<Doctor> doctorList = new List<Doctor>();
            doctorList.Add(doctor);
            /*Consilium con1 = new Consilium
            {
                Id = new Guid("890e4ba4-e968-4cb6-ab86-aac1b525d225"),
                IsDone = false,
                RoomId = new Guid("5c036fba-1318-4f4b-b153-90d75e606111"),
                DateRange = new DateRange(),
                Doctors = doctorList,
            };

            context.Add(con1);*/

            
        }
        private static void initRenovation(HospitalDbContext context)
        {
            List<RoomRenovationPlan> plans1 = new List<RoomRenovationPlan>();
            plans1.Add(new RoomRenovationPlan(new Guid("fbcf2919-ef1c-49fe-9556-f99188bdbad9")));
            plans1.Add(new RoomRenovationPlan(new Guid("18e98c94-5081-4020-ac91-d00f995c7e4f")));
            plans1.Add(new RoomRenovationPlan(
                "Description233",
                "Name8211",
                212
                ));


            RenovationAppointment renovation1 = new RenovationAppointment(
                RenovationAppointment.TypeOfRenovation.Merge,
                plans1,
                new DateRange(DateTime.Now.AddDays(3), DateTime.Now.AddDays(4)),
                new Guid("fbcf2919-ef1c-49fe-9556-f99188bdbad9")
            );

            RenovationAppointment renovation2 = new RenovationAppointment(
                RenovationAppointment.TypeOfRenovation.Merge,
                plans1,
                new DateRange(DateTime.Now.AddDays(4), DateTime.Now.AddDays(5)),
                new Guid("18e98c94-5081-4020-ac91-d00f995c7e4f")
            );

            List<RoomRenovationPlan> plans2 = new List<RoomRenovationPlan>();
            plans2.Add(new RoomRenovationPlan(new Guid("e2689a81-c248-4686-a807-5e6796a90857")));
            plans2.Add(new RoomRenovationPlan(
                "Desipt33",
                "Nam1",
                85
                ));
            plans2.Add(new RoomRenovationPlan(
                "asd33",
                "Na11",
                23
                ));

            RenovationAppointment renovation3 = new RenovationAppointment(
               RenovationAppointment.TypeOfRenovation.Split,
               plans2,
               new DateRange(DateTime.Now.AddDays(4), DateTime.Now.AddDays(5)),
               new Guid("e2689a81-c248-4686-a807-5e6796a90857")
           );

            context.RenovationAppointments.Add(renovation1);
            context.RenovationAppointments.Add(renovation2);
            context.RenovationAppointments.Add(renovation3);
        }
        private static void initRooms(HospitalDbContext context)
        {
            List<RoomsEquipment> list = new List<RoomsEquipment>();
            list.Add(new RoomsEquipment(new Guid("a8402f72-7a2f-47a0-8bd0-fc0bf6b698d0"), new Guid("fbcf2919-ef1c-49fe-9556-f99188bdbad9"), 3));

            Room room = new Room(
                new Guid("fbcf2919-ef1c-49fe-9556-f99188bdbad9"),
                "Description",
                "Name82",
                20,
                list
            );

            List<RoomsEquipment> list2 = new List<RoomsEquipment>();
            list2.Add(new RoomsEquipment(new Guid("a8402f72-7a2f-47a0-8bd0-fc0bf6b698d0"), new Guid("18e98c94-5081-4020-ac91-d00f995c7e4f"), 1));
            list2.Add(new RoomsEquipment(new Guid("497f7913-2139-4091-9a4c-0091d3b76216"), new Guid("18e98c94-5081-4020-ac91-d00f995c7e4f"), 3));

            Room room2 = new Room(
                new Guid("18e98c94-5081-4020-ac91-d00f995c7e4f"),
                "Description2",
                "Name821",
                21,
                list2
            );

            List<RoomsEquipment> list3 = new List<RoomsEquipment>();
            list3.Add(new RoomsEquipment(new Guid("a8402f72-7a2f-47a0-8bd0-fc0bf6b698d0"), new Guid("e2689a81-c248-4686-a807-5e6796a90857"), 5));
            list3.Add(new RoomsEquipment(new Guid("497f7913-2139-4091-9a4c-0091d3b76216"), new Guid("e2689a81-c248-4686-a807-5e6796a90857"), 1));

            Room room3 = new Room(
                new Guid("e2689a81-c248-4686-a807-5e6796a90857"),
                "Description3",
                "Name83",
                22,
                list3
            );

            context.Rooms.Add(room);
            context.Rooms.Add(room2);
            context.Rooms.Add(room3);
        }

        private static void initMedicalAppointments(HospitalDbContext context)
        {
            Address address = new Address { Id = new Guid("f6927bfe-0246-4e2b-94e1-4b8123ef3ea3"), Street = "Ulica", StreetNumber = "10", City = "Grad", Country = "Država" };
            Room room = new Room { Id = new Guid("f6927bfe-0246-4e2b-94e1-4b8023ef3ea3"), Name = "Soba", Number = 10, Description = "Opis sobe" };
            Doctor doctor= new Doctor(new Guid("5c125fba-1318-4f4b-b153-90d75e60626e"), "Test Doctor Sastanak", "Test Doctor Sastanak",
                new DateTime(1973, 9, 28, 0, 0, 0), Gender.Female, address, new Jmbg("1807000730038"),
                new Email("doctor@test.com"), "066/123-456", "12345", "Surgeon", "03:00",
                "05:00", room.Id, room);
            
            Patient patient = new Patient(new Guid("a6937bfe-0246-4e2b-94e1-4b8023ef3ea1"), "Petar", "Popovic", DateTime.Now, Gender.Male, address, new Jmbg("1807000730038"),
                new Email("mail@gmail.pir"), "066413242", BloodType.FromString("A+"));
            patient.AppointTheChosenDoctor(doctor);

            var dateStart = new DateTime(2022, 12, 26, 4, 0, 0);
            MedicalAppointment medicalAppointment = new MedicalAppointment(
                new Guid("9d01e769-70a4-4b1c-958c-2c587ec94b4b"),
                new DateRange(dateStart, dateStart.AddMinutes(30)),
                room.Id, null, new Guid("5c125fba-1318-4f4b-b153-90d75e60626e"), null, patient.Id, null, false);

            context.Addresses.Add(address);
            context.Rooms.Add(room);
            context.Doctors.Add(doctor);
            context.Patients.Add(patient);
            context.MedicalAppointments.Add(medicalAppointment);
            
        }

        private static void initMedicalAppointmentSchedulingSessions(HospitalDbContext context)
        {
            
            Address address = new Address
            {
                Id = new Guid("f6927bfe-1246-4e2b-94e1-4b8123ef3ea3"), Street = "Ulica", StreetNumber = "10", City = "Grad",
                Country = "Država"
            };
            
            Room room = new Room
            {
                Id = new Guid("f6927bfe-1246-4e2b-94e1-4b8023ef3ea3"), Name = "Soba", Number = 10, Description = "Opis sobe"
            };
            
            Doctor doctor = new Doctor(new Guid("1c125fba-1318-4f4b-b153-90d75e60626e"), "Test Doctor Sastanak",
                "Test Doctor Sastanak",
                new DateTime(1973, 9, 28, 0, 0, 0), Gender.Female, address, new Jmbg("0811000800021"),
                new Email("doctor@test.com"), "066/123-456", "12345", "Surgeon", "03:00",
                "05:00", room.Id, room);
            
            
            
            Patient patient = new Patient(Guid.NewGuid(), "Zakazivac", "Zakazivacevic", new DateTime(1990, 3, 21),
                Gender.Male, new Address(Guid.NewGuid(), "Novi Sad", "Serbia", "Paragovska", "72"),
                new Jmbg("0811000800021"), new Email("zakazivac@gmail.com"), "0612371234",
                new BloodType(BloodGroup.B, RhFactor.NEGATIVE));
            patient.AppointTheChosenDoctor(doctor);
            
            
            context.Addresses.Add(address);
            context.Rooms.Add(room);
            context.Doctors.Add(doctor);
            context.Patients.Add(patient);
            
            DateTime currentTime = DateTime.Now;
            Guid unfinishedAggregateId = new Guid("0e34318e-0bf6-4c8d-8b0e-153dae18d80b");
            context.MedicalAppointmentSchedulingSessionEvents.Add(new HospitalLibrary.MedicalAppointmentSchedulingSession.Events.StartedScheduling(unfinishedAggregateId, currentTime, patient));
            context.MedicalAppointmentSchedulingSessionEvents.Add(new ChosenDate(unfinishedAggregateId, currentTime.AddSeconds(5), new DateTime(2023, 4, 4)));
            context.MedicalAppointmentSchedulingSessionEvents.Add(new ChosenSpeciality(unfinishedAggregateId, currentTime.AddSeconds(10), "Chiropractor"));
            context.MedicalAppointmentSchedulingSessionEvents.Add(new ChosenDoctor(unfinishedAggregateId, currentTime.AddSeconds(15), doctor));
            context.MedicalAppointmentSchedulingSessionEvents.Add(new HospitalLibrary.MedicalAppointmentSchedulingSession.Events.GoneBackToSelection(unfinishedAggregateId, currentTime.AddSeconds(20), Selection.Speciality));
            context.MedicalAppointmentSchedulingSessionEvents.Add(new ChosenSpeciality(unfinishedAggregateId, currentTime.AddSeconds(25), "Physician"));
            context.MedicalAppointmentSchedulingSessionEvents.Add(new ChosenDoctor(unfinishedAggregateId, currentTime.AddSeconds(30), doctor));

            Guid finishedAggregateId = new Guid("055f61ca-9487-495f-8229-590c24e7b7da");
            context.MedicalAppointmentSchedulingSessionEvents.Add(new HospitalLibrary.MedicalAppointmentSchedulingSession.Events.StartedScheduling(finishedAggregateId, currentTime, patient));
            context.MedicalAppointmentSchedulingSessionEvents.Add(new ChosenDate(finishedAggregateId, currentTime.AddSeconds(5), new DateTime(2023, 4, 4)));
            context.MedicalAppointmentSchedulingSessionEvents.Add(new ChosenSpeciality(finishedAggregateId, currentTime.AddSeconds(10), "Chiropractor"));
            context.MedicalAppointmentSchedulingSessionEvents.Add(new ChosenDoctor(finishedAggregateId, currentTime.AddSeconds(15), doctor));
            context.MedicalAppointmentSchedulingSessionEvents.Add(new HospitalLibrary.MedicalAppointmentSchedulingSession.Events.FinishedScheduling(finishedAggregateId, currentTime.AddSeconds(20), new DateTime(2023, 1, 14, 12,30,0)));

        }

        private static void initMedicalAppointmentReportSessions(HospitalDbContext context)
        {

            Address address = new Address
            {
                Id = Guid.NewGuid(),
                Street = "Ulica",
                StreetNumber = "10",
                City = "Grad",
                Country = "Država"
            };

            Room room = new Room
            {
                Id = Guid.NewGuid(),
                Name = "Soba",
                Number = 10,
                Description = "Opis sobe"
            };

            Doctor doctor = new Doctor(Guid.NewGuid(), "Test Doctor Report",
                "Test Doctor Report",
                new DateTime(1980, 10, 1, 0, 0, 0), Gender.Male, address, new Jmbg("0811000800021"),
                new Email("doctorreport@test.com"), "066/123-456", "12345", "Surgeon", "09:00",
                "15:00", room.Id, room);


            Patient patient = new Patient(Guid.NewGuid(), "Test Patient Report", "Test Patient Report", new DateTime(1990, 10, 1),
                Gender.Female, new Address(Guid.NewGuid(), "Novi Sad", "Serbia", "Ulica 1", "50"),
                new Jmbg("0811000800021"), new Email("pacijent@gmail.com"), "066/555-666",
                new BloodType(BloodGroup.O, RhFactor.POSITIVE));
            patient.AppointTheChosenDoctor(doctor);


            context.Addresses.Add(address);
            context.Rooms.Add(room);
            context.Doctors.Add(doctor);
            context.Patients.Add(patient);

            DateTime currentTime = DateTime.Now;
            Guid unfinishedAggregateId = new Guid("4f82557d-2a4d-4f1f-9f0f-02196f1a7d4f");
            context.MedicalAppointmentReportSessionEvents.Add(new HospitalLibrary.MedicalAppointmentReportSession.Model.Events.StartedScheduling(unfinishedAggregateId, currentTime, doctor));
            context.MedicalAppointmentReportSessionEvents.Add(new ChosenSymptom(unfinishedAggregateId, currentTime.AddSeconds(5), 2));
            context.MedicalAppointmentReportSessionEvents.Add(new ChosenReportText(unfinishedAggregateId, currentTime.AddSeconds(10), "Report text 1"));
            context.MedicalAppointmentReportSessionEvents.Add(new ChosenMedicine(unfinishedAggregateId, currentTime.AddSeconds(15), 1));
            context.MedicalAppointmentReportSessionEvents.Add(new HospitalLibrary.MedicalAppointmentReportSession.Model.Events.GoneBackToSelection(unfinishedAggregateId, currentTime.AddSeconds(20), SelectionReport.ReportText));
            context.MedicalAppointmentReportSessionEvents.Add(new ChosenReportText(unfinishedAggregateId, currentTime.AddSeconds(25), "Fixed report text"));
            context.MedicalAppointmentReportSessionEvents.Add(new ChosenMedicine(unfinishedAggregateId, currentTime.AddSeconds(30), 1));

            Guid finishedAggregateId = new Guid("c4b12ea1-417c-4f89-9028-67077a229661");
            context.MedicalAppointmentReportSessionEvents.Add(new HospitalLibrary.MedicalAppointmentReportSession.Model.Events.StartedScheduling(finishedAggregateId, currentTime, doctor));
            context.MedicalAppointmentReportSessionEvents.Add(new ChosenSymptom(finishedAggregateId, currentTime.AddSeconds(5), 1));
            context.MedicalAppointmentReportSessionEvents.Add(new ChosenReportText(finishedAggregateId, currentTime.AddSeconds(10), "Report text 2"));
            context.MedicalAppointmentReportSessionEvents.Add(new ChosenMedicine(finishedAggregateId, currentTime.AddSeconds(15), 2));
            context.MedicalAppointmentReportSessionEvents.Add(new HospitalLibrary.MedicalAppointmentReportSession.Model.Events.FinishedScheduling(finishedAggregateId, currentTime.AddSeconds(20), new DateTime(2023, 1, 20, 12, 0, 0)));

        }

        private static void initRenovationSessions(HospitalDbContext context) {
            Guid rootId = Guid.NewGuid();
            SessionStarted sessionStarted = new SessionStarted(rootId);
            TypeChosen typeChosen = new TypeChosen(rootId,RenovationAppointment.TypeOfRenovation.Merge);

            List<RoomRenovationPlan> oldRooms = new List<RoomRenovationPlan>();
            oldRooms.Add(new RoomRenovationPlan(Guid.Parse("fbcf2919-ef1c-49fe-9556-f99188bdbad9")));
            oldRooms.Add(new RoomRenovationPlan(Guid.Parse("18e98c94-5081-4020-ac91-d00f995c7e4f")));
            OldRoomsChosen oldRoomsChosen =  new OldRoomsChosen(rootId, oldRooms);

            TimeframeCreated timeframeCreated = new TimeframeCreated(rootId, DateTime.Now.AddDays(22), DateTime.Now.AddDays(23));
            SpecificTimeChosen specificTimeChosen = new SpecificTimeChosen(rootId, DateTime.Now.AddDays(22), DateTime.Now.AddDays(23));

            List<RoomRenovationPlan> newRooms = new List<RoomRenovationPlan>();
            newRooms.Add(new RoomRenovationPlan("Na8211","Description123",212));
            NewRoomsCreated newRoomsCreated = new NewRoomsCreated(rootId, newRooms);         

            SessionEnded sessionEnded = new SessionEnded(rootId);

            RenovationSessionAggregateRoot root = new RenovationSessionAggregateRoot(rootId);
            root.StartSession();
            root.ChooseType(typeChosen.AggregateId, typeChosen.TypeOfRenovationChosen);
            root.ChooseOldRooms(oldRoomsChosen.AggregateId, oldRoomsChosen.RoomRenovationPlans);
            root.CreateTimeframe(timeframeCreated.AggregateId, timeframeCreated.Start, timeframeCreated.End);
            root.ChooseSpecificTime(specificTimeChosen.AggregateId, specificTimeChosen.Start, specificTimeChosen.End);
            root.CreateNewRooms(newRoomsCreated.AggregateId, newRoomsCreated.RoomRenovationPlans);
            root.EndSession(sessionEnded.AggregateId);

            context.RenovationSessionAggregateRoots.Add(root);

            context.RenovationSessionEvents.Add(sessionStarted);
            context.RenovationSessionEvents.Add(oldRoomsChosen);
            context.RenovationSessionEvents.Add(timeframeCreated);
            context.RenovationSessionEvents.Add(specificTimeChosen);
            context.RenovationSessionEvents.Add(sessionEnded);
            context.RenovationSessionEvents.Add(newRoomsCreated);


            Guid rootId2 = Guid.NewGuid();
            SessionStarted sessionStarted2 = new SessionStarted(rootId2);
            TypeChosen typeChosen2 = new TypeChosen(rootId2,RenovationAppointment.TypeOfRenovation.Merge);

            List<RoomRenovationPlan> oldRooms2 = new List<RoomRenovationPlan>();
            oldRooms.Add(new RoomRenovationPlan(Guid.Parse("fbcf2919-ef1c-49fe-9556-f99188bdbad9")));
            oldRooms.Add(new RoomRenovationPlan(Guid.Parse("18e98c94-5081-4020-ac91-d00f995c7e4f")));
            OldRoomsChosen oldRoomsChosen2 =  new OldRoomsChosen(rootId2, oldRooms);

            TimeframeCreated timeframeCreated2 = new TimeframeCreated(rootId2, DateTime.Now.AddDays(22), DateTime.Now.AddDays(23));
            SpecificTimeChosen specificTimeChosen2 = new SpecificTimeChosen(rootId2, DateTime.Now.AddDays(22), DateTime.Now.AddDays(23));

            List<RoomRenovationPlan> newRooms2 = new List<RoomRenovationPlan>();
            newRooms.Add(new RoomRenovationPlan("Na8211","Description123",212));
            NewRoomsCreated newRoomsCreated2 = new NewRoomsCreated(rootId2, newRooms);         

            ReturnedToNewRoomCreation returnedToNewRoomCreation = new ReturnedToNewRoomCreation(rootId2);
            ReturnedToSpecificTimeSelection returnedToSpecificTimeSelection = new ReturnedToSpecificTimeSelection(rootId2);
            ReturnedToTimeframeCreation returnedToTimeframeCreation = new ReturnedToTimeframeCreation(rootId2);
            ReturnedToOldRoomsSelection returnedToOldRoomsSelection = new ReturnedToOldRoomsSelection(rootId2);
            ReturnedToTypeSelection returnedToType = new ReturnedToTypeSelection(rootId2);
            
            TypeChosen typeChosen3 = new TypeChosen(rootId2,RenovationAppointment.TypeOfRenovation.Merge);
            OldRoomsChosen oldRoomsChosen3 =  new OldRoomsChosen(rootId2, oldRooms);

            TimeframeCreated timeframeCreated3 = new TimeframeCreated(rootId2, DateTime.Now.AddDays(28), DateTime.Now.AddDays(29));
            SpecificTimeChosen specificTimeChosen3 = new SpecificTimeChosen(rootId2, DateTime.Now.AddDays(28), DateTime.Now.AddDays(29));

            NewRoomsCreated newRoomsCreated3 = new NewRoomsCreated(rootId2, newRooms); 
            

            SessionEnded sessionEnded2 = new SessionEnded(rootId2);


            RenovationSessionAggregateRoot root2 = new RenovationSessionAggregateRoot(rootId2);
            root2.StartSession();
            root2.ChooseType(typeChosen2.AggregateId, typeChosen2.TypeOfRenovationChosen);
            root2.ChooseOldRooms(oldRoomsChosen2.AggregateId, oldRoomsChosen2.RoomRenovationPlans);
            root2.CreateTimeframe(timeframeCreated2.AggregateId, timeframeCreated2.Start, timeframeCreated2.End);
            root2.ChooseSpecificTime(specificTimeChosen2.AggregateId, specificTimeChosen2.Start, specificTimeChosen2.End);
            root2.CreateNewRooms(newRoomsCreated2.AggregateId, newRoomsCreated2.RoomRenovationPlans);
            root2.ReturnToNewRoomCreation(returnedToNewRoomCreation.AggregateId);
            root2.ReturnToSpecificTimeSelection(returnedToSpecificTimeSelection.AggregateId);
            root2.ReturnToTimeframeCreation(returnedToTimeframeCreation.AggregateId);
            root2.ReturnToOldRoomSelection(returnedToOldRoomsSelection.AggregateId);
            root2.ReturnToTypeSelection(returnedToType.AggregateId);
            root2.ChooseType(typeChosen3.AggregateId, typeChosen3.TypeOfRenovationChosen);
            root2.ChooseOldRooms(oldRoomsChosen3.AggregateId, oldRoomsChosen3.RoomRenovationPlans);
            root2.CreateTimeframe(timeframeCreated3.AggregateId, timeframeCreated3.Start, timeframeCreated3.End);
            root2.ChooseSpecificTime(specificTimeChosen3.AggregateId, specificTimeChosen3.Start, specificTimeChosen3.End);
            root2.CreateNewRooms(newRoomsCreated3.AggregateId, newRoomsCreated3.RoomRenovationPlans);
            root2.EndSession(sessionEnded2.AggregateId);

            context.RenovationSessionAggregateRoots.Add(root2);

            context.RenovationSessionEvents.Add(sessionStarted2);
            context.RenovationSessionEvents.Add(oldRoomsChosen2);
            context.RenovationSessionEvents.Add(timeframeCreated2);
            context.RenovationSessionEvents.Add(specificTimeChosen2);
            context.RenovationSessionEvents.Add(newRoomsCreated2);
            context.RenovationSessionEvents.Add(returnedToNewRoomCreation);
            context.RenovationSessionEvents.Add(returnedToSpecificTimeSelection);
            context.RenovationSessionEvents.Add(returnedToTimeframeCreation);
            context.RenovationSessionEvents.Add(returnedToOldRoomsSelection);
            context.RenovationSessionEvents.Add(returnedToType);
            context.RenovationSessionEvents.Add(oldRoomsChosen3);
            context.RenovationSessionEvents.Add(timeframeCreated3);
            context.RenovationSessionEvents.Add(specificTimeChosen3);
            context.RenovationSessionEvents.Add(newRoomsCreated3);
            context.RenovationSessionEvents.Add(sessionEnded2);

        }

        private static void InitAgeGroups(HospitalDbContext context)
        {
           context.AgeGroups.Add(new AgeGroup("Child", 0, 16));
           context.AgeGroups.Add(new AgeGroup("Young adults", 17, 30));
           context.AgeGroups.Add(new AgeGroup("Middle-aged adults", 31, 50));
           context.AgeGroups.Add(new AgeGroup("Old Adults", 51, 999));
        }

    }
}
