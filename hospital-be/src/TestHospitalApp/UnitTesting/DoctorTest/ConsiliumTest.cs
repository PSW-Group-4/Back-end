using HospitalLibrary.Appointments.Service;
using HospitalLibrary.Consiliums.Model;
using HospitalLibrary.Consiliums.Repository;
using HospitalLibrary.Consiliums.Service;
using HospitalLibrary.Doctors.Service;
using HospitalLibrary.RoomsAndEqipment.Service.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestHospitalApp.UnitTesting.DoctorTest
{
    public class ConsiliumTest
    {

        [Fact]
        public void Check_if_date_is_valid()
        {
            var doctorAppointmentService = new Mock<IDoctorAppointmentService>();
            var consiliumRepo = new Mock<IConsiliumRepository>();
            var doctorService = new Mock<IDoctorService>();
            var roomService = new Mock<IRoomService>();
            ConsiliumService cc = new ConsiliumService(consiliumRepo.Object, doctorService.Object, doctorAppointmentService.Object,roomService.Object);

            ConsiliumRequest cr = new ConsiliumRequest()
            {
                DateStart = DateTime.Now,
                DateEnd = DateTime.Now,

            };

            //var result = cc.Create()


        }



    }
}
