using System;
using System.Collections.Generic;
using System.Linq;
using HospitalLibrary.Consiliums.Model;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Doctors.Model;
using HospitalLibrary.Doctors.Repository;
using HospitalLibrary.Doctors.Service;
using HospitalLibrary.Patients.Model;
using HospitalLibrary.Patients.Repository;
using HospitalLibrary.RoomsAndEqipment.Model;
using IntegrationLibrary.Common;
using Moq;
using Shouldly;
using Xunit;

namespace TestHospitalApp.UnitTesting.DoctorTest
{
    public class SuitableDoctorTest
    {


        [Fact]
        public void SuitableDoctorsCount()
        {
            var doctorService = DoctorServiceSetup();

            int numberOfDoctors = doctorService.DoctorsWithLeastPatients().Count();

            numberOfDoctors.ShouldBe(2);


        }

        private static List<Doctor> CreateDoctors()
        {
            Room room = new Room { Id = new Guid("f6927bfe-0246-4e2b-94e1-4b8023ef3ea2"), Name = "Soba", Number = 10, Description = "Opis sobe" };
            Address address = new Address { Id = new Guid("f6927bfe-0246-4e2b-94e1-4b8023ef3ea2"), Street = "Ulica", StreetNumber = "10", City = "Grad", Country = "Država" };

            String WorkingTimeStart1 = "9:00";
            String WorkingTimeEnd1 = "12:00";
            String Speciality = HospitalLibrary.Constants.Constants.GeneralPractitioner;
            String LicenceNum1 = "12345";

            var doctors = new List<Doctor>();

            Doctor doctor1 = new Doctor(new Guid("5c036fba-1118-4f4b-b153-90d75e60625e"), "Test Doctor", "Test Doctor",
                new DateTime(1973, 9, 28, 0, 0, 0), Gender.Female, address, new Jmbg("1807000730038"),
                new Email("doctor@test.com"), "066/123-456", LicenceNum1, Speciality, WorkingTimeStart1,
                WorkingTimeEnd1, room.Id, room);

            Doctor doctor2 = new Doctor(new Guid("5c036fba-1118-4f4b-b153-90d75e60625a"), "Test Doctor", "Test Doctor",
                new DateTime(1973, 9, 28, 0, 0, 0), Gender.Female, address, new Jmbg("1807000730038"),
                new Email("doctor@test.com"), "066/123-456", LicenceNum1, Speciality, WorkingTimeStart1,
                WorkingTimeEnd1, room.Id, room);

            Doctor doctor3 = new Doctor(new Guid("5c036fba-1118-4f4b-b153-90d75e60625b"), "Test Doctor", "Test Doctor",
                new DateTime(1973, 9, 28, 0, 0, 0), Gender.Female, address, new Jmbg("1807000730038"),
                new Email("doctor@test.com"), "066/123-456", LicenceNum1, Speciality, WorkingTimeStart1,
                WorkingTimeEnd1, room.Id, room);

            doctors.Add(doctor1);
            doctors.Add(doctor2);
            doctors.Add(doctor3);
            return doctors;
        }


        public static List<Patient> CreatePatients()
        {
            Address address = new Address { Id = new Guid("f6927bfe-0246-4e2b-94e1-4b8023ef3ea2"), Street = "Ulica", StreetNumber = "10", City = "Grad", Country = "Država" };
            Room room = new Room { Id = new Guid("f6927bfe-0246-4e2b-94e1-4b8023ef3ea2"), Name = "Soba", Number = 10, Description = "Opis sobe" };

            String WorkingTimeStart1 = "9:00";
            String WorkingTimeEnd1 = "12:00";
            String Speciality = HospitalLibrary.Constants.Constants.GeneralPractitioner;
            String LicenceNum1 = "12345";

            Doctor doctor1 = new Doctor(new Guid("5c036fba-1118-4f4b-b153-90d75e60625e"), "Test Doctor", "Test Doctor",
                new DateTime(1973, 9, 28, 0, 0, 0), Gender.Female, address, new Jmbg("1807000730038"),
                new Email("doctor@test.com"), "066/123-456", LicenceNum1, Speciality, WorkingTimeStart1,
                WorkingTimeEnd1, room.Id, room);

            Doctor doctor2 = new Doctor(new Guid("5c036fba-1118-4f4b-b153-90d75e60625a"), "Test Doctor", "Test Doctor",
                new DateTime(1973, 9, 28, 0, 0, 0), Gender.Female, address, new Jmbg("1807000730038"),
                new Email("doctor@test.com"), "066/123-456", LicenceNum1, Speciality, WorkingTimeStart1,
                WorkingTimeEnd1, room.Id, room);

            Doctor doctor3 = new Doctor(new Guid("5c036fba-1118-4f4b-b153-90d75e60625b"), "Test Doctor", "Test Doctor",
                new DateTime(1973, 9, 28, 0, 0, 0), Gender.Female, address, new Jmbg("1807000730038"),
                new Email("doctor@test.com"), "066/123-456", LicenceNum1, Speciality, WorkingTimeStart1,
                WorkingTimeEnd1, room.Id, room);



            var patients = new List<Patient>();
            Patient patient1 = new Patient(new Guid("1c036fba-1118-4f4b-b153-90d75e61625e"), "Petar", "Popovic", DateTime.Now, Gender.Male, address, new Jmbg("1807000730038"),
                new Email("mail@gmail.pir"), "066413242", BloodType.FromString("A+"));
            patient1.AppointTheChosenDoctor(doctor1);

            Patient patient2 = new Patient(new Guid("2c036fba-1118-4f4b-b153-90d75e60625c"), "Petar", "Popovic", DateTime.Now, Gender.Male, address, new Jmbg("1807000730038"),
                new Email("mail@gmail.pir"), "066413242", BloodType.FromString("A+"));
            patient2.AppointTheChosenDoctor(doctor1);

            Patient patient3 = new Patient(new Guid("3c036fba-1118-4f4b-b153-90d75e20625e"), "Petar", "Popovic", DateTime.Now, Gender.Male, address, new Jmbg("1807000730038"),
                new Email("mail@gmail.pir"), "066413242", BloodType.FromString("A+"));
            patient3.AppointTheChosenDoctor(doctor1);

            Patient patient4 = new Patient(new Guid("4c036fba-1118-4f5b-b153-90d75e20625e"), "Petar", "Popovic", DateTime.Now, Gender.Male, address, new Jmbg("1807000730038"),
                new Email("mail@gmail.pir"), "066413242", BloodType.FromString("A+"));
            patient4.AppointTheChosenDoctor(doctor1);


            patients.Add(patient1);
            patients.Add(patient2);
            patients.Add(patient3);
            patients.Add(patient4);
            return patients;

        }


        private static DoctorService DoctorServiceSetup()
        {
            var patientStubRepository = new Mock<IPatientRepository>();
            patientStubRepository.Setup(m => m.GetAll()).Returns(CreatePatients());

            var doctorStubRepository = new Mock<IDoctorRepository>();
            doctorStubRepository.Setup(m => m.GetAll()).Returns(CreateDoctors());

            var doctorService = new DoctorService(doctorStubRepository.Object, patientStubRepository.Object);
            return doctorService;
        }
    }


  

}
