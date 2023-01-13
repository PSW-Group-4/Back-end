using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.Appointments.Model;
using HospitalLibrary.BuildingManagment.Model;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Doctors.Model;
using HospitalLibrary.Medicines.Model;
using HospitalLibrary.Patients.Model;
using HospitalLibrary.Reports.Model;
using HospitalLibrary.Reports.Repository;
using HospitalLibrary.Reports.Service;
using HospitalLibrary.RoomsAndEqipment.Model;
using HospitalLibrary.RoomsAndEqipment.Repository.Interfaces;
using HospitalLibrary.RoomsAndEqipment.Service.Implementation;
using HospitalLibrary.RoomsAndEqipment.Service.Interfaces;
using HospitalLibrary.Symptoms.Model;
using IntegrationLibrary.Common;
using Moq;
using Shouldly;
using Xunit;


namespace TestHospitalApp.UnitTesting.BedTest
{
    public class SearchReportTest
    {
        [Fact]
        public void search_name()
        {

            var stubRepository = new Mock<IReportRepository>();
            var reports = new List<Report>();

            Address address = new Address { Id = new Guid("f6927bfe-0246-4e2b-94e1-4b8123ef3ea2"), Street = "Ulica", StreetNumber = "10", City = "Grad", Country = "Država" };
            

            Building building = new Building { Id = new Guid("f6923bfe-0246-4e2b-94e1-4b8023ef3ea2"), Name = "Zgrada" };
            

            Room room = new Room { Id = new Guid("f6927bfe-0246-4e2b-94e1-4b8023ef3ea2"), Name = "Soba", Number = 10, Description = "Opis sobe" };
            

            String WorkingTimeStart1 = "9:00";
            String WorkingTimeEnd1 = "12:00";
            String Speciality1 = "Surgeon";
            String LicenceNum1 = "12345";


            Doctor doctor = new Doctor(new Guid("5c036fba-1118-4f4b-b153-90d75e60625e"), "Test Doctor", "Test Doctor",
                new DateTime(1973, 9, 28, 0, 0, 0), Gender.Female, address, new Jmbg("1807000730038"),
                new Email("doctor@test.com"), "066/123-456", LicenceNum1, Speciality1, WorkingTimeStart1,
                WorkingTimeEnd1, room.Id, room);


            Symptom symptom1 = new Symptom(new Guid(), "Povišena temperatura");
            Medicine medicine1 = new Medicine(new Guid(), "Aspirin");
            
            List<Medicine> medicines = new List<Medicine>();
            medicines.Add(medicine1);
            List<Prescription> prescriptions = new List<Prescription>();

            Patient patient = new Patient(new Guid("f6927bfe-0246-4e2b-94e1-4b8023ef3ea1"), "Petar", "Popovic", DateTime.Now, Gender.Male, address, new Jmbg("1807000730038"),
                new Email("mail@gmail.pir"), "066413242", BloodType.FromString("A+"));
            patient.AppointTheChosenDoctor(doctor);

            MedicalAppointment medicalAppointment = new MedicalAppointment(
                new Guid("9d01e700-70a4-4b1c-958c-2c587ec94b4b"),
                new DateRange(DateTime.Now, DateTime.Now.AddMinutes(30)),
                room.Id, null, new Guid("5c036fba-1118-4f4b-b153-90d75e60625e"), null, patient.Id, null, false);

            Prescription prescription = new Prescription(medicines);
            prescriptions.Add(prescription);
            List<Symptom> symptoms = new List<Symptom>();
            symptoms.Add(symptom1);

            Report report = new Report(new Guid("058eb841-3975-4c7a-83ad-8b81dd6744d9"), new Guid("9d01e700-70a4-4b1c-958c-2c587ec94b4b"),
                "Opaka bolest", symptoms, prescriptions, new DateTime(2022, 9, 28, 0, 0, 0));

            // stubRepository.Setup(m => m.GetAll()).Returns(beds);
            ReportService service = new ReportService(stubRepository.Object);

            List<Report> res = service.BasicSearch("Nepostojeceime");

            res.ShouldBeNull();


        }
    }
}
