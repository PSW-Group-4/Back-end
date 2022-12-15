using HospitalLibrary.Appointments.Model;
using HospitalLibrary.Appointments.Repository;
using HospitalLibrary.Appointments.Service;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Doctors.Service;
using HospitalLibrary.Patients.Model;
using HospitalLibrary.Patients.Service;
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
    public class PatientAvailabilityTests
    {
        [Fact]
        public void Patient_free()  //promeni za datum
        {
            var patient = SetupPatients()[0];
            bool isFree = SetupMedicalAppointmentService().IsPatientFree(
                patient.Id, new DateRange(DateTime.Now, DateTime.Now.AddHours(1)));     

            isFree.ShouldBeTrue();
        }

        [Fact]
        public void Patient_on_appointment()    //promeni za datum
        {
            var patient = SetupPatients()[1];
            bool isFree = SetupMedicalAppointmentService().IsPatientFree(
                patient.Id, new DateRange(DateTime.Now, DateTime.Now.AddHours(1)));

            isFree.ShouldBeFalse();
        }

        public List<Patient> SetupPatients()
        {
            var result = new List<Patient>();

            var patient1 = new Patient 
            { Id = new Guid("C886585A-7D0C-4EA1-8016-6E4386A28925") };

            var patient2 = new Patient
            { Id = new Guid("3C1F4E71-2381-47C9-A19F-34FE98DDA84B") };

            result.Add(patient1); result.Add(patient2);
            return result;
        }

        public List<MedicalAppointment> SetupMedicalAppointments()      //promeni za datum
        {
            var patients = SetupPatients();
            var result = new List<MedicalAppointment>();

            var medicalAppointment = new MedicalAppointment
            {
                Id = new Guid("434393D7-E0BE-4087-B24A-930B26DFDE30"),
                DateRange = new DateRange(DateTime.Now, DateTime.Now.AddMinutes(30)),
                PatientId = patients[1].Id
            };

            return result;
        }

        public MedicalAppointmentService SetupMedicalAppointmentService()
        {
            var medicalAppointmentRepository = new Mock<IMedicalAppointmentRepository>();
            medicalAppointmentRepository.Setup(m => m.GetAll()).Returns(SetupMedicalAppointments());

            var doctorService = new Mock<IDoctorService>();
            var patientService = new Mock<IPatientService>();

            var medicalAppointmentService = new MedicalAppointmentService(
                medicalAppointmentRepository.Object, doctorService.Object, patientService.Object);

            return medicalAppointmentService;
        }
    }
}
