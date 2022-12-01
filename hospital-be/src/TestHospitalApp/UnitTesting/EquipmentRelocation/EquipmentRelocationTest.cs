using HospitalLibrary.Patients.Model;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using HospitalLibrary.EquipmentRelocation.DTO;
using HospitalLibrary.EquipmentRelocation.Service;
using Moq;
using HospitalLibrary.Doctors.Service;
using HospitalLibrary.Appointments.Service;
using HospitalLibrary.RoomsAndEqipment.Service.Interfaces;
using HospitalLibrary.RoomsAndEqipment.Service.Implementation;
using HospitalLibrary.Appointments.Model;

namespace TestHospitalApp.UnitTesting.EquipmentRelocation
{
    public class EquipmentRelocationTest
    {
        [Fact]
        public void Is_list_full()
        {
            HospitalLibrary.EquipmentRelocation.DTO.EquipmentRelocationDTO equipmentRelocation = new HospitalLibrary.EquipmentRelocation.DTO.EquipmentRelocationDTO(new DateTime(2022, 12, 11, 23, 0, 0), 37, Guid.Parse("133962ea-c543-497b-81a6-6a2efb54212a"), Guid.Parse("9ae3255d-261f-472f-a961-7f2e7d05d95c"));
            List<DateTime> result = new List<DateTime>();
            var appointmentService = new Mock<IRoomScheduleService>();
            EquipmentRelocationService service = new EquipmentRelocationService( appointmentService.Object);
            List<Appointment> appointments = new List<Appointment>();
            appointments.Add(new Appointment { RoomId = Guid.Parse("9ae3255d-261f-472f-a961-7f2e7d05d95c") });
            appointments.Add(new Appointment { RoomId = Guid.Parse("9ae3255d-261f-472f-a961-7f2e7d05d95c") });


            appointmentService.Setup(x => x.GetAll()).Returns(appointments);

            result = service.RecommendRelocationStart(equipmentRelocation);

            result.ShouldNotBeEmpty();
            result.Count().ShouldBe(10);
        }
    }
}
