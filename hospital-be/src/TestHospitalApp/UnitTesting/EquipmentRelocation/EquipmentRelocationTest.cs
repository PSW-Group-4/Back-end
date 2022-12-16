using HospitalLibrary.Patients.Model;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using HospitalLibrary.EquipmentRelocation.DTO;
using Moq;
using HospitalLibrary.Doctors.Service;
using HospitalLibrary.Appointments.Service;
using HospitalLibrary.RoomsAndEqipment.Service.Interfaces;
using HospitalLibrary.RoomsAndEqipment.Service.Implementation;
using HospitalLibrary.Appointments.Model;
using HospitalLibrary.Appointments.Repository;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Service;
using HospitalLibrary.Core.Repository;

namespace TestHospitalApp.UnitTesting.EquipmentRelocation
{
    public class EquipmentRelocationTest
    {
        [Fact]
        public void Is_list_full()
        {
            HospitalLibrary.EquipmentRelocation.DTO.EquipmentRelocationDTO equipmentRelocation = new HospitalLibrary.EquipmentRelocation.DTO.EquipmentRelocationDTO(new DateRange(new DateTime(2022, 12, 11, 23, 0, 0), new DateTime(2022, 12, 13, 10, 0, 0)), 37, Guid.Parse("133962ea-c543-497b-81a6-6a2efb54212a"), Guid.Parse("9ae3255d-261f-472f-a961-7f2e7d05d95c"));
            List<DateTime> result = new List<DateTime>();
            var doctorService = new Mock<IDoctorService>();
            var mService = new Mock<IAppointmentRepository>();
            var apServ = new Mock<IAppointmentService>();
            AppointmentService service = new AppointmentService(mService.Object, doctorService.Object);
            List<Appointment> appointments = new List<Appointment>();
            // appointments.Add(new Appointment { RoomId = Guid.Parse("9ae3255d-261f-472f-a961-7f2e7d05d95c"), DateRange = new HospitalLibrary.Core.Model.DateRange(new DateTime(2022, 12, 12, 0, 0, 0), new DateTime(2022, 12, 12, 0, 30, 0)) });
            // appointments.Add(new Appointment { RoomId = Guid.Parse("9ae3255d-261f-472f-a961-7f2e7d05d95c") });
            appointments.Add(new Appointment(Guid.NewGuid(),
                new DateRange(new DateTime(2022, 12, 12, 0, 0, 0),
                    new DateTime(2022, 12, 12, 0, 30, 0)),Guid.Parse("9ae3255d-261f-472f-a961-7f2e7d05d95c"), null));

            appointments.Add(new Appointment(Guid.NewGuid(),
                new DateRange(new DateTime(2022, 12, 12, 0, 0, 0),
                    new DateTime(2022, 12, 12, 0, 30, 0)),Guid.Parse("9ae3255d-261f-472f-a961-7f2e7d05d95c"), null));

            apServ.Setup(x => x.GetAll()).Returns(appointments);

            result = service.RecommendStartForRelocationOrRenovation(equipmentRelocation).ToList();

            result.ShouldNotBeEmpty();
        }
    }
}
