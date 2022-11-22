using HospitalAPI;
using HospitalLibrary.BloodSupplies.Model;
using HospitalLibrary.Settings;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System;
using HospitalLibrary.BuildingManagment.Model;
using HospitalLibrary.Doctors.Model;
using HospitalLibrary.Core.Model;
using HospitalLibrary.RoomsAndEqipment.Model;
using HospitalLibrary.Patients.Model;
using HospitalLibrary.Admissions.Model;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;

namespace TestHospitalApp.Setup
{
    public class TestDatabaseFactory<TStartup> : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseSolutionRelativeContentRoot("");

            builder.ConfigureServices(services =>
            {
                using var scope = BuildServiceProvider(services).CreateScope();
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<HospitalDbContext>();

                InitializeDatabase(db);
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
            context.Database.EnsureCreated();
            context.Database.ExecuteSqlRaw("TRUNCATE TABLE \"BloodSupply\";");
            context.Database.ExecuteSqlRaw("TRUNCATE TABLE \"Doctors\" RESTART IDENTITY CASCADE;");
            context.Database.ExecuteSqlRaw("TRUNCATE TABLE \"Rooms\" RESTART IDENTITY CASCADE;");
            context.Database.ExecuteSqlRaw("TRUNCATE TABLE \"Floors\" RESTART IDENTITY CASCADE;");
            context.Database.ExecuteSqlRaw("TRUNCATE TABLE \"Buildings\" RESTART IDENTITY CASCADE;");
            context.Database.ExecuteSqlRaw("TRUNCATE TABLE \"Addresses\" RESTART IDENTITY CASCADE;");
            context.Database.ExecuteSqlRaw("TRUNCATE TABLE \"Patients\" RESTART IDENTITY CASCADE;");

            context.Database.ExecuteSqlRaw("INSERT INTO \"Addresses\" (\"Id\", \"City\", \"Country\", \"Street\", \"StreetNumber\") VALUES ('9b75b261-e305-4f6f-9990-97cb2d06d774', 'Kibonsod', 'Serbia', 'Comanche', '8');");
            
            context.Database.ExecuteSqlRaw("INSERT INTO \"Buildings\" (\"Id\", \"Name\") VALUES ('4c08ff1f-0227-4a3c-93db-dcd865a1069b', 'Zgrada A')");

            context.Database.ExecuteSqlRaw("INSERT INTO \"Floors\" (\"Id\", \"Name\", \"Number\", \"BuildingId\") VALUES ('9845c31d-e22a-48f6-b9ef-f8fc13e5f21c', 'Sprat 1', '5', '4c08ff1f-0227-4a3c-93db-dcd865a1069b')");

            context.Database.ExecuteSqlRaw("INSERT INTO \"Rooms\" (\"Id\", \"Description\",\"Name\", \"Number\", \"Discriminator\", \"FloorId\", \"Workhours\") VALUES ('9ae3255d-261f-472f-a961-7f2e7d05d95c', 'diam id ornare imperdiet sapien urna pretium nisl ut volutpat sapien', 'nec dui luctus rutrum nulla tellus in sagittis dui vel nisl duis ac nibh fusce lacus purus', '2', 'DoctorRoom', '9845c31d-e22a-48f6-b9ef-f8fc13e5f21c', 'mauris lacinia sapien quis libero nullam sit amet turpis elementum ligula vehicula consequat morbi a ipsum');");

            context.Doctors.Add(new Doctor
            {
                Id = new Guid("5c036fba-1118-4f4b-b153-90d75e60625e"),
                Name = "Test Doctor",
                Surname = "Test Doctor",
                WorkingTimeStart = "9:00",
                WorkingTimeEnd = "12:00",
                Gender = Gender.Female,
                Birthdate = new DateTime(1973, 9, 28, 0, 0, 0),
                Jmbg = "12345",
                Email = "doctor@test.com",
                PhoneNumber = "066/123-456",
                Speciality = "Surgeon",
                LicenceNum = "12345",
                RoomId = new Guid("9ae3255d-261f-472f-a961-7f2e7d05d95c"),
                AddressId = new Guid("9b75b261-e305-4f6f-9990-97cb2d06d774")
            });

            context.BloodSupply.Add(new BloodSupply
            {
                Id = new Guid("b14fb18a-e0d9-460c-8dd5-043b0b87dfa4"),
                Type = "A+",
                Amount = 200.00
            });
            context.BloodSupply.Add(new BloodSupply
            {
                Id = new Guid("4996bada-9081-41e9-9fac-79c484237b3f"),
                Type = "B+",
                Amount = 0.00
            });
            context.Patients.Add(new Patient
            {
                Id = new Guid("4994cada-9081-41e9-9fac-79c484237b3f"),
                BloodType = BloodType.A_POS,
                ChoosenDoctorId = new Guid("5c036fba-1118-4f4b-b153-90d75e60625e"),
                Name = "Petar",
                Surname = "Popovic",
                Birthdate = DateTime.Now,
                Gender = Gender.Male,
                AddressId = new Guid("9b75b261-e305-4f6f-9990-97cb2d06d774"),
                Jmbg = "12312313",
                Email = "mail@gmail.krompir",
                PhoneNumber = "066413242"
            }) ;
            context.Admissions.Add(new Admission
            {
                Id = new Guid("9b75b261-e305-4f6f-9990-97cb2d13d174"),
                PatientId = new Guid("4994cada-9081-41e9-9fac-79c484237b3f"),
                Reason = "Razlog za otpust",
                RoomId = new Guid("9ae3255d-261f-472f-a961-7f2e7d05d95c"),
                arrivalDate = DateTime.Now
            }) ;

            context.SaveChanges();
        }
    }
}
