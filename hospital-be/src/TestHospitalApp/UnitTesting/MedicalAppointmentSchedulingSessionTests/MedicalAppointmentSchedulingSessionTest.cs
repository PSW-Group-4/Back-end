using System;
using System.Reflection;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Doctors.Model;
using HospitalLibrary.MedicalAppointmentSchedulingSession;
using HospitalLibrary.MedicalAppointmentSchedulingSession.Events;
using HospitalLibrary.Patients.Model;
using HospitalLibrary.RoomsAndEqipment.Model;
using IntegrationLibrary.Common;
using Shouldly;
using Xunit;

namespace TestHospitalApp.UnitTesting.MedicalAppointmentSchedulingSessionTests
{
    public class MedicalAppointmentSchedulingSessionTest
    {
        private Doctor MakeDoctor()
        {
            Address address = new Address
            {
                Id = new Guid("f6927bfe-0246-4e2b-94e1-4b8123ef3ea3"), Street = "Ulica", StreetNumber = "10", City = "Grad",
                Country = "Država"
            };
            
            Room room = new Room
            {
                Id = new Guid("f6927bfe-0246-4e2b-94e1-4b8023ef3ea3"), Name = "Soba", Number = 10, Description = "Opis sobe"
            };
            
            Doctor doctor = new Doctor(new Guid("5c125fba-1318-4f4b-b153-90d75e60626e"), "Test Doctor Sastanak",
                "Test Doctor Sastanak",
                new DateTime(1973, 9, 28, 0, 0, 0), Gender.Female, address, new Jmbg("1807000730038"),
                new Email("doctor@test.com"), "066/123-456", "12345", "Surgeon", "03:00",
                "05:00", room.Id, room);
            return doctor;
        }

        private Patient MakePatient()
        {
            Patient patient = new Patient(Guid.NewGuid(), "Zakazivac", "Zakazivacevic", new DateTime(1990, 3, 21),
                Gender.Male, new Address(Guid.NewGuid(), "Novi Sad", "Serbia", "Paragovska", "72"),
                new Jmbg("0811000800021"), new Email("zakazivac@gmail.com"), "0612371234",
                new BloodType(BloodGroup.B, RhFactor.NEGATIVE));
            return patient;
        }
        [Fact]
        public void Schedules_appointment_without_going_back()
        {
            Patient patient = MakePatient();
            Doctor doctor = MakeDoctor();


            MedicalAppointmentSchedulingSession session = new MedicalAppointmentSchedulingSession(patient, DateTime.Now);
            
            session.Causes(new ChosenDate(session.Id, DateTime.Now, new DateTime(2023, 1, 14 ))); 
            session.Causes(new ChosenSpeciality(session.Id, DateTime.Now, "Chiropractor"));
            session.Causes(new ChosenDoctor(session.Id, DateTime.Now, doctor));
            session.Causes(new FinishedScheduling(session.Id,DateTime.Now, new DateTime(2023, 1, 14, 12,30,0)));

            var properties = session.GetType().GetProperties();
            properties.ShouldAllBe(field => field.GetValue(session) != null);
        }

        [Fact]
        public void Schedules_appointment_with_going_back_to_doctor_selection()
        {
            Patient patient = MakePatient();
            Doctor doctor = MakeDoctor();


            MedicalAppointmentSchedulingSession session = new MedicalAppointmentSchedulingSession(patient, DateTime.Now);
            
            session.Causes(new ChosenDate(session.Id, DateTime.Now, new DateTime(2023, 1, 14 ))); 
            session.Causes(new ChosenSpeciality(session.Id, DateTime.Now, "Chiropractor"));
            session.Causes(new ChosenDoctor(session.Id, DateTime.Now, doctor));
            session.Causes(new GoneBackToSelection(session.Id, DateTime.Now, Selection.Doctor));
            session.Causes(new ChosenDoctor(session.Id, DateTime.Now, doctor));
            session.Causes(new FinishedScheduling(session.Id,DateTime.Now, new DateTime(2023, 1, 14, 12,30,0)));

            var properties = session.GetType().GetProperties();
            properties.ShouldAllBe(field => field.GetValue(session) != null);
        }
    }
}