using System;
using HospitalAPI;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Doctors.Model;
using HospitalLibrary.MedicalAppointmentSchedulingSession;
using HospitalLibrary.MedicalAppointmentSchedulingSession.Events;
using HospitalLibrary.MedicalAppointmentSchedulingSession.Repository;
using HospitalLibrary.Patients.Model;
using HospitalLibrary.RoomsAndEqipment.Model;
using IntegrationLibrary.Common;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using TestHospitalApp.Setup;
using Xunit;

namespace TestHospitalApp.UnitTesting.MedicalAppointmentSchedulingSessionTests
{
    public class MedicalAppointmentSchedulingSessionTest : BaseIntegrationTest
    {
        public MedicalAppointmentSchedulingSessionTest(TestDatabaseFactory<Startup> factory) : base(factory) { }
        private Doctor MakeDoctor()
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
            
            Doctor doctor = new Doctor(Guid.NewGuid(), "Test Doctor Sastanak",
                "Test Doctor Sastanak",
                new DateTime(1973, 9, 28, 0, 0, 0), Gender.Female, address, new Jmbg("1807000730038"),
                new Email("doctor@test.com"), "066/123-456", "12345", "Surgeon", "03:00",
                "05:00", room.Id, room);
            return doctor;
        }

        private Patient MakePatient(Doctor doctor)
        {
            Patient patient = new Patient(Guid.NewGuid(), "Zakazivac", "Zakazivacevic", new DateTime(1990, 3, 21),
                Gender.Male, new Address(Guid.NewGuid(), "Novi Sad", "Serbia", "Paragovska", "72"),
                new Jmbg("0811000800021"), new Email("zakazivac@gmail.com"), "0612371234",
                new BloodType(BloodGroup.B, RhFactor.NEGATIVE));
            patient.AppointTheChosenDoctor(doctor);
            return patient;
        }
        [Fact]
        public void Schedules_appointment_without_going_back()
        {
            using var scope = Factory.Services.CreateScope();
            
            Doctor doctor = MakeDoctor();
            Patient patient = MakePatient(doctor);
            IMedicalAppointmentSchedulingSessionRepository repository =
                scope.ServiceProvider.GetRequiredService<IMedicalAppointmentSchedulingSessionRepository>();
            


            MedicalAppointmentSchedulingSession session = new MedicalAppointmentSchedulingSession(repository);
            
            session.Causes(new StartedScheduling(session.Id, DateTime.Now, patient));
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
            using var scope = Factory.Services.CreateScope();
            
            Doctor doctor = MakeDoctor();
            Patient patient = MakePatient(doctor);
            IMedicalAppointmentSchedulingSessionRepository repository =
                scope.ServiceProvider.GetRequiredService<IMedicalAppointmentSchedulingSessionRepository>();
            


            MedicalAppointmentSchedulingSession session = new MedicalAppointmentSchedulingSession(repository);
            
            session.Causes(new StartedScheduling(session.Id, DateTime.Now, patient));
            session.Causes(new ChosenDate(session.Id, DateTime.Now, new DateTime(2023, 1, 14 ))); 
            session.Causes(new ChosenSpeciality(session.Id, DateTime.Now, "Chiropractor"));
            session.Causes(new ChosenDoctor(session.Id, DateTime.Now, doctor));
            session.Causes(new GoneBackToSelection(session.Id, DateTime.Now, Selection.Doctor));
            session.Causes(new ChosenDoctor(session.Id, DateTime.Now, doctor));
            session.Causes(new FinishedScheduling(session.Id,DateTime.Now, new DateTime(2023, 1, 14, 12,30,0)));

            var properties = session.GetType().GetProperties();
            properties.ShouldAllBe(field => field.GetValue(session) != null);
        }

        [Fact]
        public void Loads_unfinished_session()
        {
            using var scope = Factory.Services.CreateScope();
            
            IMedicalAppointmentSchedulingSessionRepository repository =
                scope.ServiceProvider.GetRequiredService<IMedicalAppointmentSchedulingSessionRepository>();

            MedicalAppointmentSchedulingSession session =
                repository.GetById(new Guid("0e34318e-0bf6-4c8d-8b0e-153dae18d80b"));
            var address = session.SelectedDoctor.Address;
            
            session.IsScheduled.ShouldBeFalse();
        }
        
        
        [Fact]
        public void Loads_finished_session()
        {
            using var scope = Factory.Services.CreateScope();
            
            IMedicalAppointmentSchedulingSessionRepository repository =
                scope.ServiceProvider.GetRequiredService<IMedicalAppointmentSchedulingSessionRepository>();

            MedicalAppointmentSchedulingSession session =
                repository.GetById(new Guid("055f61ca-9487-495f-8229-590c24e7b7da"));
            var address = session.SelectedDoctor.Address;
            
            session.IsScheduled.ShouldBeTrue();
            session.Patient.ShouldNotBeNull();
            session.SelectedDoctor.ShouldNotBeNull();
        }
    }
}