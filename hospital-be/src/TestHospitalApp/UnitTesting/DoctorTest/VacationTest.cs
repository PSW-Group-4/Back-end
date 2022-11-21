using HospitalLibrary.Appointments.Model;
using HospitalLibrary.Appointments.Service;
using HospitalLibrary.Doctors.Model;
using HospitalLibrary.Vacations.Repository;
using HospitalLibrary.Vacations.Service;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestHospitalApp.UnitTesting.DoctorTest
{
    public class VacationTest
    {
        [Fact]
        public void Check_if_doctor_has_appointments_during_vacation()
        {
            Guid DoctorId = new Guid("1");

            List<Appointment> doctorAppointments = new List<Appointment>();



            doctorAppointments.Add(new Appointment
            {
                DoctorId = DoctorId,
                DateTime = new DateTime(2022, 12, 25, 0, 0, 0)
            });
            doctorAppointments.Add(new Appointment
            {
                DoctorId = DoctorId,
                DateTime = new DateTime(2022, 11, 25, 0, 0, 0)
            });


            var doctorAppointmentService = new Mock<IDoctorAppointmentService>();

            doctorAppointmentService.Setup(x => x.GetDoctorAppointments(DoctorId)).Returns(doctorAppointments);

            var vacationRepo = new Mock<IVacationRepository>();
            VacationService vc = new VacationService(vacationRepo.Object, doctorAppointmentService.Object);

            var result = vc.CheckDoctorAvailability(DoctorId, new DateTime(2022, 12, 25, 0, 0, 0), new DateTime(2022, 12, 25, 0, 0, 0));

            result.ShouldBeTrue();
            
        }

    }
}
