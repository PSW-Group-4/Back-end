using System;
using HospitalAPI;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Doctors.Model;
using HospitalLibrary.MedicalAppointmentReportSession;
using HospitalLibrary.MedicalAppointmentReportSession.Model.Events;
using HospitalLibrary.MedicalAppointmentReportSession.Repository;
using HospitalLibrary.Patients.Model;
using HospitalLibrary.RoomsAndEqipment.Model;
using IntegrationLibrary.Common;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using TestHospitalApp.Setup;
using Xunit;

namespace TestHospitalApp.IntegrationTesting.MedicalReportEventSourceTests
{
    public class CreateReportSessionTest : BaseIntegrationTest
    {
        public CreateReportSessionTest(TestDatabaseFactory<Startup> factory) : base(factory) { }
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

            Doctor doctor = new Doctor(Guid.NewGuid(), "Test Doctor Report",
                "Test Doctor Report",
                new DateTime(1980, 10, 1, 0, 0, 0), Gender.Male, address, new Jmbg("0811000800021"),
                new Email("doctorreport@test.com"), "066/123-456", "12345", "Surgeon", "03:00",
                "05:00", room.Id, room);

            return doctor;
        }

        private Patient MakePatient(Doctor doctor)
        {
            Patient patient = new Patient(Guid.NewGuid(), "Test Patient Report", "Test Patient Report", new DateTime(1990, 10, 1),
                Gender.Female, new Address(Guid.NewGuid(), "Novi Sad", "Serbia", "Ulica 1", "50"),
                new Jmbg("0811000800021"), new Email("pacijent@gmail.com"), "066/555-666",
                new BloodType(BloodGroup.O, RhFactor.POSITIVE));
            patient.AppointTheChosenDoctor(doctor);
            return patient;
        }

        [Fact]
        public void Creates_report_without_going_back()
        {
            using var scope = Factory.Services.CreateScope();

            Doctor doctor = MakeDoctor();
            Patient patient = MakePatient(doctor);
            IMedicalAppointmentReportSessionRepository repository = scope.ServiceProvider.GetRequiredService<IMedicalAppointmentReportSessionRepository>();

            MedicalAppointmentReportSession session = new MedicalAppointmentReportSession(repository);

            session.Causes(new StartedScheduling(session.Id, DateTime.Now, doctor));
            session.Causes(new ChosenSymptom(session.Id, DateTime.Now, 1));
            session.Causes(new ChosenReportText(session.Id, DateTime.Now, "Report"));
            session.Causes(new ChosenMedicine(session.Id, DateTime.Now, 1));
            session.Causes(new FinishedScheduling(session.Id, DateTime.Now, new DateTime(2023, 1, 20, 13, 0, 0)));

            var properties = session.GetType().GetProperties();
            properties.ShouldAllBe(field => field.GetValue(session) != null);
        }

        [Fact]
        public void Creates_report_with_going_back_to_report_text_input()
        {
            using var scope = Factory.Services.CreateScope();

            Doctor doctor = MakeDoctor();
            Patient patient = MakePatient(doctor);
            IMedicalAppointmentReportSessionRepository repository = scope.ServiceProvider.GetRequiredService<IMedicalAppointmentReportSessionRepository>();

            MedicalAppointmentReportSession session = new MedicalAppointmentReportSession(repository);

            session.Causes(new StartedScheduling(session.Id, DateTime.Now, doctor));
            session.Causes(new ChosenSymptom(session.Id, DateTime.Now, 1));
            session.Causes(new ChosenReportText(session.Id, DateTime.Now, "Report"));
            session.Causes(new ChosenMedicine(session.Id, DateTime.Now, 1));
            session.Causes(new GoneBackToSelection(session.Id, DateTime.Now, SelectionReport.ReportText));
            session.Causes(new ChosenReportText(session.Id, DateTime.Now, "Fixed Report"));
            session.Causes(new FinishedScheduling(session.Id, DateTime.Now, new DateTime(2023, 1, 20, 13, 0, 0)));

            var properties = session.GetType().GetProperties();
            properties.ShouldAllBe(field => field.GetValue(session) != null);
        }

        [Fact]
        public void Loads_unfinished_session()
        {
            using var scope = Factory.Services.CreateScope();

            IMedicalAppointmentReportSessionRepository repository = scope.ServiceProvider.GetRequiredService<IMedicalAppointmentReportSessionRepository>();

            MedicalAppointmentReportSession session = repository.GetById(new Guid("4f82557d-2a4d-4f1f-9f0f-02196f1a7d4f"));
            
            session.IsScheduled.ShouldBeFalse();
        }


        [Fact]
        public void Loads_finished_session()
        {
            using var scope = Factory.Services.CreateScope();

            IMedicalAppointmentReportSessionRepository repository = scope.ServiceProvider.GetRequiredService<IMedicalAppointmentReportSessionRepository>();

            MedicalAppointmentReportSession session = repository.GetById(new Guid("c4b12ea1-417c-4f89-9028-67077a229661"));

            session.IsScheduled.ShouldBeTrue();
        }
    }
}