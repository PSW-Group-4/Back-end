using HospitalLibrary.Appointments.Model;
using HospitalLibrary.Appointments.Repository;
using HospitalLibrary.Appointments.Service;
using HospitalLibrary.Consiliums.Model;
using HospitalLibrary.Consiliums.Repository;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Doctors.Model;
using HospitalLibrary.Doctors.Repository;
using HospitalLibrary.Doctors.Service;
using HospitalLibrary.Patients.Model;
using HospitalLibrary.Patients.Service;
using HospitalLibrary.RoomsAndEqipment.Model;
using HospitalLibrary.Vacations.Repository;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestHospitalApp.UnitTesting.MedicalAppointmentTests
{
    public class DoctorAvailabilityTests
    {
        [Fact]
        public void Doctor_available()  //promeni za datum
        {
            var doctor = SetupDoctors()[0];
            bool isAvailable = SetupDoctorAppointmentService().IsDoctorAvailable(doctor.Id, DateTime.Now);

            isAvailable.ShouldBeTrue();
        }

        [Fact]
        public void Doctor_working()    //promeni za datum
        {
            var doctor = SetupDoctors()[1];  
            bool isAvailable = SetupDoctorAppointmentService().IsDoctorAvailable(doctor.Id, DateTime.Now); 

            isAvailable.ShouldBeFalse();
        }

        [Fact]
        public void Doctor_on_medical_appointment() //promeni za datum
        {
            var doctor = SetupDoctors()[2];
            bool isAvailable = SetupDoctorAppointmentService().IsDoctorAvailable(doctor.Id, DateTime.Now);

            isAvailable.ShouldBeFalse();
        }

        [Fact]
        public void Doctor_on_consilium()   //promeni za datum
        {
            var doctor = SetupDoctors()[3];
            bool isAvailable = SetupDoctorAppointmentService().IsDoctorAvailable(doctor.Id, DateTime.Now);

            isAvailable.ShouldBeFalse();
        }

        private static List<Doctor> SetupDoctors()
        {
            var result = new List<Doctor>();

            var doctor1 = new Doctor() { Id = new Guid("5c036fba-1118-4f4b-b153-90d75e60625e"), WorkingTimeStart = "9:30",
            WorkingTimeEnd = "17:30", RoomId = new Guid("5c036fba-1118-4f4b-b153-90d75e60625e"), 
                Room = new Room() { Id = new Guid("5c036fba-1118-4f4b-b153-90d75e60625e") }
            };

            var doctor2 = new Doctor()
            {
                Id = new Guid("27BBFC73-1D60-41AC-9E61-18E896B91A16"),
                WorkingTimeStart = "9:30",
                WorkingTimeEnd = "17:30",
                RoomId = new Guid("5c036fba-1118-4f4b-b153-90d75e60625e"),
                Room = new Room() { Id = new Guid("5c036fba-1118-4f4b-b153-90d75e60625e") }
            };

            var doctor3 = new Doctor()
            {
                Id = new Guid("340894B8-3F12-4DEF-904C-375F4D4C96DD"),
                WorkingTimeStart = "9:30",
                WorkingTimeEnd = "17:30",
                RoomId = new Guid("5c036fba-1118-4f4b-b153-90d75e60625e"),
                Room = new Room() { Id = new Guid("5c036fba-1118-4f4b-b153-90d75e60625e") }
            };

            var doctor4 = new Doctor()
            {
                Id = new Guid("48A84F6A-EBC2-4D7B-8791-BFD17E96B48B"),
                WorkingTimeStart = "9:30",
                WorkingTimeEnd = "17:30",
                RoomId = new Guid("5c036fba-1118-4f4b-b153-90d75e60625e"),
                Room = new Room() { Id = new Guid("5c036fba-1118-4f4b-b153-90d75e60625e") }
            };

            result.Add(doctor1); result.Add(doctor2); result.Add(doctor3); result.Add(doctor4);
            return result;
        }

        private static List<MedicalAppointment> SetupMedicalAppointments()
        {
            var doctor = SetupDoctors()[2];
            var result = new List<MedicalAppointment>();

            var appointment = new MedicalAppointment()
            {
                Id = new Guid("5c036fba-1118-4f4b-b153-90d75e60625e"),
                DateRange = new DateRange(DateTime.Now, DateTime.Now.AddHours(2)),
                DoctorId = doctor.Id,
                Doctor = doctor,
                PatientId = new Guid("5c036fba-1118-4f4b-b153-90d75e60625e"),
                Patient = new Patient() { Id = new Guid("5c036fba-1118-4f4b-b153-90d75e60625e") },
                IsCanceled = false
            };

            result.Add(appointment);
            return result;
        }

        private static List<Consilium> SetupConsiliums()
        {
            var doctors = new List<Doctor>();
            doctors.Add(SetupDoctors()[3]);

            var result = new List<Consilium>();

            Consilium consilium = new Consilium() {
                Id = new Guid("5c036fba-1118-4f4b-b153-90d75e60625e"),
                DateRange = new DateRange(DateTime.Now, DateTime.Now.AddHours(2)),
                Doctors = doctors
            };
            return result;
        }

        private static DoctorAppointmentService SetupDoctorAppointmentService()
        {
            var medicalAppointmentService = SetupMedicalAppointmentService();
            var doctorRepository = new Mock<IDoctorRepository>();
            var vacationRepository = new Mock<IVacationRepository>();
            var consiliumRepository = new Mock<IConsiliumRepository>();
            consiliumRepository.Setup(m => m.GetAll()).Returns(SetupConsiliums());

            DoctorAppointmentService service = new DoctorAppointmentService(
                medicalAppointmentService, doctorRepository.Object, vacationRepository.Object, consiliumRepository.Object);

            return service; 
        }

        private static MedicalAppointmentService SetupMedicalAppointmentService()
        {
            var doctorService = new Mock<IDoctorService>();
            var patientService = new Mock<IPatientService>();
            var medicalAppointmentRepository = new Mock<IMedicalAppointmentRepository>();
            medicalAppointmentRepository.Setup(m => m.GetAll()).Returns(SetupMedicalAppointments());

            var service = 
                new MedicalAppointmentService(medicalAppointmentRepository.Object, doctorService.Object, patientService.Object);

            return service;
        }
    }
}
