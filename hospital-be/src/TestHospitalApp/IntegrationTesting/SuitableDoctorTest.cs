using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Constants;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Doctors.Model;
using HospitalLibrary.Doctors.Repository;
using HospitalLibrary.Doctors.Service;
using HospitalLibrary.Patients.Model;
using HospitalLibrary.Patients.Repository;
using HospitalLibrary.Settings;
using Microsoft.EntityFrameworkCore;
using Moq;
using Shouldly;
using Xunit;

namespace TestHospitalApp.IntegrationTesting
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
            var doctors = new List<Doctor>();
            Doctor doctor1 = new Doctor
            {
                Id = new Guid("5c036fba-1118-4f4b-b153-90d75e60625e"),
                Name = "Test Doctor1",
                Surname = "Test Doctor1",
                Speciality = HospitalLibrary.Constants.Constants.GeneralPractitioner,

            };
            Doctor doctor2 = new Doctor
            {
                Id = new Guid("5c036fba-1118-4f4b-b153-90d75e60625a"),
                Name = "Test Doctor2",
                Surname = "Test Doctor2",
                Speciality = HospitalLibrary.Constants.Constants.GeneralPractitioner,

            };
            Doctor doctor3 = new Doctor
            {
                Id = new Guid("5c036fba-1118-4f4b-b153-90d75e60625b"),
                Name = "Test Doctor3",
                Surname = "Test Doctor3",
                Speciality = HospitalLibrary.Constants.Constants.GeneralPractitioner,

            };
            doctors.Add(doctor1);
            doctors.Add(doctor2);
            doctors.Add(doctor3);
            return doctors;
        }


        public static List<Patient> CreatePatients()
        {
            var patients = new List<Patient>();
            Patient patient1 = new Patient
            {
                Id = new Guid("1c036fba-1118-4f4b-b153-90d75e61625e"),
                ChoosenDoctorId = new Guid("5c036fba-1118-4f4b-b153-90d75e60625e"),
            };
            Patient patient2 = new Patient
            {
                Id = new Guid("2c036fba-1118-4f4b-b153-90d75e60625c"),
                ChoosenDoctorId = new Guid("5c036fba-1118-4f4b-b153-90d75e60625e"),
            };
            Patient patient3 = new Patient
            {
                Id = new Guid("3c036fba-1118-4f4b-b153-90d75e20625e"),
                ChoosenDoctorId = new Guid("5c036fba-1118-4f4b-b153-90d75e60625e"),
            };
            Patient patient4 = new Patient
            {
                Id = new Guid("4c036fba-1118-4f5b-b153-90d75e20625e"),
                ChoosenDoctorId = new Guid("5c036fba-1118-4f4b-b153-90d75e60625e"),
            };

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
            doctorStubRepository.Setup(m => m.GetAll()).Returns(CreateDoctors);

            var doctorService = new DoctorService(doctorStubRepository.Object, patientStubRepository.Object);
            return doctorService;
        }
    }


  

}
